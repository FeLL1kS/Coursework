using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DTO;

namespace Library.BusinessLayer.Interfaces
{
    /// <summary>
    /// Декларация действий о работе с автором
    /// </summary>
    public interface IAuthorProcess
    {
        /// <summary>
        /// Возвращает список авторов
        /// </summary>
        /// <returns>список авторов</returns>
        IList<AuthorDto> GetList();

        /// <summary>
        /// Возвращает автора по ID
        /// </summary>
        /// <param name="id">ID автора</param>
        /// <returns>Автор</returns>
        AuthorDto Get(int id);

        /// <summary>
        /// Добавляет автора
        /// </summary>
        /// <param name="author">Автор</param>
        void Add(AuthorDto author);

        /// <summary>
        /// Обновляет данные об авторе
        /// </summary>
        /// <param name="author">Автор, которого нужно изменить</param>
        void Update(AuthorDto author);

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
        IList<AuthorDto> SearchAuthors(string Name);
    }
}
