using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class TxtLog:ILog
    {
        private string _filePath;

        public TxtLog(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
