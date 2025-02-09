using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentApp.Domain.Entities;
using System.Threading.Tasks;

namespace RentApp.Domain.Entities
{
    public class Room_Images
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public bool IsKeyImage { get; set; }

        // Foreign Key
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
