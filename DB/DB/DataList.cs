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
				new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=College;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

		//start of the design document Methods

		// Start of Madan Methods
		// get max id
		public int GetMaxID()
		{
			connection.Open();
			command.CommandText = "Select Max(" + idField + ") from " + table;
			reader = command.ExecuteReader();
			reader.Read();
			int maxId = Convert.ToInt32(reader.GetValue(0));
			connection.Close();
			reader.Close();
			return maxId;

		}
		//first exist
		public bool Exist(string column1, string value1, string column2, string value2, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value1", value1);
			command.Parameters.AddWithValue("@value2", value2);
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "Select Count(" + idField + ") FROM " + table +
				" WHERE " + column1 + " = @value1" +
				" And" + column2 + " = @value2" +
				" And" + column + " = @value";
			reader = command.ExecuteReader();
			reader.Read();
			int count = Convert.ToInt32(reader.GetValue(0));
			reader.Close();
			connection.Close();
			if (count == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		//second total value
		public int TotalValue(string sumColumn, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "Select Sum(" + sumColumn + ") FROM " + table + " Where " + column + " = @value";
			reader = command.ExecuteReader();
			reader.Read();
			int sum = Convert.ToInt32(reader.GetValue(0));
			reader.Close();
			connection.Close();
			return sum;
		}
		// third avreage value
		public double AverageValue(String sumColumn, string table1, string key1, string key2,
			string table2, string key3, string key4, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value", value);
			command.CommandText =
				"Select avg(" + sumColumn + ") from " + table +
				" inner join " + table1 + " on " + key1 + " = " + key2 +
				" inner join " + table2 + " on " + key3 + " = " + key4 +
				" where " + column + " = @value";
			reader = command.ExecuteReader();
			reader.Read();
			double avg = Convert.ToDouble(reader.GetValue(0));
			reader.Close();
			connection.Close();
			return avg;
		}
		// End of Madan Methods
		//Abdulla's methods 

		//first total value
		public int TotalValue(string columnName)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@column",columnName);
            command.CommandText = "Select sum(@column) from " + table ;
            reader = command.ExecuteReader();
            reader.Read();
            int sum = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            connection.Close();
            return sum;
        }

        //4th total value
        public int TotalValue(String sumColumn, string table1, string key1, string key2, 
            string table2, string key3, string key4, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@value",value);
            command.CommandText =
                "Select sum(" + sumColumn+") from " + table +
                " inner join "+ table1 +" on "+ key1 + " = "+key2 +
                " inner join "+table2 + " on "+key3 + " = "+ key4 +
                " where "+ column +" = @value";
            reader = command.ExecuteReader();
            reader.Read();
            int sum = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            connection.Close();
            return sum;
        }

        // first delete
        public void Delete(string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@column",column);
            command.Parameters.AddWithValue("@value", value);
            command.CommandText = "Delete from " + table + " where " + @column + " = @value";
            command.ExecuteNonQuery();
            connection.Close();
        }

        //second average 
        public double AverageValue(string sumColumn, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@column", column);
            command.Parameters.AddWithValue("@value", value);
            command.CommandText = "select avg(" + sumColumn + ") from " + table + " where " + @column +
                " = @value";
            reader = command.ExecuteReader();
            reader.Read();
            double sum = Convert.ToDouble(reader.GetValue(0));
            reader.Close();
            connection.Close();
            return sum;
        }

        //Moosa's Methods

        //Average Value (1)
        public double AverageValue(string columnName)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@column", columnName);
            command.CommandText = "SELECT AVG(@column) FROM " + table;
            reader = command.ExecuteReader();
            reader.Read();
            double avg = Convert.ToDouble(reader.GetValue(0));
            reader.Close();
            connection.Close();
            return avg;
        }

        //Delete (2)
        public void Delete(string table2, string key1, string key2, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@value", value);
            //table here could be section (maybe we call this method from the SectionList class) and column and value are the instructors
            command.CommandText = "DELETE FROM " + table + " WHERE " + key1 + " IN (SELECT " + key1 + " FROM " + table2 + " WHERE " 
                + column + " = " + value +")";
            command.ExecuteNonQuery();
            connection.Close();
        }

        //Total Value (3)
        public double TotalValue(string sumColumn, string table1, string key1, string key2, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@value", value);
            command.CommandText = "SELECT SUM(" + sumColumn + ") FROM " + table + " WHERE " + key1 + " IN ( SELECT " + key2 + 
                " FROM " + table1 + " WHERE " + column + " = @value";
            reader = command.ExecuteReader();
            reader.Read();
            double sum = Convert.ToDouble(reader.GetValue(0));
            reader.Close();
            connection.Close();
            return sum;
        }

        //Exist (2)
        public bool Exist(string table1, string key1, string key2, string column1, 
            string value1, string column2, string value2, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@value1", value1);
            command.Parameters.AddWithValue("@value2", value2);
            command.Parameters.AddWithValue("@value", value);
            command.CommandText = "SELECT COUNT(" + idField + ") FROM " + table +
                " WHERE " + key1 + " IN (" +
                "SELECT " + key1 + " FROM " + table1 + " WHERE " + key2 + " IN (SELECT " + key2 + " FROM " + table + " " +
                "WHERE " + column + " = @value)) AND " 
                + column1 + " = @value1 AND " + column2 + " = @value2";
            reader = command.ExecuteReader();
            reader.Read();
            int count = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            connection.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Exist (3)
        public bool Exist(string table1, string key1, string key2, string table2, string key3, string key4, 
            string column1, string value1, string column2, string value2, string column, string value)
        {
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@value1", value1);
            command.Parameters.AddWithValue("@value2", value2);
            command.Parameters.AddWithValue("@value", value);
            command.CommandText = "SELECT COUNT(" + idField + ") FROM " + table +
                " WHERE " + key1 + " IN (" +
                "SELECT " + key1 + " FROM " + table1 + " WHERE " + key2 + " IN (SELECT " + key2 +
                " FROM " + table2 + " WHERE " + key3 + " IN (SELECT " + key3 +
                " FROM " + table + " WHERE " + column + " = @value)) AND " +
                "" + column1 + " = @value1 AND " + column2 + " = @value2";
            reader = command.ExecuteReader();
            reader.Read();
            int count = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            connection.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
