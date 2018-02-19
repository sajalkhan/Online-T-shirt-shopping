using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Category:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public bool Insert()
        {
            Command=CommandBuilder("insert into Category(name,description,categoryId) values (@name,@description,@categoryId)");
            Command.Parameters.AddWithValue("name",Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("categoryId", CategoryId);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update Category set name = @name,description=@description,categoryId = @categoryId where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("categoryId", CategoryId);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from Category where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name,description,categoryId from Category where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                CategoryId = (Int32)Reader["categoryId"];
                Description = Reader["descripion"].ToString();
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select(string ExtraSQl="")
        {
            return ExecuteDS(@"select c1.id,c1.name,c1.description,c2.name as head
                                from Category as c1
                                left join Category c2 on c1.categoryid=c2.id " + ExtraSQl);
        }

        public bool Table()
        {
            Command = CommandBuilder(@"  create table Category(Id int identity Primary key,
                                         Name varchar(200) unique not null,
                                         description varchar(500),
                                         categoryId int,
                                         foreign key(categoryId) references Category(Id))");

            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("categoryId", CategoryId);
            return ExecuteNQ(Command);
        }
    }
}
