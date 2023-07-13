using System;
using System.Collections;
using System.Collections.Generic;
using DesignMethod;

namespace OnMac
{
    class Program
    {
        static void Main(string[] args)
        {
            testFactory();

        }


        public static void testFactory()
        {
            Product product = Factory.GetProduct(1);
        }
    }

}
