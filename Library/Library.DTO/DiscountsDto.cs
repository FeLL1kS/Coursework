using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class DiscountsDto
    {
        public int Id { get; set; }
        public string DiscountDescription { get; set; }
        public int DiscountPercent { get; set; }
    }
}
