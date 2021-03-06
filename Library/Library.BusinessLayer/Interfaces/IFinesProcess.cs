﻿using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer.Interfaces
{
    public interface IFinesProcess
    {
        /// <summary>
        /// Возвращает список штрафов
        /// </summary>
        /// <returns>Список штрафов</returns>
        IList<FinesDto> GetList();

        /// <summary>
        /// Возвращает штраф по ID
        /// </summary>
        /// <param name="id">ID штрафа</param>
        /// <returns>Штраф</returns>
        FinesDto Get(int id);

        /// <summary>
        /// Добавляет штраф
        /// </summary>
        /// <param name="fines">Штраф</param>
        void Add(FinesDto fines);

        /// <summary>
        /// Обновляет данные об скидке
        /// </summary>
        /// <param name="fines">Штраф, который нужно изменить</param>
        void Update(FinesDto fines);

        /// <summary>
        /// Удаляет вид штрафа
        /// </summary>
        /// <param name="id">ID штрафа</param>
        void Delete(int id);

        /// <summary>
        /// Поиск по штрафам
        /// </summary>
        /// <param name="PriceFrom">Начальная цена</param>
        /// <param name="PriceTo">Конечная цена</param>
        /// <returns>Список штрафов</returns>
        IList<FinesDto> SearchFines(string PriceFrom, string PriceTo);
    }
}
