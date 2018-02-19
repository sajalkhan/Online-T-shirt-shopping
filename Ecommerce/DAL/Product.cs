using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Product:MyBase,IdataBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Offers { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public double Discount { get; set; }


        public bool Insert()
        {
            Command=CommandBuilder(@"insert into product(name,description,tag,code,type,categoryId,brandId,offers,discount)
                                               values(@name,@description,@tag,@code,@type,@categoryId,@brandId,@offers,@discount)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@categoryId", CategoryId);
            Command.Parameters.AddWithValue("@brandId", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command= CommandBuilder(@"update product set name = @name,description=@description,tag=@tag,
                                    code=@code,type=@type,categoryId=@categoryId,brandId=@barndId,offers=@offers,
                                    discount=@discount
                                    where id = @id");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@categoryId", CategoryId);
            Command.Parameters.AddWithValue("@brandId", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from product where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder(@"select id,name,description,tag,code,type,categoryId,brandId,offers,discount
                                    from product where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                Tag = Reader["tag"].ToString();
                Code = (String)Reader["code"];
                Type = (String)Reader["type"];
                CategoryId = (Int32)Reader["categoryId"];
                BrandId = (Int32)Reader["brandId"];
                Offers = Reader["offers"].ToString();
                Discount = (float)Reader["discount"];
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS(@"select p.id, p.name,p.description,p.tag,p.code,p.type,c.name as category,b.name as brand,p.offers,p.discount 
                                from product as p
                                left join Category as c on p.CategoryId=c.id
                                left join Brand as b on p.BrandId=b.id");
        }

        public bool Table()
        {

            Command = CommandBuilder(@" create table Product
                                        (Id int identity Primary key,
                                        Name varchar(200),
                                        Description varchar(2000),
                                        Tag varchar(200),
                                        Code varchar(200) unique,
                                        Type varchar(5),
                                        categoryId int not null,
                                        brandId int not null,
                                        Offers varchar(2000),
                                        Discount float,
                                        foreign key (categoryId) references Category(Id),
                                        foreign key (brandId) references Brand(Id))");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@categoryId", CategoryId);
            Command.Parameters.AddWithValue("@brandId", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(Command);
        }
    }
}
