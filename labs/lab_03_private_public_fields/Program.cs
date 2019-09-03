using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person();
            person1.name = "Fantasia";
            person1.SetNINO("abc123");

            Console.WriteLine(person1.GetNINO());
        }
    }

    class Person
    {
        private string NINO;
        public string name;

        //getter and setters needed to be able to read/write private data
        public string GetNINO()
        {
            return this.NINO;
        }
        public void SetNINO(string nino)
        {
            this.NINO = nino;
        }
    }
}
