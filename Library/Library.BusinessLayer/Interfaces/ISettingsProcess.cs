﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer.Interfaces
{
    public interface ISettingsProcess
    {
        string GetSettings();
        bool SetSettings(string server, string db, string user, string password);
    }
}
