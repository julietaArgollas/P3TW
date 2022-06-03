using System;
using Database.Repositories;

namespace Database
{
    public class UnitOfWork
    {
        private PracticeDbContext _context;

        private UserRepository _userRepository;
        private ProductRepository _productRepository;
        private ListProductRepository _listProductRepository;


        public ProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }
        public ListProductRepository ListProductRepository
        {
            get
            {
                return _listProductRepository;
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                return _userRepository;
            }
        }

        public UnitOfWork(PracticeDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
            _productRepository = new ProductRepository(_context);
            _listProductRepository = new ListProductRepository(_context);
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw;
            }
        }
    }
}
