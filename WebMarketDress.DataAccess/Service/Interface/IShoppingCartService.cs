﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.Models;

namespace WebMarketDress.DataAccess.Service.Interface
{
    public interface IShoppingCartService
    {
        public void Add(ShoppingCart entity);
        public IEnumerable<ShoppingCart> GetAll(string? id);
        public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter);
        public void Remove(ShoppingCart entity);
        public void RemoveRange(IEnumerable<ShoppingCart> entities);
        public void Update(ShoppingCart entity);

        int IncrementCount(ShoppingCart shoppingCart, int count);

        int DecrementCount(ShoppingCart shoppingCart, int count);
    }
}
