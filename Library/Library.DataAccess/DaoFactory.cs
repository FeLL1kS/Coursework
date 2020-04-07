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

        public static ISettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }
    }
}
