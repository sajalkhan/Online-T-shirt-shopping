using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Ledger:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public int EmployeeId { get; set; }


        public bool Insert()
        {
            Command=CommandBuilder(@"insert into Ledger(name,contact,contactPerson,email,password,headId,description,address,cityId,createDate,employeeId)
                                                 values(@name,@contact,@contactPerson,@email,@password,@headId,@description,@address,@cityId,@createDate,@employeeId)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", Contact);
            Command.Parameters.AddWithValue("@contactPerson", ContactPerson);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@cityId", CityId);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder(@"update Ledger set name = @name,contact=@contact,contactPerson=@contactPerson,
                                    email=@email,password=@password,headId=@headId,description=@description,
                                    address=@address,cityId=@cityId,createDate=@createDate,employeeId=@employeeId 
                                    where id = @id");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", Contact);
            Command.Parameters.AddWithValue("@contactPerson", ContactPerson);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@cityId", CityId);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);

            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from Ledger where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder(@"select id,name,contact,contactPerson,email,password,headId,description,
                                    address,cityId,createDate,employeeId from Ledger where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Contact = Reader["contact"].ToString();
                ContactPerson = Reader["contactPerson"].ToString();
                Email = Reader["email"].ToString();
                Password = Reader["password"].ToString();
                HeadId = (Int32)Reader["headId"];
                Description = Reader["description"].ToString();
                Address = Reader["address"].ToString();
                CityId = (Int32)Reader["cityId"];
                CreateDate = (DateTime)Reader["creatDate"];
                EmployeeId = (Int32)Reader["employeeId"];
                return true;
            }
            Reader.Close();
            return false;
        }


        public bool Login()
        {
            if (!Connection()) return false;

            Command = CommandBuilder(@"select id,name,contact,contactPerson,email,password,headId,description,
                                    address,cityId,createDate,employeeId from Ledger where (email=@email or contact=@email) and password=@password");
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Id = (Int32)Reader["id"];
                Name = Reader["name"].ToString();
                Contact = Reader["contact"].ToString();
                ContactPerson = Reader["contactPerson"].ToString();
                Email = Reader["email"].ToString();
                Password = Reader["password"].ToString();
                HeadId = (Int32)Reader["headId"];
                Description = Reader["description"].ToString();
                Address = Reader["address"].ToString();
                CityId = (Int32)Reader["cityId"];
                CreateDate = (DateTime)Reader["creatDate"];
                EmployeeId = (Int32)Reader["employeeId"];
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS(@"select l.id, l.name, l.contact, l.ContactPerson, l.email, l.password, l.description, l.address,l.createdate,
                                h.name as head,l2.EmployeeID as employee,c.name as city,cn.name as country
                                from ledger as l
                                left join Head h on l.HeadId=h.id
                                left join City c on l.CityId=c.id
                                left join Ledger l2 on l.EmployeeID=l2.id
                                left join Country cn on c.CountryId=cn.id");
        }

        public bool Table()
        {

            Command = CommandBuilder(@" create table Ledger(Id int identity primary key ,
                                        Name varchar(200) not null unique,
                                        Contact varchar(200),
                                        contactPerson varchar(200) default 'NA',
                                        Email varchar(200) not null unique,
                                        Password varchar(200) not null,
                                        headId int,
                                        description varchar(500),
                                        Address varchar(500),
                                        cityId int,
                                        createDate datetime default getdate(),
                                        employeeId int,
                                        foreign key (headId) references head(Id),
                                        foreign key (cityId) references City(Id),
                                        foreign key (employeeId) references Ledger(Id) )");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@Contact", Contact);
            Command.Parameters.AddWithValue("@contactPerson", ContactPerson);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@cityId", CityId);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);

            return ExecuteNQ(Command);
        }
    }
}
