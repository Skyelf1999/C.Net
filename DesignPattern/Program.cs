using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using DesignPattern;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        // 设计模式测试
        TestDesignPattern testDesignPattern = TestDesignPattern.GetInstance();
        // testDesignPattern.testFactory();
        // testDesignPattern.testSingleInstance();
        testDesignPattern.testPrototype();
        // testDesignPattern.testAdapter();
        // testDesignPattern.testBridge();
        // testDesignPattern.testComposition();
        // testDesignPattern.testCommand();

    }
    
}