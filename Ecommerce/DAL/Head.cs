using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Head:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; }

        public bool Insert()
        {
            Command=CommandBuilder("insert into Head(name,description,headId) values (@name,@description,@headId)");
            Command.Parameters.AddWithValue("name",Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("headId", HeadId);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update Head set name = @name,description=@description,headId = @headId where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("headId", HeadId);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from Head where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name,description,headId from Head where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                HeadId = (Int32)Reader["headId"];
                Description = Reader["descripion"].ToString();
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select(string ExtraSQl="")
        {
            return ExecuteDS(@"select h1.id,h1.name,h1.description,h2.name as head
                                from Head as h1
                                left join Head h2 on h1.headid=h2.id "+ ExtraSQl);
        }

        public bool Table()
        {

            Command = CommandBuilder(@"  create table Head(Id int identity Primary key,
                                         Name varchar(200) unique not null,
                                         description varchar(500),
                                         headId int,
                                         foreign key(headId) references Head(Id))");

            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("headId", HeadId);
            return ExecuteNQ(Command);
        }
    }
}
