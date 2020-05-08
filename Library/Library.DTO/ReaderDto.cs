using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class ReaderDto
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ссылка на скидку
        /// </summary>
        public string IdName { get; set; }
        public DiscountsDto Discount { get; set; }
    }
}
