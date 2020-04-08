using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface IFinesDao
    {
        /// <summary>
        /// Возвращает список штрафов
        /// </summary>
        /// <returns>Список штрафов</returns>
        IList<Fines> GetList();

        /// <summary>
        /// Возвращает штраф по ID
        /// </summary>
        /// <param name="id">ID штрафа</param>
        /// <returns>Штраф</returns>
        Fines Get(int id);

        /// <summary>
        /// Добавляет штраф
        /// </summary>
        /// <param name="fines">Штраф</param>
        void Add(Fines fines);

        /// <summary>
        /// Обновляет данные об скидке
        /// </summary>
        /// <param name="fines">Штраф, который нужно изменить</param>
        void Update(Fines fines);

        /// <summary>
        /// Удаляет вид штрафа
        /// </summary>
        /// <param name="id">ID штрафа</param>
        void Delete(int id);
    }
}
