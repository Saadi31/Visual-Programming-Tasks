using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assg
{
    class Sibling
    {
        public DateTime DOB 
        { 
            get;
            set; 
        }

        public Sibling(DateTime dateOfBirth)
        {
            this.DOB = dateOfBirth;
        }

    }
}
