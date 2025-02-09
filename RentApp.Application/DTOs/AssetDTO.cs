using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Application.DTOs
{
    internal class AssetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }  // Renamed for clarity
    }
}
