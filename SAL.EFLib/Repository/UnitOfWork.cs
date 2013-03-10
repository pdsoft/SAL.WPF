using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAL.EFLib.Repository
{
    public class UnitOfWork : IDisposable
    {
        private SALEntities _context = SALContext.Instance.Context;//new SALEntities();

        private Repository<Customer> _customerRepository;
        private Repository<Equipment> _equipmentRepository;
        private Repository<EquipmentType> _equipmentTypeRepository;
        private Repository<Location> _locationRepository;
        private Repository<Site> _siteRepository;

        public Repository<Customer> CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    this._customerRepository = new Repository<Customer>(_context);
                }
                return _customerRepository;
            }
        }

        public Repository<Equipment> EquipmentRepository
        {
            get
            {
                if (this._equipmentRepository == null)
                {
                    this._equipmentRepository = new Repository<Equipment>(_context);
                }
                return _equipmentRepository;
            }
        }

        public Repository<EquipmentType> EquipmentTypeRepository
        {
            get
            {
                if (this._equipmentTypeRepository == null)
                {
                    this._equipmentTypeRepository = new Repository<EquipmentType>(_context);
                }
                return _equipmentTypeRepository;
            }
        }

        public Repository<Location> LocationRepository
        {
            get
            {
                if (this._locationRepository == null)
                {
                    this._locationRepository = new Repository<Location>(_context);
                }
                return _locationRepository;
            }
        }

        public Repository<Site> SiteRepository
        {
            get
            {
                if (this._siteRepository == null)
                {
                    this._siteRepository = new Repository<Site>(_context);
                }
                return _siteRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public static void Reload(object obj)
        {
            SALContext.Instance.Context.Entry(obj).Reload();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
