﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class StudentHelper
    {
        public static string GetStudentName()
        {
            Console.Write("Podaj swoje imie: ");
            string studentName = Console.ReadLine();
            return studentName;
        }
        
        public static string GetStudentSurname()
        {
            Console.Write("Podaj swoje nazwisko: ");
            string studentSurname = Console.ReadLine();
            return studentSurname;
        }
    }
}
