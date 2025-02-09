using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Application.DTOs
{
    internal class ApartmentImageDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsKeyImage { get; set; }
    }
}
