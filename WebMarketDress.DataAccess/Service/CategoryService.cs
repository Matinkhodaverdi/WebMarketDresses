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
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
           _db = db;
        }

        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _db.Categories;
            return query;
        }

        public Category GetFirstOrDefualt(Expression<Func<Category, bool>> filter)
        {
           IQueryable<Category> query = _db.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Category entity)
        {
           _db.Categories.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.Categories.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
