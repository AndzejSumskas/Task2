using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Person
    {
        [StringLength(20)]
        private string name { get; set; }
        [StringLength(20)]
        private string surName { get; set; }
        [MaxLength(6)]
        private int telephonNumber { get; set; }

        public Person(string name, string surName, int telephonNumber)
        {
            this.name = name;
            this.surName = surName;
            this.telephonNumber = telephonNumber;
        }
    }
}
