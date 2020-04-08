using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer.Interfaces
{
    public interface ICardIndexProcess
    {
        /// <summary>
        /// Возвращает список из картотеки
        /// </summary>
        /// <returns>Список из картотеки</returns>
        IList<CardIndexDto> GetList();

        /// <summary>
        /// Возвращает запись из картотеки по ID
        /// </summary>
        /// <param name="id">ID скидки</param>
        /// <returns>Запись</returns>
        CardIndexDto Get(int id);

        /// <summary>
        /// Добавляет запись в картотеку
        /// </summary>
        /// <param name="cardIndex">Запись</param>
        void Add(CardIndexDto cardIndex);

        /// <summary>
        /// Обновляет данные записи в картотеке
        /// </summary>
        /// <param name="cardIndex">Запись, которую нужно изменить</param>
        void Update(CardIndexDto cardIndex);

        /// <summary>
        /// Удаляет запись из картотеки
        /// </summary>
        /// <param name="id">ID записи</param>
        void Delete(int id);
    }
}
