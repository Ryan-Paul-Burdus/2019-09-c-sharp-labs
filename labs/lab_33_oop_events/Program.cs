using System;

namespace lab_33_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child();
            James.Name = "James";
            for (int i = 0; i < 10; i++)
            {
                James.Grow($"PartyType {i+1}");
            }
        }
    }

    class Child
    {
        public delegate int BirthdayDelegate(string typeOfParty); 
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }

        public Child()
        {
            this.Age = 0;
            Console.WriteLine("Congratulations!!!! Beautiful baby :) ");
            HaveABirthday += Celebrate;
        }

        int Celebrate(string typeOfParty)
        {
            this.Age++; //one year older
            Console.WriteLine($"Celebrating another birthday : Age is {this.Age} : {typeOfParty}");
            return Age;
        }

        public void Grow(string typeOfParty)
        {
            int AgeNow = HaveABirthday(typeOfParty);
        }
    }
}
