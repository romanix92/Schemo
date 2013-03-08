using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemoCore
{

    delegate void SignalHandler(Signal s);

    public abstract class Port
    {
        public abstract void AcceptSignal(Signal s);
        public String Name { get; set; }
        public Signal Signal { get { return m_signal; } }
        protected Signal m_signal;
    }

    public class InOutPort : Port
    {
        public InOutPort()
        {
            m_signal = Signal.UNDEF;
        }

        public InOutPort(String name)
        {
            m_signal = Signal.UNDEF;
            Name = name;
        }

        public override void AcceptSignal(Signal s)
        {
            lock (this)
            {
                m_signal = s;
                m_subscribers.BeginInvoke(m_signal, null, null);
            }
        }

        public void AddSubscriber(Port p)
        {
            m_subscribers += p.AcceptSignal;
        }

        private SignalHandler m_subscribers;
    }

    public class InPort : Port
    {
        public InPort(Element elem)
        {
            m_parent = elem;
            m_signal = Signal.UNDEF;
            Name = elem.Name + "_In_" + this.GetHashCode().ToString();
        }

        public InPort(Element elem, String name)
        {
            m_parent = elem;
            m_signal = Signal.UNDEF;
            Name = elem.Name + "_" + name;
        }

        public override void AcceptSignal(Signal s)
        {
            lock (this)
            {
                m_signal = s;
                m_parent.Process();
            }
        }

        private Element m_parent;

    }

    public class OutPort : Port
    {
        public override void AcceptSignal(Signal s)
        {

        }

        public void AddSubscriber(Port p)
        {

        }
    }
}
