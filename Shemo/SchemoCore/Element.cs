using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    public abstract class Element
    {
        public abstract void Process();

        public int Delay { get; set; }

        public String Name { get; set; }

    }

    /*public class And2 : Element
    {
        
    }*/
}
