using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UnitOfWork:IDisposable
    {
        private MakeupApiContext context = new MakeupApiContext();
        private GenericRepository<Product> productRepository;
        private GenericRepository<Perfume> perfumeRepository;
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Category> categoryRepository;


        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<Perfume> PerfumeRepository
        {
            get
            {
                if (this.perfumeRepository == null)
                {
                    this.perfumeRepository = new GenericRepository<Perfume>(context);
                }
                return perfumeRepository;
            }
        }

        public GenericRepository<Brand> BrandRepository
        {
            get
            {
                if (this.brandRepository == null)
                {
                    this.brandRepository = new GenericRepository<Brand>(context);
                }
                return brandRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            { 
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
