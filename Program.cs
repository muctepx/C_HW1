using Sem1.Model;
using Sem1.Service;
using System.Reflection;
using System.Xml.Linq;

namespace Sem1
{
    internal class Program
    {
        private static FamilyMember familyMember;
        static void Main(string[] args)
        {
            FamilyMember fm7 = new FamilyMember()
            { Name = "Олег", Surname = "Петров", Birthday = new DateTime(1960, 12, 25), Gender = Gender.Male };//дедушка
            FamilyMember fm8 = new FamilyMember()
            { Name = "Кристина", Surname = "Петрова", Birthday = new DateTime(1962, 12, 25), Gender = Gender.Female };//бабушка
            fm7.Spouse = fm8;
            fm8.Spouse = fm7;

            FamilyMember fm5 = new FamilyMember()
            { Name = "Александр", Surname = "Иванов", Birthday = new DateTime(1966, 12, 25), Gender = Gender.Male };//дедушка
            FamilyMember fm6 = new FamilyMember()
            { Name = "Юлия", Surname = "Иванов", Birthday = new DateTime(1965, 12, 25), Gender = Gender.Female };//бабушка
            fm5.Spouse = fm6;
            fm6.Spouse = fm5;


            FamilyMember fm1 = new FamilyMember()
            {Name = "Иван", Surname = "Иванов", Birthday = new DateTime(1989, 12, 25), Gender=Gender.Male, Mother = fm6, Father = fm5 };//отец
            FamilyMember fm2 = new FamilyMember()
            { Name = "Мария", Surname = "Иванов", Birthday = new DateTime(1992, 12, 25), Gender = Gender.Female, Mother = fm8, Father = fm7 };//мать
            fm1.Spouse = fm2;
            fm2.Spouse = fm1;


            FamilyMember fm3 = new FamilyMember()
            { Name = "Ольга", Surname = "Иванова", Birthday = new DateTime(2020, 12, 25), Gender = Gender.Female , Mother=fm2, Father=fm1};//дочь
            FamilyMember fm4 = new FamilyMember()
            { Name = "Сергей", Surname = "Иванов", Birthday = new DateTime(2021, 12, 25), Gender = Gender.Male, Mother = fm2, Father = fm1 };//сын
        

            var service = new FamilyMemberService();
            service.AddMember(fm1, fm2, fm3, fm4, fm5, fm6, fm7, fm8);

            foreach (var memeber in service.GetGrandFathers(fm3))
            {
                Console.Write(memeber);
            }
            Console.WriteLine("--");
            foreach (var memeber in service.GetGrandMothers(fm4))
            {
                Console.Write(memeber);
            }
            Console.WriteLine("--");
            Console.WriteLine(service.FindOldestMember());

            Console.WriteLine("--");
            Console.WriteLine($"мужем для {fm8.Name} {fm8.Surname} является \n {service.FindCouple(fm8)}");



        }
    }
}
