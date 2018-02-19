using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class country:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
       
        public bool Insert()
        {

            Command=CommandBuilder( "insert into Country(name) values (@name)");
            Command.Parameters.AddWithValue("name",Name);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {

            Command= CommandBuilder("update Country set name = @name where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            return ExecuteNQ(Command);
        }


        public bool Delete()
        {
            Command = CommandBuilder("delete from Country where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name from Country where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS( "select id,name from Country");
        }

        public bool Table()
        {

            Command = CommandBuilder("create table Country(Id int identity Primary key,Name varchar(200) unique not null)");
            Command.Parameters.AddWithValue("name", Name);
            return ExecuteNQ(Command);
        }
    }
}
