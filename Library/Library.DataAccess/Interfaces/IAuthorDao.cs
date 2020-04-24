using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    /// <summary>
    /// Декларация действий о работе с объектом автора в базе
    /// </summary>
    public interface IAuthorDao
    {

        /// <summary>
        /// Возвращает список авторов
        /// </summary>
        /// <returns>список авторов</returns>
        IList<Author> GetList();

        /// <summary>
        /// Возвращает автора по ID
        /// </summary>
        /// <param name="id">ID автора</param>
        /// <returns>Автор</returns>
        Author Get(int id);

        /// <summary>
        /// Добавляет автора
        /// </summary>
        /// <param name="author">Автор</param>
        void Add(Author author);

        /// <summary>
        /// Обновляет данные об авторе
        /// </summary>
        /// <param name="author">Автор, которого нужно изменить</param>
        void Update(Author author);

        /// <summary>
        /// Удаляет автора
        /// </summary>
        /// <param name="id">ID автора</param>
        void Delete(int id);

        /// <summary>
        /// Ищет авторов по имени
        /// </summary>
        /// <param name="Name">ФИО автора</param>
        /// <returns>Список авторов</returns>
        IList<Author> SearchAuthors(string Name);
    }
}
