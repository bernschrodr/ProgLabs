using System.Collections.Generic;
using System;
using System.Globalization;

namespace lab3
{
    public class Section
    {
        public string Name { get; }
        Dictionary<string, string> configs = new Dictionary<string, string>();

        public Section(string name){
            Name = name;
        }
        public void Add(string config, string value){
            configs.Add(config,value);
        }

        public string GetStringConfig(string configName)
        {
            string parametrOut;

            if (configs.TryGetValue(configName, out parametrOut))
            {
                return parametrOut;
            }
            else
            {
                throw new NotFoundException("Config Not Found");
            }
        }

        public int GetIntConfig(string configName)
        {
            string value = GetStringConfig(configName);
            if (Int32.TryParse(value, NumberStyles.Number,
            new CultureInfo("en-US"), out int outInt))
            {
                return outInt;
            }
            else
            {
                throw new NotParsedException("Can not be parsed");
            }
        }

        public double GetDoubleConfig(string configName)
        {
            string value = GetStringConfig(configName);
            if (Double.TryParse(value, NumberStyles.Number,
            new CultureInfo("en-US"), out double outInt))
            {
                return outInt;
            }
            else
            {
                throw new NotParsedException("Can not be parsed");
            }
        }
    }
}