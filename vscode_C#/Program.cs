using System;
using System.Collections;

// 创建：dotnet new console
// 在控制台中输入 dotnet run 运行程序


namespace vsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils utils = new Utils();
            Leetcode leetcode = new Leetcode();
            int i=0;
            for(i=0;i<10;i++) if(i==3) break;

            Console.WriteLine(i);
            // int[] data = {2,0,6,0,0,7,7,0};
            // Console.WriteLine(leetcode.SpecialArray(data));
            
        }

    }

}

