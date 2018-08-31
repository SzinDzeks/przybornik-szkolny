using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Data
    {
        public static List<string> gradesWithPlusAndMinus = new List<string>()
        { "1", "1+", "2-", "2", "2+", "3-", "3","3+","4-","4","4+","5-","5","5+","6-","6" };
        public static List<string> stepTwoMenu { get; private set; } = new List<string>()
        {
            "Krok 2: Sporządzenie listy przedmitotów. ",
            "Wypisz wszystkie swoje przedmioty szkolne, zatwierdzając każdy Enter'em.",
            "Aby usunąć ostatnio dodany przedmiot wpisz COFNIJ i zatwierdź Enter'em",
            "Gdy skończysz napisz KONIEC i zatwierdź Enter'em.",
            ""
        };
        public static List<string> stepThreeMenu { get; private set; } = new List<string>()
        {
            "Krok 3: Wybranie typu ocen",
            "",
            "W niektórych placówkach oceny są zapisywane tylko całościowo,",
            "w innych są zapisywane z plusami i minusami.",
            "Powiedz nam jak jest u ciebie.",
            "Wybierz jedną z opcji:",
            "",
            "1. Oceny tylko całościowe",
            "2. Oceny całościowe oraz z plusami i minusami",
            "",
            "Wybór: "
        };
        public static List<string> stepFourMenu { get; private set; } = new List<string>()
        {
            "Krok 4: Czy plusy i minusy są brane pod uwagę przy obliczaniu średnich?",
            "Wybierz jedną z opcji:",
            "",
            "1. Tak",
            "2. Nie",
            "",
            "Wybór: "
        };
    }
}
