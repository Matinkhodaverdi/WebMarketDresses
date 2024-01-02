using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface ICoverTypeService
    {
        public void Add(CoverType entity);
        public IEnumerable<CoverType> GetAll();
        public CoverType GetFirstOrDefualt(Expression<Func<CoverType, bool>> filter);
        public void Remove(CoverType entity);
        public void RemoveRange(IEnumerable<CoverType> entities);
        public void Update(CoverType coverType);

    }
}
