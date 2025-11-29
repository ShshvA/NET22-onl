using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public interface IDoctor
    {
        public void Treat();

        public string Name { get; set; }
    }    
}
