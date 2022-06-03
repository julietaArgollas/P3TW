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

        public ListProduct CreateListProduct(ListProduct product)
        {
            _context.Set<ListProduct>().Add(product);
            return product;
        }

        public ListProduct GetById(Guid id)
        {
            return _context.Set<ListProduct>().Find(id);
        }

        public ListProduct UpdateListProduct(ListProduct product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return product;
        }

        public ListProduct DeleteListProduct(ListProduct product)
        {
            _context.Set<ListProduct>().Remove(product);
            return product;
        }
    }
}
