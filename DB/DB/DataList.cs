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
		//declaring the class level variables that will be used througout 
		private SqlConnection connection;
		private SqlDataReader reader;
		private List<Item> list;
		private DataTable dataTable;
		private SqlCommand command;
		private string table;
		private string idField;

		//creating getters and setters for the command, table, idfield and dataTable.
		//protected because only sub-classes will access them
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
		protected SqlConnection Connection
		{
			get { return connection; }
			set { connection = value; }
		}
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
		//dataList constructor that takes two parameters (table name and primary key field name) 
		//Inside, the sql connection and the reader are created
		public DataList(string table, string idField)
		{
			list = new List<Item>();
			this.table = table;
			this.idField = idField;

			//connection =
			//new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=College;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

			// abdulla connection string, dont delete just comment
			connection =
				  new SqlConnection("Data Source=(localdb)\\LocalDB;Initial Catalog=College;Integrated Security=True");

			// Madan connection please don't remove only comment it 
			//connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=College;Integrated Security=True");
			// connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=College;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			command = connection.CreateCommand();
			dataTable = new DataTable();
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

		// Start of Madan's Methods

		/* 
		 * Name: GetMaxID 
		 * Parameters: none
		 * Return: int
		 * Descreption: this method gets the max of the id field and converts it to int and returns it
		 * purpose: to be used when creating new itmes in the database such as instructor and student Because
		 * the primary key field in the Course table is not autoincrement type, the application needs to provide
		 * a new unique ID value when new rows are added.
		 */
		public int GetMaxID()
		{
			connection.Open(); // open DataBase connection
			command.CommandText = "Select Max(" + idField + ") from " + table; // set the sql query
			reader = command.ExecuteReader(); // excute the query and assign it to reader
			reader.Read(); // read the first line
			int maxId = Convert.ToInt32(reader.GetValue(0)); // convert the first value in the first line to int and assign it to maxId var
			connection.Close(); // close connection
			reader.Close(); // close reader 
			return maxId; // return the value of maxId var

		}

		/* 
		 * Name: Exist 
		 * Parameters: string column1, string value1, string column2, string value2, string column, string value
		 * Return: boolean
		 * Descreption: this method do a count with the required conditions and if the count result = 0 then 
		 * returns false and if = 1 or more then return ture
		 * purpose: to be used to determine if a Location is already scheduled for a particular day and time
		 */
		public bool Exist(string column1, string value1, string column2, string value2, string column, string value)
		{
			connection.Open(); // open connection
			command.Parameters.Clear(); // clear parameters
			command.Parameters.AddWithValue("@value1", value1); // add parameter with  value to be used in the query
			command.Parameters.AddWithValue("@value2", value2);// add parameter with  value to be used in the query
			command.Parameters.AddWithValue("@value", value);// add parameter with  value to be used in the query
			command.CommandText = "Select Count( * ) FROM " + table +
				" WHERE " + column1 + " = @value1" +
				" And " + column2 + " = @value2" +
				" And " + column + " = @value"; // set the sql query 
			reader = command.ExecuteReader(); // excute the query and assign it to reader
			reader.Read(); // read the first line
			int count = Convert.ToInt32(reader.GetValue(0));// convert the first value in the first line to int and assign it to count var
			reader.Close(); // close reader 
			connection.Close();// close connection
							   /* if statment to check the value of the count */
			if (count == 0)
			{
				/* if the count = 0 return false */
				return false;
			}
			else
			{
				/* slse return true */

				return true;
			}
		}

		/* 
		 * Name: TotalValue 
		 * Parameters: string sumColumn, string column, string value
		 * Return: int
		 * Descreption: calculates the total of a column where another column is equal to a value
		 * purpose: to be used to calculate the total scheduled hours for a Section or a Location
		 */
		public int TotalValue(string sumColumn, string column, string value)
		{
			int sum = 0; // create new var called sum 
			connection.Open(); // open connetion
			command.Parameters.Clear(); // clear previous parameters
			command.Parameters.AddWithValue("@value", value);// add parameter with  value to be used in the query
			command.CommandText = "Select Sum(" + sumColumn + ") FROM " + table + " Where " + column + " = @value"; // set the sql query 
			reader = command.ExecuteReader(); // excute the query and assign it to reader
			reader.Read();// read the first line

			/* this if statment is to chack if the value is null then return 0 because if the value is null then it cannot be converted  to int then 
			 * an exceprtion is going to be raisd and the application will be closed 
			 * this is a way around
			 */

			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				/* if the value is null then set the sum as 0*/
				sum = 0;
			}
			else
			{
				/* else  convert the first value in the first line to int and assign it to sum var */
				sum = Convert.ToInt32(reader.GetValue(0));
				
			}

			reader.Close(); // close reader
			connection.Close(); // close connection
			return sum; // return sum
		}

		/* 
		* Name: AverageValue 
		* Parameters: string column1, string value1, string column2, string value2, string column, string value
		* Return: double
		* Descreption: A method  calculates the average of a column where a column in a related table is equal 
		* to a value, and the related table needs to be joined via another related table. Overloaded version of
		* previous AverageValue method 
		* purpose: Needed to calculate the average grade for a Course
		*/
		public double AverageValue(string avgColumn, string table1, string key1, string key2,
			string table2, string key3, string key4, string column, string value)
		{
			double avg = 0;// create new var called sum 
			connection.Open();// open connetion
			command.Parameters.Clear();// clear previous parameters
			command.Parameters.AddWithValue("@value", value); // add parameter with  value to be used in the query
			command.CommandText =
				"Select AVG(CAST([" + avgColumn + "] as float)) from " + table +
				" inner join " + table1 + " on " + key1 + " = " + key2 +
				" inner join " + table2 + " on " + key3 + " = " + key4 +
				" where " + column + " = @value";// set the sql query 
			reader = command.ExecuteReader();// excute the query and assign it to reader
			reader.Read();// read the first line

			/* this if statment is to chack if the value is null then return 0 because if the value is null then it cannot be converted  to double and then 
			 * an exceprtion is going to be raisd and the application will be closed 
			 * this is a way around
			 */

			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				/* if the value is null then set the avg as 0.0*/

				avg = 0.0;
			}
			else
			{
				/* else  convert the first value in the first line to double and assign it to avg var */

				avg = Convert.ToDouble(reader.GetValue(0));
			}
			reader.Close();// close reader
			connection.Close();// close connection
			return avg; // return the value of avg
		}

		/* 
		 * 
		 *  !!!!!!!!!!!!!!!! important please read carfully  !!!!!!!!!!!!!!!!!!!
		 *  !!!!!!!!!!!!!!!! This method is the same as the one above it but it does the work with less paramerters. !!!!!!!!!!!!!!!!!
		 *  
		 *  
		 * Name: AverageValue 
		 * Parameters: string avgColumn, string table1, string key1, string key2, string table2, string column, string value
		 * Return: double
		 * Descreption: This Method is the same as the above method but this method uses another approach so this method uses less parameters but 
		 *				in the same time it dose the same work
		 * purpose: Needed to calculate the average grade for a Course
		 */
		public double AverageValue(string avgColumn, string table1, string key1, string key2,
		   string table2, string column, string value)
		{
			double avg = 0;// create new var called sum 
			connection.Open();// open connetion
			command.Parameters.Clear();// clear previous parameters
			command.Parameters.AddWithValue("@value", value); // add parameter with  value to be used in the query
			command.CommandText =
			   "Select AVG(CAST([" + avgColumn + "] as float)) from " + table +
				" inner join " + table1 + " on " + table + "." + key1 + " = " + table1 + "." + key1 +
				" inner join " + table2 + " on " + table1 + "." + key2 + " = " + table2 + "." + key2 +
				" where " + column + " = @value";// set the sql query 
			reader = command.ExecuteReader();// excute the query and assign it to reader
			reader.Read();// read the first line

			/* this if statment is to chack if the value is null then return 0 because if the value is null then it cannot be converted  to double and then 
			 * an exceprtion is going to be raisd and the application will be closed 
			 * this is a way around
			 */

			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				/* if the value is null then set the avg as 0.0*/

				avg = 0.0;
			}
			else
			{
				/* else  convert the first value in the first line to double and assign it to avg var */

				avg = Convert.ToDouble(reader.GetValue(0));
			}
			reader.Close();// close reader
			connection.Close();// close connection
			return avg;// return the value of avg
		}
		// End of Madan's Methods

		//Abdulla's methods 
		/*
         *this total value method with one parameter -column name- will 
         * be needed to calculate the total of all scheduled hours or any values in the passed
         * column.
        */
		public int TotalValue(string columnName)
		{
			//declaring a variable sum to store the value
			int sum;
			//opening the connection and clearing paramters of the command
			connection.Open();
			command.Parameters.Clear();
			/*
             * setting the command text to the SQL statment using the paramertes as 
             * column nameand the table variable which is a class variable.
            */
			command.CommandText = "Select sum(" + columnName + ") from " + table;
			//exectuing the query and storing the results in the reader
			reader = command.ExecuteReader();
			//because one result will return from the execution, we need to put it in the buffer
			reader.Read();
			/*
             *The below if statment will be usedd to check if there were any values were in 
             * the column specified or if they are a valid values. if not, the sum will be 
             * returned as zero or the actual value will be stored in sum variable. 
             */
			if (reader.GetValue(0) == null)
			{
				sum = 0;
			}
			else
			{
				//converting the value from string to an int to be stored and returned.
				sum = Convert.ToInt32(reader.GetValue(0));
			}
			//closing the reader and connection after finishing the execution
			reader.Close();
			connection.Close();
			//returning the varibale.
			return sum;
		}

		/*
         * totalValue with nine parameters ranging from column and table names, keys to be 
         * used in the inner join and the value specified for the statment.
         * This method is Needed to calculate the total scheduled hours for a 
         * Course or a Student and also can be used to to check if a student have 
         * more than 20 schedules hours.
         */
		public int TotalValue(string sumColumn, string table1, string key1, string key2,
			string table2, string key3, string key4, string column, string value)
		{
			//declaring a varibale to store the returned data
			int sum;
			//opening the connection and clearing parameters
			connection.Open();
			command.Parameters.Clear();
			//adding the value as a paramrter with value to avoid SQL injection attacks
			command.Parameters.AddWithValue("@value", value);
			//storing the SQL statment in the command text using all paramrters to structure it.
			command.CommandText =
				"Select sum(" + sumColumn + ") from " + table +
				" inner join " + table1 + " on " + key1 + " = " + key2 +
				" inner join " + table2 + " on " + key3 + " = " + key4 +
				" where " + column + " = @value";
			//executing the command and storing the results in the reader
			reader = command.ExecuteReader();
			//because one result will return from the execution, we need to put it in the buffer
			reader.Read();
			/*
             *The below if statment will be usedd to check if there were any values were in 
             * the column specified or if they are a valid values. if not, the sum will be 
             * returned as zero or the actual value will be stored in sum variable. 
             */
			if (reader.GetValue(0) == null)
			{
				sum = 0;
			}
			else
			{
				//converting the value from string to an int to be stored and returned.
				sum = Convert.ToInt32(reader.GetValue(0));
			}
			//closing the reader and connection after finishing the execution
			reader.Close();
			connection.Close();
			//returning the variable to the caller method
			return sum;
		}
		//This method does the same exact thing as the previous total value except with less parameters.
		public int TotalValue(string sumColumn, string table1, string key1, string key2,
		 string table2, string column, string value)
		{
			//declaring a varibale to store the returned data
			int sum;
			//opening the connection and clearing parameters
			connection.Open();
			command.Parameters.Clear();
			//adding the value as a paramrter with value to avoid SQL injection attacks
			command.Parameters.AddWithValue("@value", value);
			//storing the SQL statment in the command text using all paramrters to structure it.
			command.CommandText =
				"Select sum(" + sumColumn + ") from " + table +
				" inner join " + table1 + " on " + table + "." + key1 + " = " + table1 + "." + key1 +
				" inner join " + table2 + " on " + table1 + "." + key2 + " = " + table2 + "." + key2 +
				" where " + column + " = @value";
			//executing the command and storing the results in the reader
			reader = command.ExecuteReader();
			//because one result will return from the execution, we need to put it in the buffer
			reader.Read();
			/*
             *The below if statment will be usedd to check if there were any values were in 
             * the column specified or if they are a valid values. if not, the sum will be 
             * returned as zero or the actual value will be stored in sum variable. 
             */
			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				sum = 0;
			}
			else
			{
				//converting the value from string to an int to be stored and returned.
				sum = Convert.ToInt32(reader.GetValue(0));
			}
			//closing the reader and connection after finishing the execution
			reader.Close();
			connection.Close();
			//returning the variable to the caller method
			return sum;
		}
		/*
         * This delete have two parameters which are column name and the value. This method 
         * is Needed for deleting a Student.  Deleteing a recored with related data in
         * other tables will throw an exception. First the related records 
         * in the SectionStudent table will need to be deleted using this method. 
         * Then the Student can be deleted
         */
		public void Delete(string column, string value)
		{
			//opening the connection and clearing parameters
			connection.Open();
			command.Parameters.Clear();
			//adding the value as a paramrter with value to avoid SQL injection attacks
			command.Parameters.AddWithValue("@value", value);
			//storing the SQL statment in the command text using all paramrters to structure it as well as the table class variable.
			command.CommandText = "Delete from " + table + " where " + column + " = @value";
			//Executing the command against the database
			command.ExecuteNonQuery();
			//closing the connection to the database after the command is executed.
			connection.Close();
		}

		/*
         * averageValue method has three parameters which are the column take the average of
         * and the condition column as well as the value of it. This method will be used 
         * to calculate the average grade for a Section or Student
         */
		public double AverageValue(string avgColumn, string column, string value)
		{
			//declaring a varibale to store the returned data
			double avg;
			//opening the connection and clearing parameters
			connection.Open();
			command.Parameters.Clear();
			//adding the value as a paramrter with value to avoid SQL injection attacks
			command.Parameters.AddWithValue("@value", value);
			/*storing the SQL statment in the command text using all paramrters to 
             * structure it as well as the table class variable. The cast in the sql statment 
             * is used to apply the average function on the columns that are declared as
             * nvarchar but store only numbers, this is why it must be casted as a float to 
             * avoid any exceptions from the databse.
             */
			command.CommandText = "select AVG(CAST([" + avgColumn + "] as float)) from " + table + " where " + column +
				" = @value";
			//because one result will return from the execution, we need to put it in the buffer
			reader = command.ExecuteReader();
			reader.Read();
			/*
             *The below if statment will be usedd to check if there were any values were in 
             * the column specified or if they are a valid values. if not, the sum will be 
             * returned as zero or the actual value will be stored in sum variable. 
             */
			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				avg = 0;
			}
			else
			{
				//converting the value from string to an double to be stored and returned.
				avg = Convert.ToDouble(reader.GetValue(0));
			}
			//closing the connection to the database after the command is executed.
			reader.Close();
			connection.Close();
			//returning the variable to the caller method.
			return avg;
		}
		//end of abdulla

		//Moosa's Methods
		//Average Value (1)
		public double AverageValue(string columnName)
		{
			connection.Open();
			command.Parameters.Clear();
			command.CommandText = "SELECT AVG(CAST([" + columnName + "] as float)) FROM " + table;
			reader = command.ExecuteReader();
			reader.Read();
			double avg;
			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				avg = 0;
			}
			else
			{
				avg = Convert.ToDouble(reader.GetValue(0));
			}
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
			command.CommandText = "DELETE " + table + " FROM " + table +
				" INNER JOIN " + table2 + " ON " + key1 + " = " + key2 +
				" WHERE " + column + " = @value";
			command.ExecuteNonQuery();
			connection.Close();
		}

		//Total Value (3)
		public double TotalValue(string sumColumn, string table1, string key1, string key2, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "SELECT SUM(" + sumColumn + ") FROM " + table +
				" INNER JOIN " + table1 + " ON " + key1 + " = " + key2 +
				" WHERE " + column + " = @value";
			reader = command.ExecuteReader();
			reader.Read();
			double sum;
			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				sum = 0;
			}
			else
			{
				sum = Convert.ToInt32(reader.GetValue(0));
			}
			reader.Close();
			connection.Close();
			return sum;
		}

		//Total Value (3) With 5 parameters instead of 6
		public double TotalValue(string sumColumn, string table1, string key1, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value", value);
			//command.CommandText = "SELECT SUM(" + sumColumn + ") FROM " + table +
			//    " INNER JOIN " + table1 + " ON " + key1 + " = " + key2 +
			//    " WHERE " + column + " = @value";
			command.CommandText = "SELECT SUM(" + sumColumn + ") FROM " + table +
				" INNER JOIN " + table1 + " ON " + table + "." + key1 + " = " + table1 + "." + key1 +
				" WHERE " + column + " = @value";
			reader = command.ExecuteReader();
			reader.Read();
			double sum;
			if (reader.GetValue(0) == null || reader.GetValue(0) is DBNull)
			{
				sum = 0;
			}
			else
			{
				sum = Convert.ToInt32(reader.GetValue(0));
			}
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
			command.CommandText = "SELECT COUNT(*) FROM " + table
				+ " INNER JOIN " + table1 + " ON " + key1 + " = " + key2 +
				" WHERE " + column1 + " = @value1 AND " + column2 + " = @value2 " +
				" AND " + column + " = @value";
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

		//Exist method that checks if a student is busy on a particular day and time to avoid double scheduling
		public bool Exist(string table1, string key1, string key2, string table2, string key3, string key4,
			string column1, string value1, string column2, string value2, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value1", value1);
			command.Parameters.AddWithValue("@value2", value2);
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "SELECT COUNT(" + idField + ") FROM " + table
				+ " INNER JOIN " + table1 + " ON " + key1 + " = " + key2 +
				" INNER JOIN " + table2 + " ON " + key3 + " = " + key4 +
				" WHERE " + column1 + " = @value1 AND " + column2 + " = @value2 " +
				" AND " + column + " = @value";
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
		//the below method is the same as the above but it uses less parameters and provide the same output
		public bool Exist(string table1, string key1, string key2, string table2,
			string column1, string value1, string column2, string value2, string column, string value)
		{
			connection.Open();
			command.Parameters.Clear();
			command.Parameters.AddWithValue("@value1", value1);
			command.Parameters.AddWithValue("@value2", value2);
			command.Parameters.AddWithValue("@value", value);
			command.CommandText = "SELECT COUNT(" + idField + ") FROM " + table
				+ " INNER JOIN " + table1 + " ON " + table + "." + key1 + " = " + table1 + "." + key1 +
				" INNER JOIN " + table2 + " ON " + table1 + "." + key2 + " = " + table2 + "." + key2 +
				" WHERE " + column1 + " = @value1 AND " + column2 + " = @value2 " +
				" AND " + column + " = @value";
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
