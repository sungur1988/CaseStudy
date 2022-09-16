using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : EfBaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(AppDbContext context):base(context)
        {

        }
    }
}
