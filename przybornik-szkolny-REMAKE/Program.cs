using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace przybornik_szkolny_REMAKE
{
    class Program
    {
        Student student;
        Toolbox toolbox;
        static void Main(string[] args)
        {
            //Tworzenie egzemplarza programu i rozpoczęcie konfiguracji
            Program program = new Program();
            if (!program.Prepare()) return;

            bool running = true;
            while(running)
            {
                program.toolbox.DrawMenu();
                running = program.toolbox.HandleMenuInput();
            }
        }

        bool Prepare()
        {
            Console.Write("Wstępna konfiguracja programu. Wciśnij dowolny klawisz...");
            Console.ReadKey();

            student = new Student();
            if (!student.Prepare()) return false;
            toolbox = new Toolbox(student);

            return true;
        }
    }
}
