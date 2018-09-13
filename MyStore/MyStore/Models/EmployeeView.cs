using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class EmployeeView
    {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string SurName { get; set; }
            public string Patronymic { get; set; }
            public int Age { get; set; }
        public DateTime Bithday { get; set; }
        public DateTime WorkDate { get; set; }
        public int TelNumber { get; set; }
        public string Adress { get; set; }
        public string Position { get; set; }

    }
}
