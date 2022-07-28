using System;


namespace vsTest
{
    class Utils
    {
        public void test()
        {
            Console.WriteLine("成功");
        }

        public void introduce(string func,bool choice=true)
        {
            string info = "---------------- " + func + " ----------------";
            if(choice) info = "\n\n" + info + "\n";
            else info = "\n" + info + "\n\n";
            Console.WriteLine(info);
        }

        public void funcStart(string func)
        {
            Console.WriteLine("\n\n---------------- " + func + " ----------------\n");
        }
        public void funcEnd(string func)
        {
            Console.WriteLine("\n---------------- " + func + " ----------------\n\n");
        }
    }
}