﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _db;
        public CompanyService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Company entity)
        {
            _db.Companies.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Company> GetAll()
        {
            IEnumerable<Company> query = _db.Companies;
            return query;
        }

        public Company GetFirstOrDefault(Expression<Func<Company, bool>> filter)
        {
            IQueryable<Company> query = _db.Companies;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Company entity)
        {
            _db.Companies.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Company> entities)
        {
            _db.Companies.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
        }
    }
}
