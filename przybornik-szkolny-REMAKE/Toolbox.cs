using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Toolbox
    {
        Student student;
        public Toolbox(Student student) => this.student = student;

        public void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("School tool - menu:");
            Console.WriteLine("");
            Console.WriteLine("1. Wyświetl oceny");
            Console.WriteLine("2. Dodaj ocene");
            Console.WriteLine("3. Popraw ocene");
            Console.WriteLine("4. Wykonaj kopie zapasową");
            Console.WriteLine("5. Ustawienia");
            Console.WriteLine("6. Wyjście z programu");
            Console.WriteLine("");
            Console.Write("Wybór: ");
        }

        public void TemporaryUnavaible()
        {
            Console.Clear();
            Console.WriteLine("Ta funkcja jest tymczasowo niedostępna.");
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }
}
