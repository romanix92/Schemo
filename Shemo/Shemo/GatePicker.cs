using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shemo
{
    public partial class GatePicker : Form
    {
        public GatePicker()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            String s = (String)listGates.SelectedItem;
            switch (s)
            {
                case "And2":
                    AddingState.Instance.selected = typeof(And2Visible);
                    break;
                case "Or2":
                    AddingState.Instance.selected = typeof(Or2Visible);
                    break;
                case "Nor2":
                    AddingState.Instance.selected = typeof(Nor2Visible);
                    break;
                case "Nand2":
                    AddingState.Instance.selected = typeof(Nand2Visible);
                    break; 
                default:
                    break;
            }
            this.Close();
        }
    }
}
