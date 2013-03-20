using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{
    public abstract class Generator : Element
    {
        public Generator(String name, int period)
        {
            this.Name = name;
            this.Delay = period;
        }

        public override bool IsMyPort(Port p)
        {
            return p.Name == m_port.Name;
        }

        public override void InitPorts()
        {
            m_port = new OutPort(this, "out");
        }

        public virtual void Start()
        {
            this.ChangeState();
        }

        public OutPort Port
        {
            get
            {
                return m_port;
            }
        }

        public override List<Port> GetPorts()
        {
            List<Port> res = new List<Port>();
            res.Add(m_port);
            return res;
        }

        protected OutPort m_port;
    }

    public class ClockGenerator : Generator
    {
        public ClockGenerator(String name, int period)
            : base(name, period)
        { }

        public override void ChangeState()
        {
            if (m_port.Signal == Signal.LOW || m_port.Signal == Signal.UNDEF)
                m_port.AcceptSignal(Signal.HIGH);
            else
                m_port.AcceptSignal(Signal.LOW);
            Scheduler.Instance.AddEvent(this.ChangeState, this.Delay);
        }
    }
}
