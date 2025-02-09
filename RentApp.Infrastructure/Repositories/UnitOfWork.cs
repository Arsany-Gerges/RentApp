using RentApp.Domain.Abstraction;
using RentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentAppDbContext _context;
        public IBaseRepository<Apartment> Apartments { get; private set; }

        public IBaseRepository<Room> Rooms { get; private set; }

        public IBaseRepository<Asset> Assets { get; private set; }
        public UnitOfWork(RentAppDbContext context)
        {
            _context = context;
            Apartments = new BaseRepository<Apartment>(_context);
            Rooms = new BaseRepository<Room>(_context);
            Assets = new BaseRepository<Asset>(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
