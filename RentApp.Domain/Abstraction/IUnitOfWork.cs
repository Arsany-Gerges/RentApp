using RentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Domain.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Apartment> Apartments { get; }
        IBaseRepository<Room> Rooms { get; }
        IBaseRepository<Asset> Assets { get; }

        int Complete();

    }
}
