using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DTO
{
    public class FinesDto
    {
        /// <summary>
        /// ИД штрафа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Описание штрафа
        /// </summary>
        public string FineDescription { get; set; }
        /// <summary>
        /// Цена штрафа
        /// </summary>
        public double FinePrice { get; set; }
    }
}
