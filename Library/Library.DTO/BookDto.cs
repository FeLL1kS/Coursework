using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class BookDto
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Залоговая стоимость
        /// </summary>
        public double CollateralValue { get; set; }
        /// <summary>
        /// Цена за день
        /// </summary>
        public double CostPerDay { get; set; }
        /// <summary>
        /// Ссылка на автора
        /// </summary>
        public AuthorDto Author { get; set; }
    }
}
