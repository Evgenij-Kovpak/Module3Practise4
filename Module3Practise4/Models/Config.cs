using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Practise4.Models
{
    public class Config
    {
        public string LogFolderPath { get; set; }

        public string LogNameFile { get; set; }

        public string BackUpFolderPath { get; set; }

        public int CountRecordsFlushBackUp { get; set; }
    }
}
