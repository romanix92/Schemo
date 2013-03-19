using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchemoCore;

namespace Shemo
{
    public partial class WaveFormsWindow : Form
    {
        public WaveFormsWindow()
        {
            InitializeComponent();
        }

        int count = 0;
        int height = 25;

        private void AddWaveForm(String name, WaveForm w)
        {
            Label title = new Label();
            title.Text = name;
            title.Location = new Point(5, count * height + 5);
            this.Controls.Add(title);

            Panel wave = new Panel();
            wave.BackColor = Color.White;
            wave.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            wave.Height = 15;
            wave.Width = this.Width - 125;
            wave.Location = new Point(120, count * height + 5);
            this.Controls.Add(wave);

            count++;

            WaveFormDrawer.Draw(w, wave.CreateGraphics());
        }

        private void WaveFormsWindow_Load(object sender, EventArgs e)
        {
            foreach (VisibleElement el in Circuit.gates)
            {
                foreach (Port p in el.Element.GetPorts())
                {
                    WaveForm w = p.WaveForm;
                    String name = p.Name;
                    AddWaveForm(name, w);
                }
            }
        }
    }
}
