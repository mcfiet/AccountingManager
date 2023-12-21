using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Services.PdfExport
{
    public class SaveFileDialog
    {
        public String FolderPath { get; set; }
        public String FileName { get; set; }
        public String DefaultExt { get; set; }
        public String Filter { get; set; }
    }
}
