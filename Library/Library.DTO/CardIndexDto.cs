using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class CardIndexDto
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalPrice { get; set; }
        public BookDto Book { get; set; }
        public FinesDto Fine { get; set; }
        public ReaderDto Reader { get; set; }
    }
}
