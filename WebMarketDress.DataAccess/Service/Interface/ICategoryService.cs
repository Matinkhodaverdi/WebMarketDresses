using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface ICategoryService
    {
        public void Add(Category entity);
        public IEnumerable<Category> GetAll();
        public Category GetFirstOrDefualt(Expression<Func<Category, bool>> filter);
        public void Remove(Category entity);
        public void RemoveRange(IEnumerable<Category> entities);
        public void Update(Category category);

    }
}
