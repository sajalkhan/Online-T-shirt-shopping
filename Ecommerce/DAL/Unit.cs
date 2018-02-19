using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    sealed class Unit:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PrimaryQty { get; set; }

        public bool Insert()
        {
            Command=CommandBuilder("insert into unit(name,description,primaryQty) values (@name,@description,@primaryQty)");
            Command.Parameters.AddWithValue("@name",Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryQty", PrimaryQty);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update unit set name = @name,description=@description,productQty = @productQty where id = @id");
            Command.Parameters.AddWithValue("@id",Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryQty", PrimaryQty);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from unit where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name,description,primaryQty from unit where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                PrimaryQty = (double)Reader["categoryId"];
                Description = Reader["descripion"].ToString();
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS(@"select id, name, description, primaryQty from unit");
        }

        public bool Table()
        {
            Command = CommandBuilder(@"  create table Unit
                                         (Id int identity Primary key,
                                         Name varchar(200),
                                         Description varchar(500),
                                         primaryQty float)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("primaryQty", PrimaryQty);
            return ExecuteNQ(Command);
        }
    }
}
