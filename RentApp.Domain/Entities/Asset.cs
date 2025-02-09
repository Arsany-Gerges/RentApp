using System;
using RentApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Domain.Entities
{
    public class Asset
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool AvailableOrNot { get; set; }


        //foreign key
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }
    }
}
