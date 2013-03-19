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
    public partial class ElProp : Form
    {
        public ElProp()
        {
            InitializeComponent();
            this.labelElementName.Text = ElementContextProvider.Instance.Selected.Element.Name;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ElementContextProvider.Instance.Selected.Element.Delay = (int)this.delayVal.Value;
            this.Close();
        }
    }
}
