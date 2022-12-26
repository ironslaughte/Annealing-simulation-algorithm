using System.IO;
using System.Collections.Generic;
using System;
namespace K_means
{
    static class FileReader
    {
        public static List<string[]> Read(string nameFile)
        {
            var streamReader = new StreamReader(nameFile);
            var data = streamReader.ReadToEnd();
            streamReader.Close();   

            var newData = string.Join(" ", data.Split(',', '\n')).Split('\r');
            List<string[]> result = new List<string[]>();
            foreach (var item in newData)
            {
                string row =  item.Trim().Replace('.', ',');
                result.Add(row.Split(' '));
            }
            return result;
        }
    }
}
