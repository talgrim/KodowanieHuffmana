using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodowanieHuffmana
{
    public class Symbol : IEquatable<Symbol>, IComparable<Symbol>
    {
        public char symbol;
        public int presence;
        [DisplayName("Symbol")]
        public string Znak => symbol.ToString();
        [DisplayName("Liczba wystąpień")]
        public string Wystapienia => presence.ToString();
        public Symbol(char znak)
        {
            symbol = znak;
            presence = 1;
        }

        public bool Equals(Symbol other)
        {
            return this.symbol == other.symbol;
        }

        public int GetHashCode(Symbol obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Symbol other)
        {
            return presence.CompareTo(other.presence);
        }
    }
}
