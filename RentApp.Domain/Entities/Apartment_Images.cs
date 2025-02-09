using System;
using System.Collections.Generic;
using System.Linq;
using RentApp.Domain.Entities;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Domain.Entities
{
    public class Apartment_Images
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public bool IsKeyImage { get; set; }

        //Foreign Key
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }
    }
}
