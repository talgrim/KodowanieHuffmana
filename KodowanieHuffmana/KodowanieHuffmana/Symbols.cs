using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
