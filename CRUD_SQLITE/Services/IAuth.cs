using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SQLITE.Services
{
    interface IAuth
    {
        bool Login(string email, string password);
        bool Register(string name, string email, string password);
    }
}
