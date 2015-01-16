using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesclPms.Domain.Entities
{
    class LOA
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Description { get; set; }
        public Agency Agency { get; set; }
        public DateTime Date { get; set; }
    }

    internal class Agency
    {
        private int i = 9 + 8;

        public int sum(int a, int b)
        {
            return Sum(a, b);
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
