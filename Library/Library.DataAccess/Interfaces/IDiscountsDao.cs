using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface IDiscountsDao
    {
        /// <summary>
        /// Возвращает список скидок
        /// </summary>
        /// <returns>Список скидок</returns>
        IList<Discounts> GetList();

        /// <summary>
        /// Возвращает скидку по ID
        /// </summary>
        /// <param name="id">ID скидки</param>
        /// <returns>Скидка</returns>
        Discounts Get(int id);

        /// <summary>
        /// Добавляет скидку
        /// </summary>
        /// <param name="discount">Скидка</param>
        void Add(Discounts discount);

        /// <summary>
        /// Обновляет данные об скидке
        /// </summary>
        /// <param name="discount">Скидка, которую нужно изменить</param>
        void Update(Discounts discount);

        /// <summary>
        /// Удаляет вид скидки
        /// </summary>
        /// <param name="id">ID скидки</param>
        void Delete(int id);
    }
}
