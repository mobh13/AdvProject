using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SqlClient;

namespace DB
{
	public class DataListJoin : DataList
	{
		private string idFieldJoin;
		public DataListJoin(string table, string idField, string idFieldJoin)
			: base(table, idField)
		{
			this.idFieldJoin = idFieldJoin;
		}

		public void Populate(ItemJoin item)
		{
			Connection.Open();
			Command.Parameters.Clear();
			Command.Parameters.AddWithValue("@id", item.getID());
			Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
			Command.CommandText = "SELECT * FROM " + Table + " WHERE " + IdField + " = @id" +
				" AND " + idFieldJoin + " = idJoin";
			Reader = Command.ExecuteReader();
			Reader.Read();
			SetValues(item);
			Reader.Close();
			Connection.Close();
		}

		public void Update(ItemJoin item)
		{
			Connection.Open();
			Command.Parameters.Clear();
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties)
			{
				if (property.GetValue(item) != null) //if the property value is not null
				{
					//if the current property is not the ID Field
					if (!property.Name.Equals(IdField, StringComparison.InvariantCultureIgnoreCase))
					{
						//use parameter for the user value - prevent SQL injection
						Command.Parameters.AddWithValue("@id", item.getID());
						Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
						Command.Parameters.AddWithValue("@value", property.GetValue(item));

						//generate SQL Update string for the current property name and value
						Command.CommandText = "UPDATE " + Table +
						   " SET " + property.Name + " = @value WHERE " + IdField + " =  @id" +
						   " AND " + idFieldJoin + " = @idJoin";
						Command.ExecuteNonQuery(); //execute command; update the database
						Command.Parameters.Clear(); //clear parameter for next iteration of loop
					}
				}
			}
			Connection.Close();
		}

		public void Delete(ItemJoin item)
		{
			Connection.Open();
			Command.Parameters.Clear();
			Command.Parameters.AddWithValue("@id", item.getID());
			Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
			Command.CommandText = "DELETE FROM " + Table + " WHERE " + IdField + " = @id" +
					" AND " + idFieldJoin + " = @idJoin";
			try { Command.ExecuteNonQuery(); }
			catch (SqlException ex)
			{
				item.setValid(false);
				item.setErrorMessage(ex.Message);
			}
			Connection.Close();
		}
	}
}
