using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project
{
    class Model
    {
        public class Data
        {
            public int Id { get; set; }
            public string ButtonContent { get; set; }
        }

        public class DataNumber
        {
            public string Text { get; set; }
            public int Index { get; set; }
        }
    }
}
