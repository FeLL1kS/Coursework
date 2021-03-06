﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DataAccess.Interfaces
{
    public interface ISettingsDao
    {
        string GetSettings();
        bool SetSettings(string server, string db, string user, string password);
    }
}
