using System;

namespace study_1
{
    class Test_main
    {
        static void Main(string[] args)
        {
            print_hello();
            int choice = Convert.ToInt32(Console.ReadLine());
            Test_1 test_1 = new Test_1();
            switch(choice)
            {
                case 1:
                    test_1.test_class();
                    break;
                case 2:
                    test_1.test_array();
                    break;
                case 3:
                    test_1.test_string();
                    break;
                case 4:
                    test_1.test_son();
                    break;
            }
        }

        static void print_hello()
        {
            Console.WriteLine("请选择您需要测试的功能：\n");
            return;
        }

    }


    class Test_1        // 基础测试
    {
        public void func_type(String func,int choice)
        {
            if (choice == 0) Console.WriteLine("\n//---------------- " + func + " ----------------//\n\n");
            else Console.WriteLine("\n\n//---------------- " + func + " ----------------//\n");
        }

        public void test_class()
        {
            func_type("类方法与输入输出测试",0);
            Player player_1 = new Player();
            Console.WriteLine("Hello World!\n");
            player_1.getInfo();

            player_1.Name = "青冥鸟道深";
            // 输入的数据类型转换
            player_1.Age = Convert.ToInt32(Console.ReadLine());
            player_1.Game_fav = Console.ReadLine();
            player_1.getInfo();
            // 输出数据类型转换
            Console.WriteLine("\nplayer_1的age：" + player_1.Age.ToString());
            func_type("类方法与输入输出测试", 1);
        }

        public void test_array()
        {
            func_type("数组测试", 0);
            // 定义
            int[] array_int = new int[10];
            String[] array_string = { "DotA", "SC", "MHW" };

            func_type("数组测试", 0);
        }

        public void test_string()
        {
            func_type("字符串测试", 1);
            string hello = "Hello";
            Console.WriteLine("{0}的第二个字符为：{1}",hello,hello[1]);
            int length = hello.Length;
            Console.WriteLine("{0}的长度为：{1}", hello, length);
            string hello_new = hello + ", 这是拼接的部分";
            Console.WriteLine(hello_new);
            bool result = hello_new.Contains(hello);
            Console.WriteLine("hello_new是否包含hello：{0}", result);
            func_type("字符串测试", 0);
        }

        public void test_son()
        {
            Player_DotA dotaer = new Player_DotA("起名难",22, 5);
            dotaer.speak();
            dotaer.getInfo();
        }


    }


}
