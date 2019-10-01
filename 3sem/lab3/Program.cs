using System;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StreamReader configFile = new StreamReader("config.ini");
            ConfigReader cf = new ConfigReader(configFile);
            Console.WriteLine(cf.GetStringConfig("ADC_DEV", "SampleRate"));
            try
            {
                //Console.WriteLine(cf.GetIntConfig("ADC_DEV", "SampleRate"));
                Console.WriteLine(cf.GetDoubleConfig("ADC_DEV", "SampleRate"));
                Console.WriteLine(cf.GetStringConfig("ABC_DEV", "SampleRate"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
