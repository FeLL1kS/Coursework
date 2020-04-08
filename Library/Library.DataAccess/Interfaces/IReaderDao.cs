using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface IReaderDao
    {
        /// <summary>
        /// Возвращает список читателей
        /// </summary>
        /// <returns>Список читателей</returns>
        IList<Reader> GetList();

        /// <summary>
        /// Возвращает читателя по ID
        /// </summary>
        /// <param name="id">ID читателя</param>
        /// <returns>Читатель</returns>
        Reader Get(int id);

        /// <summary>
        /// Добавляет читателя
        /// </summary>
        /// <param name="reader">Читатель</param>
        void Add(Reader reader);

        /// <summary>
        /// Обновляет данные об читателе
        /// </summary>
        /// <param name="reader">Читатель, которого нужно изменить</param>
        void Update(Reader reader);

        /// <summary>
        /// Удаляет читателя
        /// </summary>
        /// <param name="id">ID читателя</param>
        void Delete(int id);
    }
}
