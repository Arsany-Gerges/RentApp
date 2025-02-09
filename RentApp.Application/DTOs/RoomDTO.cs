using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Application.DTOs
{
    internal class RoomDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }

        public List<RoomImageDTO> RoomImages { get; set; }
    }
}
