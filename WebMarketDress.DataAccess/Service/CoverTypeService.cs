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
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeService(ApplicationDbContext db)
        {
           _db = db;
        }

        public void Add(CoverType entity)
        {
            _db.CoverTypes.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<CoverType> GetAll()
        {
            IEnumerable<CoverType> query = _db.CoverTypes;
            return query;
        }

        public CoverType GetFirstOrDefualt(Expression<Func<CoverType, bool>> filter)
        {
           IQueryable<CoverType> query = _db.CoverTypes;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(CoverType entity)
        {
           _db.CoverTypes.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<CoverType> entities)
        {
            _db.CoverTypes.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
            _db.SaveChanges();
        }
    }
}
