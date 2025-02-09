using RentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Domain.Entities
{
    public class Room
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }

        // Foreign Key
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }

        // Relationships
        public List<Room_Images> RoomImages { get; set; }
    }
}
