﻿using Library.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    /// <summary>
    /// Фабрика классов бизнес-логики
    /// </summary>
    public class ProcessFactory
    {
        /// <summary>
        /// Возвращает объект реализующий <seealso cref="IAuthorProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IAuthorProcess GetAuthorProcess()
        {
            return new AuthorProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий <seealso cref="IBookProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IBookProcess GetBookProcess()
        {
            return new BookProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий IDiscountProcess
        /// </summary>
        /// <returns></returns>
        public static IDiscountsProcess GetDiscountProcess()
        {
            return new DiscountsProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий IReaderProcess
        /// </summary>
        /// <returns></returns>

        public static IReaderProcess GetReaderProcess()
        {
            return new ReaderProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий IFinesProcess
        /// </summary>
        /// <returns></returns>

        public static IFinesProcess GetFinesProcess()
        {
            return new FinesProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий ICardIndexProcess
        /// </summary>
        /// <returns></returns>

        public static ICardIndexProcess GetCardIndexProcess()
        {
            return new CardIndexProcessDb();
        }

        /// <summary>
        /// Возвращает объект реализующий ISettingsProcess
        /// </summary>
        /// <returns></returns>

        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }

        /// <summary>
        /// Возвращает объект реализующий IReportGenerator
        /// </summary>
        /// <returns></returns>
        public static IReportGenerator GetReportGenerator()
        {
            return new ReportGenerator();
        }

        /// <summary>
        /// Возвращает объект реализующий IReportItemProcess
        /// </summary>
        /// <returns></returns>
        public static IReportItemProcess GetReportProcess()
        {
            return new ReportItemProcess();
        }
    }
}
