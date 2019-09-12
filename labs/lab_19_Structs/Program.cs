using System;

namespace lab_19_Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MyStruct();
            var s2 = new MyStruct(10, 10, "Hi");
            Console.WriteLine(s2.getX());
        }
    }

    class MyClass
    {

    }

    struct MyStruct
    {
        private int x;
        public int y;
        public string z { get; set; }
        public MyStruct(int x, int y, string z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int getX()
        {
            return this.x;
        }
    }
}
