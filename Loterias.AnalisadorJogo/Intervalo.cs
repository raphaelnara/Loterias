using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterias.AnalisadorJogo
{
    public class Intervalo : IEquatable<Intervalo>, IComparable<Intervalo>, IComparable
    {
        protected IList<int> numeros = new List<int>();

        public string Id => string.Join(",", numeros);
        public int Quantidade => numeros.Count;
        public IEnumerable<int> Numeros => numeros;

        public void Add(int n)
        {
            if (numeros.Contains(n)) return;
            numeros.Add(n);
        }

        public int CompareTo(Intervalo other)
        {
            if (Quantidade < other.Quantidade) return -1;
            if (Quantidade > other.Quantidade) return 1;
            return 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var seq = obj as Intervalo;
            if (seq == null) return 1;
            return CompareTo(seq);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var seq = obj as Intervalo;
            if (seq == null) return false;
            return Equals(seq);
        }

        public bool Equals(Intervalo other)
        {
            if (Quantidade != other.Quantidade) return false;
            int i = 0;
            foreach (var nOther in other.Numeros)
            {
                if (nOther != numeros[i]) return false;
                i++;
            }
            return true;
        }

    }

}
