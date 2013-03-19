using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchemoCore;

namespace Shemo
{
    class Simulator
    {
        public static readonly Lazy<Simulator> m_instance = new Lazy<Simulator>(() => new Simulator());

        public void Simulate(int tickCount)
        {
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

        public static Simulator Instance
        {
            get
            {
                return m_instance.Value;
            }
        }
    }
}
