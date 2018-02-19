using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    sealed class ProductPrice : MyBase,IdataBase
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }   

        public bool Insert()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("insert into ProductPrice (productId,unitId,Price) values(@ProductId,@UnitId,@Price)");
            Command.Parameters.AddWithValue("@ProductId", ProductId);
            Command.Parameters.AddWithValue("@UnitId", UnitId);
            Command.Parameters.AddWithValue("@Price", Price);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("update ProductPrice set Price=@Price where productId=@ProductId");
            Command.Parameters.AddWithValue("@Price", Price);
            Command.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("delete from ProductPrice where productId=@ProductId");
            Command.Parameters.AddWithValue("@ProductId",ProductId);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("select productId,unitId,Price from ProductPrice where productId=@ProductId");
            Command.Parameters.AddWithValue("@ProductId", ProductId);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Price = Convert.ToDouble(Reader["Price"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select pp.productId, pp.unitId, p.name as product, u.name as unit, pp.price
                                from ProductPrice as pp
                                left join product as p on pp.productId = p.id
                                left join unit as u on pp.unitId = u.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table ProductPrice(productId int not null,
                                        unitId int not null,Price float,
                                        foreign key (productId) references Product(Id),
                                        foreign key (unitId) references Unit(Id),
                                        primary key (productId,UnitId))");
            return ExecuteNQ(Command);
        }
    }
}
