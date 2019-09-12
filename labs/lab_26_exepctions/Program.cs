using System;
using System.IO;

namespace lab_26_exepctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ERROR -> bank calculates your interest incorrectly : programmer error in logic

            //EXCEPTION -> code crashes so program cannot continue

            //handled -> the exception takes place in a try block and the code is held in the catch block 
            //  - error or not, it will run the finally block
            //unhandled -> messy exception, the program temrinates uncleanly
            //compiler -> the program will not build
            //runtime -> will build but will crash (e.g. divide by 0)

            int x = 10;
            int y = 0;
            //Console.WriteLine(x/y); //unhandled exception 



            try {
                //try any code that might produce an exception
                Console.WriteLine(x/y); //this will throw an exception 
            }
            catch(Exception e) {
                Console.WriteLine("Hey! dont do that!");
                Console.WriteLine(e);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("Have fun");
            }

            //custom exceptions 
            var myException = new Exception("Hey this is a phil special");
            try
            {
                //imagine engine is getting hot but hasnt burnt out yet 
                throw (myException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //large application 
            //layers of nesting (e.g. main, sub, sub, ...)
            try
            {
                try
                {
                    try
                    {
                        throw (new Exception("inner exception"));
                    }
                    catch(Exception e)
                    {
                        throw;
                    }
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.WriteAllText("log.txt", $"Phils code not working again - typical - {e.Message}");
            }

            //types of exceptions 
            try {
                Console.WriteLine(x/y);
            }
            catch(DivideByZeroException e) {
                Console.WriteLine("Dont do that");
            }
            catch (Exception e)
            {
                Console.WriteLine("all exceptions");
            }
        }
    }
}
