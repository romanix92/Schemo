using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchemoCore;

namespace Schemo
{
    public partial class WaveFormsWindow : Form
    {
        public WaveFormsWindow()
        {
            InitializeComponent();
        }

        int count = 0;
        int height = 25;

        class WaveFormPanel : Panel
        {
            public WaveForm WaveForm = null;

            public WaveFormPanel()
                : base() { }
        }

        private void AddWaveForm(String name, WaveForm w)
        {
            Label title = new Label();
            title.Text = name;
            title.Location = new Point(5, count * height + 35);
            this.Controls.Add(title);

            WaveFormPanel wave = new WaveFormPanel();
            this.Controls.Add(wave);
            wave.BackColor = Color.White;
            wave.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            wave.Height = 22;
            wave.Width = this.Width - 125;
            wave.Location = new Point(120, count * height + 30);
            wave.WaveForm = w;
            wave.Paint += DrawWaveForm;
            count++;
        }

        private void DrawWaveForm(object sender, PaintEventArgs e)
        {
            WaveFormDrawer.Draw(((WaveFormPanel)sender).WaveForm, e.Graphics);
        }

        private void WaveFormsWindow_Load(object sender, EventArgs e)
        {
            count = 0;
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

        private void WaveFormsWindow_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", 12.0f);
            Brush brush = new SolidBrush(Color.Black);
            for (int i = 0; i <= Simulator.Instance.Duration(); i += 10)
            {
                e.Graphics.DrawString(i.ToString(), font, brush, new Point(115 + i * WaveFormDrawer.pixPerTick, 10));
            }
        }

        private void WaveFormsWindow_Shown(object sender, EventArgs e)
        {
        }


    }
}
