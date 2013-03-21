using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemoCore;

namespace Schemo
{
    class Simulator
    {
        public static readonly Lazy<Simulator> m_instance = new Lazy<Simulator>(() => new Simulator());

        public void Simulate(int tickCount)
        {
            m_tickCount = tickCount;
            foreach (VisibleElement gate in Circuit.gates)
            {
                Generator g = gate.Element as Generator;
                if (g != null)
                    g.Start();
            }

            for (int i = 0; i < tickCount; ++i)
            {
                Scheduler.Instance.Execute();
            }
        }

        public int Duration()
        {
            return m_tickCount;
        }

        public void Reset()
        {
            Scheduler.Instance.Reset();
            m_tickCount = 0;
            foreach (VisibleElement el in Circuit.gates)
            {
                foreach (Port p in el.Element.GetPorts())
                    p.WaveForm.Clear();
            }
        }
        int m_tickCount;

        public static Simulator Instance
        {
            get
            {
                return m_instance.Value;
            }
        }
    }
}
