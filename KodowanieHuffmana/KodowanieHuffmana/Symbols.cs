using System.Collections.Generic;
using System.Linq;

namespace KodowanieHuffmana
{
    class Symbols
    {
        public List<Symbol> List { get; private set; }

        public Symbols()
        {
            List = new List<Symbol>();
        }

        public void Add(char znak)
        {
            List.Add(new Symbol(znak));
        }

        public void Add(char znak, int wystapienia)
        {
            List.Add(new Symbol(znak,wystapienia));
        }

        public void AddPresence(char znak)
        {
            int index = List.FindIndex(x => x.symbol == znak);
            List[index].presence++;
        }

        public bool Contains(char znak)
        {
            return List.Contains(new Symbol(znak));
        }

        public void SortAscending()
        {
            List = List.OrderBy(o => o.presence).ToList();
        }

        public void SortDescending()
        {
            List = List.OrderByDescending(o => o.presence).ToList();
        }

        public Dictionary<char, int> ToDictionary()
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (Symbol symbol in List)
                dictionary.Add(symbol.symbol, symbol.presence);
            return dictionary;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Symbol symbol in List)
                result += symbol.ToString();
            return result;
        }
    }
}
