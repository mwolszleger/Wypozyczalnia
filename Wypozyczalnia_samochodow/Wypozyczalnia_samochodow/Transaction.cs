using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    class Transaction
    {
        public Car car { get; private set; }
        //private Customer customer {get;private set};
        private DateTime begin;
        private DateTime end;
        //Employee employee1;
        //Employee employee2;
        public bool isFinished()
        {
            return end!=null;
        }

    }
}
