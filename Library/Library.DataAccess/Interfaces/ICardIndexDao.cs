using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface ICardIndexDao
    {
        /// <summary>
        /// Возвращает список из картотеки
        /// </summary>
        /// <returns>Список из картотеки</returns>
        IList<CardIndex> GetList();

        /// <summary>
        /// Возвращает запись из картотеки по ID
        /// </summary>
        /// <param name="id">ID скидки</param>
        /// <returns>Запись</returns>
        CardIndex Get(int id);

        /// <summary>
        /// Добавляет запись в картотеку
        /// </summary>
        /// <param name="cardIndex">Запись</param>
        void Add(CardIndex cardIndex);

        /// <summary>
        /// Обновляет данные записи в картотеке
        /// </summary>
        /// <param name="cardIndex">Запись, которую нужно изменить</param>
        void Update(CardIndex cardIndex);

        /// <summary>
        /// Удаляет запись из картотеки
        /// </summary>
        /// <param name="id">ID записи</param>
        void Delete(int id);

        /// <summary>
        /// Поиск в картотеке
        /// </summary>
        /// <param name="ReturnDateFrom">Начальная дата для поиска по дате возврата</param>
        /// <param name="ReturnDateTo">Конечная дата для поиска по дате возврата</param>
        /// <param name="DateOfIssueFrom">Начальная дата для поиска по дате выдачи</param>
        /// <param name="DateOfIssueTo">Конечная дата для поиска по дате выдачи</param>
        /// <param name="TotalPrice">Стоимость</param>
        /// <param name="ReaderCode">Читатель</param>
        /// <param name="BookCode">Книга</param>
        /// <param name="FineCode">Штраф</param>
        /// <returns>Список читателей</returns>
        IList<CardIndex> SearchCardIndices(string ReturnDateFrom, string ReturnDateTo, string DateOfIssueFrom, string DateOfIssueTo, string TotalPrice, string ReaderCode, string BookCode, string FineCode);
    }
}
