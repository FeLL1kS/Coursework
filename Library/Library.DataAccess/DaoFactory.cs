using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DataAccess
{
    public class DaoFactory
    {
        public static IAuthorDao GetAuthorDao()
        {
            return new AuthorDao();
        }

        public static IBookDao GetBookDao()
        {
            return new BookDao();
        }

        public static IDiscountsDao GetDiscountsDao()
        {
            return new DiscountsDao();
        }

        public static ISettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }
    }
}
