using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class DiscountsDto
    {
        /// <summary>
        /// ИД скидки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Описание скидки
        /// </summary>
        public string DiscountDescription { get; set; }
        /// <summary>
        /// Процент скидки
        /// </summary>
        public int DiscountPercent { get; set; }
    }
}
