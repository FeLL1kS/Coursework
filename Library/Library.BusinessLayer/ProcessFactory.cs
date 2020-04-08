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

        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }
    }
}
