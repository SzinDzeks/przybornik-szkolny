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
        Menu menu;
        public ConfigHandler confighandler
        {
            get; private set;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            bool running = true;
            while(running)
            {
                program.menu.Draw();
                running = program.toolbox.HandleMenuInput();
            }
        }

        Program()
        {
            Console.Write("Wstępna konfiguracja programu. Wciśnij dowolny klawisz...");
            Console.ReadKey();

            student = new Student();
            toolbox = new Toolbox(student);
            confighandler = new ConfigHandler(student);
            menu = new Menu(ConstructMenu());
        }

        List<string> ConstructMenu()
        { 
            return new List<string> {
                "School tool- menu",
                "",
                "1. Wyświetl oceny",
                "2. Dodaj ocenę",
                "3. Popraw ocenę",
                "4. Ustawienia",
                "5. Wyjście z programu",
                ""
            };
        }
    }
}
