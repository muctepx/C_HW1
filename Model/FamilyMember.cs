using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1.Model
{

    internal class FamilyMember
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DayOfDeath { get; set; }
        public FamilyMember Spouse { get; set; }

        public override string ToString()
        {
            return $"Имя {Name}\n Фамилия {Surname}\n Пол {Gender}\n ДР {Birthday.ToString()}\n";
        }
    }
}
