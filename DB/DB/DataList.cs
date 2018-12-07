using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace DB
{
	public class DataList
	{
		private SqlConnection connection;
		private SqlDataReader reader;
		private List<Item> list;
		private DataTable dataTable;
		private SqlCommand command;
		private string table;
		private string idField;


		protected SqlCommand Command
		{
			get { return command; }
			set { command = value; }
		}

		protected string Table
		{
			get { return table; }
			set { table = value; }
		}


		protected string IdField
		{
			get { return idField; }
			set { idField = value; }
		}


		public DataTable DataTable
		{
			get { return dataTable; }
			set { dataTable = value; }
		}

		public DataList(string table, string idField)
		{
			list = new List<Item>();
			this.table = table;
			this.idField = idField;
			connection =
				new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Source\\Repos\\AdvProject\\DB\\DB\\College.mdf;Integrated Security=True;Connect Timeout=30");
			command = connection.CreateCommand();
			dataTable = new DataTable();

		}





		//protected as used only by subclasses
		protected SqlConnection Connection
		{
			get { return connection; }
			set { connection = value; }
		}

		//protected as used only by subclasses
		protected SqlDataReader Reader
		{
			get { return reader; }

			set
			{
				reader = value;
			}
		}

		public List<Item> List
		{
			get { return list; }

			set
			{
				list = value;
			}
		}

		public void SetDataTableColumns(Item item)
		{

			dataTable.Clear();
			dataTable.Columns.Clear();
			Type type = item.GetType();

			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties)
			{
				dataTable.Columns.Add(property.Name);
			}

		}

		public void AddDataTableRow(Item item)
		{
			int count = 0;
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();
			string[] values = new string[properties.Count()];

			foreach (PropertyInfo property in properties)
			{
				values[count] = property.GetValue(item).ToString();
				count++;
			}
			dataTable.Rows.Add(values);
		}

		public virtual void Populate()
		{
			connection.Open();
			command.CommandText = "SELECT * FROM " + table;
			reader = command.ExecuteReader();
			GenerateList();
		}

		public virtual void Filter(string field, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@field", field);
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "SELECT * FROM " + table + " WHERE " + @field + " = @value";
			reader = command.ExecuteReader();
			GenerateList();
		}

		protected virtual void GenerateList()
		{ }

		protected void SetValues(Item item)
		{
			Type type = item.GetType();

			PropertyInfo[] properties = type.GetProperties();

			int fieldCount = 0;
			foreach (PropertyInfo property in properties)
			{
				property.SetValue(item, reader.GetValue(fieldCount).ToString());
				fieldCount++;
			}
		}

		public void Populate(Item item)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@id", item.getID());
			command.CommandText = "SELECT * FROM " + table + " WHERE " + idField + " = @id";
			reader = command.ExecuteReader();
			reader.Read();
			SetValues(item);
			reader.Close();
			connection.Close();

		}

		public void Update(Item item)
		{
			connection.Open();
			command.Parameters.Clear();
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties)
			{
				if (property.GetValue(item) != null) //if the property value is not null
				{
					//if the current property is not the ID Field
					if (!property.Name.Equals(idField, StringComparison.InvariantCultureIgnoreCase))
					{
						//use parameter for the user value - prevent SQL injection
						command.Parameters.AddWithValue("@id", item.getID());
						command.Parameters.AddWithValue("@value", property.GetValue(item));

						//generate SQL Update string for the current property name and value
						command.CommandText = "UPDATE " + table +
							" SET " + property.Name + " = @value WHERE " + idField + " =  @id";
						command.ExecuteNonQuery(); //execute command; update the database
						command.Parameters.Clear(); //clear parameter for next iteration of loop
					}
				}
			}
			connection.Close();
		}

		/*builds an Add string from the Item Properties collection 
        and uses it to add a new Item to the database */
		public void Add(Item item)
		{
			connection.Open();
			command.CommandText = "SELECT * FROM " + table;
			reader = command.ExecuteReader(CommandBehavior.KeyInfo);
			DataTable schemaTable = reader.GetSchemaTable();
			reader.Close();

			command.Parameters.Clear();
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();
			int count = 0;
			//create the first part of the Add SQL string
			string addString = "INSERT INTO " + table + "(";

			//add each item property name to the string
			foreach (PropertyInfo property in properties)
			{
				if (!schemaTable.Rows[count]["IsAutoIncrement"].ToString().Equals("True"))
				{
					addString += property.Name;
					count++;
					//add a comma until end of Properties collection is reached
					if (count < properties.Count())
					{ addString += ", "; }
				}
				else
				{
					count++;
				}
			}


			//start second part of Add string
			addString += ") VALUES(";
			count = 0;
			int paramCounter = 1;
			//add each item property value to the string
			foreach (PropertyInfo property in properties)
			{
				if (!schemaTable.Rows[count]["IsAutoIncrement"].ToString().Equals("True"))
				{
					if (property.GetValue(item) != null)
					{
						command.Parameters.AddWithValue("@" + paramCounter, property.GetValue(item));
						addString += "@" + paramCounter; //insert parameter in string
						paramCounter++;
					}
					else
					{ addString += "NULL"; }
					count++;
					//add a comma until end of Properties collection is reached
					if (count < properties.Count())
					{ addString += ", "; }
				}
				else
				{
					count++;
				}
			}
			//add bracket at end of Add string
			addString += ")";

			command.CommandText = addString;
			try
			{ command.ExecuteNonQuery(); }
			catch (SqlException ex)
			{
				item.setValid(false);
				item.setErrorMessage(ex.Message);
			}
			connection.Close();
		}

		public void Delete(Item item)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@id", item.getID());
			command.CommandText = "DELETE FROM " + table +
				" WHERE " + idField + " = @id";
			try { command.ExecuteNonQuery(); }
			catch (SqlException ex)
			{
				item.setValid(false);
				item.setErrorMessage(ex.Message);
			}
			connection.Close();
		}

        public int GetMaxID()
        {
            connection.Open();
            command.Parameters.Clear();
            command.CommandText = "SELECT MAX (" + idField + ") FROM " + table;
            Reader = command.ExecuteReader();
            Reader.Read();
            int maxID = Int32.Parse(Reader.GetValue(0).ToString());
            Reader.Close();
            Connection.Close();
            return maxID + 1;
        }
	}
}
