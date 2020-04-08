using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess
{
    public interface IBookDao
    {
        /// <summary>
        /// Возвращает список книг
        /// </summary>
        /// <returns>Список книг</returns>
        IList<Book> GetList();

        /// <summary>
        /// Возвращает книгу по ID
        /// </summary>
        /// <param name="id">ID книги</param>
        /// <returns>Книга</returns>
        Book Get(int id);

        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="book">Книга</param>
        void Add(Book book);

        /// <summary>
        /// Обновляет данные об книге
        /// </summary>
        /// <param name="book">Книга, которую нужно изменить</param>
        void Update(Book book);

        /// <summary>
        /// Удаляет книгу
        /// </summary>
        /// <param name="id">ID книги</param>
        void Delete(int id);
    }
}
