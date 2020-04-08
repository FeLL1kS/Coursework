using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class ReaderDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SeconName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DiscountsDto Discount { get; set; }
    }
}
