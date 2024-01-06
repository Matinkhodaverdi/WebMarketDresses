using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface IOrderHeaderService
	{
        public void Add(OrderHeader entity);
        public IEnumerable<OrderHeader> GetAll();
        public OrderHeader GetFirstOrDefualt(Expression<Func<OrderHeader, bool>> filter);
        public void Remove(OrderHeader entity);
        public void RemoveRange(IEnumerable<OrderHeader> entities);
        public void Update(OrderHeader orderHeader);
        void UpdateStatus(int id,string orderStatus, string? paymentStatus= null);

    }
}
