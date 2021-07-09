using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnScrambler.Helpers
{
    public class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
