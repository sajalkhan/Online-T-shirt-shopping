using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class city:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public  bool Insert()
        {
            Command=CommandBuilder("insert into City(name,countryId) values (@name,@countryId)");
            Command.Parameters.AddWithValue("name",Name);
            Command.Parameters.AddWithValue("countryId", CountryId);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update City set name = @name,countryId = @countryId where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("countryId", CountryId);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from City where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name,countryId from City where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                CountryId = (Int32)Reader["countryId"];
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            Command = CommandBuilder("select city.id, city.name, country.name as country from City left join Country on city.CountryId = Country.id");
            if (CountryId > 0)
            {
                Command.CommandText += " where country.id=@CountryId";
                Command.Parameters.AddWithValue("@CountryId", CountryId);
            }
            return ExecuteDS(Command);
        }

        private DataSet ExecuteDS(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public bool Table()
        {

            Command = CommandBuilder(@"create table City(Id int identity Primary key,
                                     Name varchar(200) unique not null,
                                     countryId int not null,
                                     foreign key(countryId) references Country(Id))");

            Command.Parameters.AddWithValue("name", Name);
            return ExecuteNQ(Command);
        }
    }
}
