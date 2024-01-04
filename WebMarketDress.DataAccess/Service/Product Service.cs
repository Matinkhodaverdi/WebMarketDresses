using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;
using WebMarketDress.Models.ProductVM;

namespace WebMarketDress.DataAccess.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(ProductVM entity)
        {
            _db.Products.Add(entity.Product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(C => C.Category).Include(C => C.CoverType);
            return query;
        }

        public Product GetFirstOrDefualt(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var ObjProduct = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (ObjProduct != null)
            {
                ObjProduct.Name = obj.Name;
                ObjProduct.Material = obj.Material;
                ObjProduct.Color = obj.Color;
                ObjProduct.Size = obj.Size;
                ObjProduct.Description = obj.Description;
                ObjProduct.Price = obj.Price;
                ObjProduct.Price50 = obj.Price50;
                ObjProduct.Price100 = obj.Price100;
                if (ObjProduct.ImgUrl != null)
                {
                    ObjProduct.ImgUrl = obj.ImgUrl;

                }
                ObjProduct.CategoryId = obj.CategoryId;
                ObjProduct.CoverTypeId = obj.CoverTypeId;
            }

            _db.SaveChanges();
        }
    }
}
