using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductImage:MyBase,IdataBase
    {
       public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public DateTime Datetime { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
       
        public bool Insert()
        {

            Command=CommandBuilder("insert into productImage(productId, title, image, filename) values (@productId, @title, @image, @filename)");
            Command.Parameters.AddWithValue("@productId",ProductId);
            Command.Parameters.AddWithValue("@title", Title);
            Command.Parameters.AddWithValue("@image", Image);
            Command.Parameters.AddWithValue("@filename", FileName);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {

            Command= CommandBuilder("update productImage set productId = @productId, title=@title, image=@iamge, filename=@filename where id = @id");
            Command.Parameters.AddWithValue("@id",Id);
            Command.Parameters.AddWithValue("@productId",ProductId);
            Command.Parameters.AddWithValue("@image",Image);
            Command.Parameters.AddWithValue("@filename", FileName);
            return ExecuteNQ(Command);
        }


        public bool Delete()
        {
            Command = CommandBuilder("delete from productImage where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;

            Command= CommandBuilder("select id,productId, image from productImage where id = @id");
            Command.Parameters.AddWithValue("id", Id);

            Reader= Command.ExecuteReader();
            while(Reader.Read())
            {
                ProductId = (Int32)Reader["productId"];
                Image = (byte[])Reader["image"];
                return true;
            }
            Reader.Close();
            return false;
        }

        public DataSet Select()
        {
            return ExecuteDS( @"select pi.id, pi.title, pi.image, pi.datetime, p.name as product
                                from productImage as pi
                                left join product p on pi.productId=p.id");
        }

        public bool Table()
        {

            Command = CommandBuilder(@"create table productImage
                                      (Id int identity Primary key,
                                      productId  int unique not null,
                                      title varchar(200),
                                      image image,
                                      filename varchar(200),
                                      foreign key(productId) references product(ID) )");

            Command.Parameters.AddWithValue("@productId",ProductId);
            Command.Parameters.AddWithValue("@title", Title);
            Command.Parameters.AddWithValue("@image", Image);
            Command.Parameters.AddWithValue("@filename", FileName);
            return ExecuteNQ(Command);
        }
    }
}
