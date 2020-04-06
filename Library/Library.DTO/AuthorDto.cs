using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    /// <summary>
    /// Класс - автор
    /// </summary>
    public class AuthorDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }
    }
}
