using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public class Sort
    {
        public string Field { get; set; }//sıralama yapılacak alan
        public string Dir { get; set; }//asc or desc

        public Sort(string field, string dir)
        {
            Field = field;
            Dir = dir;
        }
        public Sort()
        {
            Field = string.Empty;
            Dir = string.Empty;
        }
    }
}
