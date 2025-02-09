using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Application.DTOs
{
    internal class ApartmentDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int Level { get; set; }
        public int NumberOfRooms { get; set; }
        public double Size { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public bool IsFurnished { get; set; }

        public List<RoomDTO> Rooms { get; set; }
        public List<AssetDTO> Assets { get; set; }
        public List<ApartmentImageDTO> ApartmentImages { get; set; }
    }
}
