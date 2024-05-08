using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxLabelUtilApp
{
    public class ModelFile
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Path { get; set; }
        public AxModelInfo ModelInfo { get; set; }
    }
}
