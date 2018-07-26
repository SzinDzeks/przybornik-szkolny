using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Menu
    {
        public List<string> menuContent {
            get; private set;
        }

        public Menu(List<string> menuContent) => this.menuContent = menuContent;
        public Menu(string menuContent)
        {
            this.menuContent = new List<string>();
            this.menuContent.Add(menuContent);
        }

        public void Draw()
        {
            Console.Clear();
            foreach (string line in menuContent)
                Console.WriteLine(line);
        }
    }
}
