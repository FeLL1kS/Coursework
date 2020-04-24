using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DTO;

namespace Library.BusinessLayer.Interfaces
{
    public interface IBookProcess
    {
        /// <summary>
        /// Возвращает список книг
        /// </summary>
        /// <returns>Список книг</returns>
        IList<BookDto> GetList();

        /// <summary>
        /// Возвращает книгу по ID
        /// </summary>
        /// <param name="id">ID книги</param>
        /// <returns>Книга</returns>
        BookDto Get(int id);

        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="book">Книга</param>
        void Add(BookDto book);

        /// <summary>
        /// Обновляет данные об книге
        /// </summary>
        /// <param name="book">Книга, которую нужно изменить</param>
        void Update(BookDto book);

        /// <summary>
        /// Удаляет книгу
        /// </summary>
        /// <param name="id">ID книги</param>
        void Delete(int id);

        /// <summary>
        /// Поиск книг
        /// </summary>
        /// <param name="Title">Название книги</param>
        /// <param name="Genre">Жанр книги</param>
        /// <param name="AuthorID">Идентификатор автора</param>
        /// <returns>Список книг</returns>
        IList<BookDto> SearchBooks(string Title, string Genre, string AuthorID);
    }
}
