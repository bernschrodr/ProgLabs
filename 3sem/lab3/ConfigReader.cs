using System;
using System.IO;
using System.Collections.Generic;

namespace lab3
{
    public class ConfigReader
    {
        Dictionary<string, Dictionary<string, string>> configs = new Dictionary<string, Dictionary<string, string>>();

        public ConfigReader(StreamReader configFile)
        {
            string line;
            int indexBufer;
            char[] sectionSeparators = { '[', ']', ' ', '/', '\\', '.' };
            char[] configSeparators = { '=', ' ', };
            string[] section = { };
            bool sectionCorrect = true;
            while ((line = configFile.ReadLine()) != null)
            {

                indexBufer = line.IndexOf('[');
                if (indexBufer != -1 && line.IndexOf(']', indexBufer) != -1)
                {
                    section = line.Split(sectionSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (section.Length != 1)
                    {
                        sectionCorrect = false;
                        Console.WriteLine("Wrong section name");
                        continue;
                    }
                    else
                    {
                        sectionCorrect = true;
                        configs.Add(section[0], new Dictionary<string, string>());
                        continue;
                    }
                }

                string[] config;
                Dictionary<string, string> configsOut;
                if (sectionCorrect)
                {
                    indexBufer = line.IndexOf(';');
                    if (indexBufer == 0)
                    {
                        continue;
                    }
                    if (indexBufer != -1)
                    {
                        line = line.Substring(0, indexBufer);
                    }
                    config = line.Split(configSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (config.Length != 2)
                    {
                        Console.WriteLine("Wrong config string");
                        continue;
                    }
                    else
                    {
                        if (configs.TryGetValue(section[0], out configsOut))
                        {
                            configsOut.Add(config[0], config[1]);
                        }
                    }
                }
            }
        }

        public string GetStringConfig(string section, string configName)
        {
            Dictionary<string, string> configsOut;
            string parametrOut;
            if (configs.TryGetValue(section, out configsOut))
            {
                if (configsOut.TryGetValue(configName, out parametrOut))
                {
                    return parametrOut;
                }
            }
            return "Not Found";
        }

        public int GetIntConfig(string section, string configName)
        {
            Dictionary<string, string> configsOut;
            string parametrOut;
            int outInt;
            if (configs.TryGetValue(section, out configsOut))
            {
                if (configsOut.TryGetValue(configName, out parametrOut))
                {
                    if (Int32.TryParse(parametrOut, out outInt)){
                        return outInt;
                    }
                }
            }
            throw new Exception("Can not be parsed");
        }

        public double GetDoubleConfig(string section, string configName)
        {
            Dictionary<string, string> configsOut;
            string parametrOut;
            Double outDouble;
            if (configs.TryGetValue(section, out configsOut))
            {
                if (configsOut.TryGetValue(configName, out parametrOut))
                {
                    if (Double.TryParse(parametrOut, out outDouble)){
                        return outDouble;
                    }
                }
            }
            throw new Exception("Can not be parsed");
        }

    }
}