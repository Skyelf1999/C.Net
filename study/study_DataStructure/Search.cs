using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace study_DataStructure
{
    /*
     * 数据单元结构：
        int key = 0;
        string type = "null";
        int data_int = 0;
        string data_string = "null";
     */
    class Search : test_program_struct
    {
        public ArrayList datas;           // 搜索数据集 
        public int key_target = 0;     // 查找的目标key

        public Search()
        {
            string data_mod = "key";
            printf("测试用数据单元模式：" + data_mod);
            datas = create_arraylist(data_mod);

            print("\n请输入查找目标的key：");
            key_target = input_int();
            introduction = "\n\t1. 顺序查找\n" +
               "\t2. 折半查找\n" +
               "\t3. 分块查找\n";
            Console.WriteLine(introduction + "请选择您需要测试的查找方式：");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    search_sequential();
                    break;
                case 2:
                    search_half();
                    break;
                case 3:
                    search_block();
                    break;
            }
        }
        ~Search() { }

        public void show_result(int index)
        {
            printf("目标数据单元序号为：" + index);
        }


        //------------------------------------ 顺序查找 ------------------------------------//
        public void search_sequential()
        {
            func_type("顺序查找", true);
            
            int index = datas.Count;
            while(index>=0)
            {
                DataStruct data = (DataStruct)datas[index];
                if (data.key == key_target) break;
                index--;
            }
            show_result(index);

            func_type("顺序查找", false);
        }
        //------------------------------------ 顺序查找------------------------------------//


        //------------------------------------ 折半查找 ------------------------------------//
        public void search_half()
        {
            func_type("折半查找", true);

            int low = 0, high = datas.Count;
            int mid = 0;
            while(low<=high)
            {
                mid = (low+high)/2;
                DataStruct data = (DataStruct)datas[mid];
                if (data.key == key_target) break;
                if (key_target < data.key) high = mid - 1;
                else low = mid+ 1;
            }
            if (low > high) mid = -1;
            show_result(mid);

            func_type("折半查找", false);
        }
        //------------------------------------ 折半查找------------------------------------//


        //------------------------------------ 分块查找 ------------------------------------//
        public void search_block()
        {
            func_type("分块查找", true);
            func_type("分块查找", false);
        }
        //------------------------------------ 分块查找------------------------------------//

    }
}
