using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface IOrderDetailsService
	{
        public void Add(OrderDetails entity);
        public IEnumerable<OrderDetails> GetAll();
        public OrderDetails GetFirstOrDefualt(Expression<Func<OrderDetails, bool>> filter);
        public void Remove(OrderDetails entity);
        public void RemoveRange(IEnumerable<OrderDetails> entities);
        public void Update(OrderDetails orderDetails);

    }
}
