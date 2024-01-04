using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;
using WebMarketDress.Models.ProductVM;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface IProductService
    {
        public void Add(ProductVM entity);
        public IEnumerable<Product> GetAll();
        public Product GetFirstOrDefualt(Expression<Func<Product, bool>> filter);
        public void Remove(Product entity);
        public void RemoveRange(IEnumerable<Product> entities);
        public void Update(Product product);
    }

}
