using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    public abstract class Element
    {
        public void Process()
        {
            Scheduler.Instance.AddEvent(ChangeState, Delay);
        }

        public abstract bool IsMyPort(Port p);

        public abstract void ChangeState();

        public abstract void InitPorts();

        public int Delay { get; set; }

        public String Name { get; set; }

    }

    public abstract class Element2Pin : Element
    {
        public InPort in1 = null;
        public InPort in2 = null;
        public OutPort out1 = null;

        public override void InitPorts()
        {
            in1 = new InPort(this, "1");
            in2 = new InPort(this, "2");
            out1 = new OutPort(this, "1");
        }

        public override sealed void ChangeState()
        {
            if (in1.Signal == Signal.UNDEF || in2.Signal == Signal.UNDEF)
                out1.AcceptSignal(Signal.UNDEF);
            bool in1val = false, in2val = false, outval = false;
            if (in1.Signal == Signal.HIGH)
                in1val = true;
            if (in2.Signal == Signal.HIGH)
                in2val = true;
            outval = Formula(in1val, in2val);
            if (outval)
                out1.AcceptSignal(Signal.HIGH);
            else
                out1.AcceptSignal(Signal.LOW);
        }

        public override bool IsMyPort(Port p)
        {
            return (p == in1 || p == in2 || p == out1);
        }

        protected abstract bool Formula(bool first, bool second);

    }

    public sealed class And2 : Element2Pin
    {
        public And2(String name)
        {
            Delay = 4;
            Name = name;
        }

        protected override bool Formula(bool first, bool second)
        {
            return first && second;
        }
    }

    public sealed class Or2 : Element2Pin
    {
        public Or2(String name)
        {
            Delay = 4;
            Name = name;
        }

        protected override bool Formula(bool first, bool second)
        {
            return first || second;
        }
    }

    public sealed class Nand2 : Element2Pin
    {

        public Nand2(String name)
        {
            Delay = 4;
            Name = name;
        }

        protected override bool Formula(bool first, bool second)
        {
            return !(first && second);
        }
    }

    public sealed class Nor2 : Element2Pin
    {
        public Nor2(String name)
        {
            Delay = 4;
            Name = name;
        }

        protected override bool Formula(bool first, bool second)
        {
            return !(first || second);
        }
    }
}
