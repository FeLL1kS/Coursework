using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DTO;

namespace Library.BusinessLayer
{
    public interface IDiscountsProcess
    {
        /// <summary>
        /// Возвращает список скидок
        /// </summary>
        /// <returns>Список скидок</returns>
        IList<DiscountsDto> GetList();

        /// <summary>
        /// Возвращает скидку по ID
        /// </summary>
        /// <param name="id">ID скидки</param>
        /// <returns>Скидка</returns>
        DiscountsDto Get(int id);

        /// <summary>
        /// Добавляет скидку
        /// </summary>
        /// <param name="discount">Скидка</param>
        void Add(DiscountsDto discount);

        /// <summary>
        /// Обновляет данные об скидке
        /// </summary>
        /// <param name="discount">Скидка, которую нужно изменить</param>
        void Update(DiscountsDto discount);

        /// <summary>
        /// Удаляет скидку
        /// </summary>
        /// <param name="id">ID скидки</param>
        void Delete(int id);
    }
}
