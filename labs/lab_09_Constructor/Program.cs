using System;

namespace lab_09_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Mercades merc01 = new Mercades(); //calling default constructor   
            Mercades merc02 = new Mercades("Chassis123", "Silver", 2500);//calls our custom constructor

            AClass AClass = new AClass("Chassis123", "blue", 2600);//calls the AClass constructor

            A104 a104_01 = new A104("Chassis456", "red", 1800); //calls the A104 constructor
            A104 a104_02 = new A104("Chassis456", "red");
        }
    }

    class Mercades
    {
        protected string engineChassisID;
        public string Color { get; set; }
        public int Length { get; set; }

        public Mercades() { }//default constructor

        //constructor
        public Mercades(string engineChassisID, string color, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Color = color;
            this.Length = length;
        }
    }

    class AClass : Mercades
    {
        public AClass() { }

        public AClass(string engineChassisID, string color, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Color = color;
            this.Length = length;
        }
    }

    class A104 : AClass
    {
        //different constructor which is calling the base/parent constructor
        public A104(string engineChassisID, string color, int length = 2300) : base(engineChassisID, color, length)
        {
            
        }
    }
}
