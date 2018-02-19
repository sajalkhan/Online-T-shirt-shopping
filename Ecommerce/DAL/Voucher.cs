using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    sealed class Voucher:MyBase,IdataBase
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AutoNumber { get; set; }
        public int CurrentNumber { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public int Length { get; set; }
        public bool AutoPrint { get; set; }

        public bool Insert()
        {
            Command=CommandBuilder(@"insert into Voucher(name,description,autonumber,currentNumber,prefix,postfix,length,autoprint)
                                                 values (@name,@description,@autonumber,@currentNumber,@prefix,@postfix,@length,@autoprint)");

            Command.Parameters.AddWithValue("name",Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("autonumber", AutoNumber);
            Command.Parameters.AddWithValue("currentNumber", CurrentNumber);
            Command.Parameters.AddWithValue("prefix", Prefix);
            Command.Parameters.AddWithValue("postfix", Postfix);
            Command.Parameters.AddWithValue("length", Length);
            Command.Parameters.AddWithValue("autoprint", AutoPrint);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder("update Voucher set name = @name,description=@description,autonumber=@autonumber,currentNumber=@currentNumber where id = @id");
            Command.Parameters.AddWithValue("id",Id);
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("autonumber", AutoNumber);
            Command.Parameters.AddWithValue("currentNumber", CurrentNumber);

            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from Voucher where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,name,description,autonumber,currentNumber from Voucher where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                AutoNumber = (bool)Reader["autonumber"];
                CurrentNumber = (int)Reader["currentNumber"];
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS("select id,name,description,autonumber,currentNumber from Voucher");
        }

        public bool Table()
        {

            Command = CommandBuilder(@" create table Voucher(
                                        Id int identity Primary key,
                                        Name varchar(200),
                                        Descreiption varchar(500),
                                        autoNumber int,
                                        preFix varchar(5),
                                        currentNumber bit,
                                        postFix varchar (5),
                                        Lenght int,
                                        autoPrint bit)");

            Command.Parameters.AddWithValue("Name", Name);
            Command.Parameters.AddWithValue("Description", Description);
            Command.Parameters.AddWithValue("autoNumber", AutoNumber);
            Command.Parameters.AddWithValue("currentNumber", CurrentNumber);
            Command.Parameters.AddWithValue("preFix", Prefix);
            Command.Parameters.AddWithValue("postFix", Postfix);
            Command.Parameters.AddWithValue("Length", Length);
            Command.Parameters.AddWithValue("autoPrint", AutoPrint);

            return ExecuteNQ(Command);
        }
    }
}
