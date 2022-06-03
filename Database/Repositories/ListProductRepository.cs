using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ListProductRepository
    {
        private PracticeDbContext _context;

        public ListProductRepository(PracticeDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListProduct>> GetAll()
        {
            return await _context.Set<ListProduct>().ToListAsync();
        }

        public ListProduct CreateProduct(ListProduct product)
        {
            _context.Set<ListProduct>().Add(product);
            return product;
        }

        public ListProduct GetById(Guid id)
        {
            return _context.Set<ListProduct>().Find(id);
        }

        public ListProduct UpdateProduct(ListProduct product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return product;
        }

        public ListProduct DeleteProduct(ListProduct product)
        {
            _context.Set<ListProduct>().Remove(product);
            return product;
        }
    }
}
