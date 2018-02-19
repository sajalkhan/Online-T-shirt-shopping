using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Brand:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public  bool Insert()
        {

            Command=CommandBuilder( "insert into Brand(name,description) values (@name,@description)");
            Command.Parameters.AddWithValue("name",Name);
            Command.Parameters.AddWithValue("description", Description);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update Brand set name = @name,description=@description where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
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

            Command= CommandBuilder("select id,name,description from Brand where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS( "select id,name,description from Brand");
        }

        public bool Table()
        {

            Command = CommandBuilder(@" create table Brand(
                                        Id int identity primary key,
                                        Name varchar(20) unique,
                                        Description varchar(50))");

            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("Description", Description);
            return ExecuteNQ(Command);
        }
    }
}
