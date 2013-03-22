using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Schemo
{
    public partial class SimulationSettings : Form
    {
        public SimulationSettings()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Simulator.Instance.Reset();
            Simulator.Instance.Simulate((int)simTimeVal.Value);
            WaveFormDrawer.pixPerTick = (int)pixPerTickVal.Value;
            (new WaveFormsWindow()).Show();
            this.Close();
        }
    }
}
