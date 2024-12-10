using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public class Paginate<T>
    {
        public Paginate()
        {
            Items = Array.Empty<T>();
        }
        public int Size { get; set; } //sayfada kaç data var
        public int Index { get; set; } //hangi sayfadayız
        public int Count { get; set; } //kaç kayıt var
        public int Pages { get; set; } //kaç sayfa var
        public IList<T> Items { get; set; } //data

        public bool HasPrevious => Index > 0;//Index 0 dan büyükse önceki sayfa da var anlamında
        public bool HasNext => Index + 1 < Pages; // sonraki sayfa var anlamında
    }
}
