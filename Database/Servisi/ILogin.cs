﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Servisi
{
    public interface ILogin
    {
        // Prijava korisnika sa odredjenim kreditijalima
        bool LogIn(string username, string password);
    }
}
