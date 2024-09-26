using MikhunaMovilXF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikhunaMovilXF.AUTH
{
    class Auth
    {
        public static Usuarios user = null;

        public static String username;
        public static String email;
        public static String password;

        public static void setAuth(Usuarios u) {
            user = u;
            username = u.NickName;
            email = u.Correo;
            password = u.Clave;
        }

        public static Usuarios getAuth() {
            return user;
        }

        public static string getUsername(String us)
        {
            return username;
        }

        public static string getEmail(String us)
        {
            return email;
        }

        public static string getPassword(String us)
        {
            return password;
        }
    }
}
