using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DataAccess.Entities
{
    public class CardIndex
    {
        public int IssuedBookID;
        public DateTime DateOfIssue;
        public DateTime? ReturnDate;
        public double? TotalPrice;
        public int BookCode;
        public int? FineCode;
        public int ReaderCode;
    }
}
