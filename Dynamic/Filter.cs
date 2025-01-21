using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public class Filter
    {
        public string Field { get; set; }
        public string? Value { get; set; }
        public string Operator { get; set; }// =,>,< vs.
        public string? Logic { get; set; }//and, or vs.

        public IEnumerable<Filter> Filters { get; set; } //iç içe filtreler oluşturmak için

        public Filter()
        {
            Field = string.Empty;
            Operator = string.Empty;
        }
        public Filter(string field, string @operator)
        {
            Field = field;
            Operator = @operator;
        }
    }
}
