using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.ViewModels
{
    class CarViewModels
    {
        
    }

    public class CarVM
    {
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        //public string Image { get; set; }
        public decimal Price { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public List<FNameGetViewModel> filters { get; set; }
    }
}
