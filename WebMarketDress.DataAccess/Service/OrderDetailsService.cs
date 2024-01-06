using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service
{
    public class OrderDetailsService : IOrderDetailsService
	{
        private readonly ApplicationDbContext _db;

        public OrderDetailsService(ApplicationDbContext db)
        {
           _db = db;
        }

        public void Add(OrderDetails entity)
        {
            _db.OrderDetails.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IEnumerable<OrderDetails> query = _db.OrderDetails;
            return query;
        }

        public OrderDetails GetFirstOrDefualt(Expression<Func<OrderDetails, bool>> filter)
        {
           IQueryable<OrderDetails> query = _db.OrderDetails;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(OrderDetails entity)
        {
           _db.OrderDetails.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderDetails> entities)
        {
            _db.OrderDetails.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(OrderDetails orderDetails)
        {
            _db.OrderDetails.Update(orderDetails);
            _db.SaveChanges();
        }
    }
}
