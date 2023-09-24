using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionForMyEnumerator
{
    internal class Users
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0 && value <= 120)
                    _age = value;
                else
                    throw new ArgumentException("Age must be between 0 and 120.");
            }
        }
    }
}
