using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    [Obsolete]
    interface IElementFactory
    {
        Element newInstance { get; }
    }

    class And2Factory : IElementFactory
    {
        public Element newInstance
        {
            get
            {
                And2 newEl = new And2("And2_" + IndexProvider.Instance.Index);
                newEl.InitPorts();
                return newEl;
            }
        }
    }

    class Or2Factory : IElementFactory
    {
        public Element newInstance
        {
            get
            {
                Or2 newEl = new Or2("Or2_" + IndexProvider.Instance.Index);
                newEl.InitPorts();
                return newEl;
            }
        }
    }

    class Nand2Factory : IElementFactory
    {
        public Element newInstance
        {
            get
            {
                Nand2 newEl = new Nand2("Nand2_" + IndexProvider.Instance.Index);
                newEl.InitPorts();
                return newEl;
            }
        }
    }

    class Nor2Factory : IElementFactory
    {
        public Element newInstance
        {
            get
            {
                Nor2 newEl = new Nor2("Nor2_" + IndexProvider.Instance.Index);
                newEl.InitPorts();
                return newEl;
            }
        }
    }
}
