using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class CardIndexDto
    {
        /// <summary>
        /// ИД в картотеке
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime DateOfIssue { get; set; }
        /// <summary>
        /// Дата возврата
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// Полная цена
        /// </summary>
        public double? TotalPrice { get; set; }
        /// <summary>
        /// Ссылка на книгу
        /// </summary>
        public BookDto Book { get; set; }
        /// <summary>
        /// Ссылка на штраф
        /// </summary>
        public FinesDto Fine { get; set; }
        /// <summary>
        /// Ссылка на покупателя
        /// </summary>
        public ReaderDto Reader { get; set; }
    }
}
