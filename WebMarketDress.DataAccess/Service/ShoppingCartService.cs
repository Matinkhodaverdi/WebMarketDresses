﻿using Microsoft.EntityFrameworkCore;
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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(ShoppingCart entity)
        {
            _db.ShoppingCarts.Add(entity);
            _db.SaveChanges();
        }



        public IEnumerable<ShoppingCart> GetAll(string? id)
        {
            IEnumerable<ShoppingCart> query = _db.ShoppingCarts
                .Where(x => x.ApplicationUserId == id)
                .Include(p => p.Product);
            return query;
        }

        public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter)
        {
            IQueryable<ShoppingCart> query = _db.ShoppingCarts;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }

        public void Remove(ShoppingCart entity)
        {
            _db.ShoppingCarts.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ShoppingCart> entities)
        {
            _db.ShoppingCarts.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(ShoppingCart entity)
        {
            _db.ShoppingCarts.Update(entity);
            _db.SaveChanges();
        }
    }
}
