using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ind_zad_18
{
    [Serializable]
    public partial class FullInfo : Form
    {
        public FullInfo()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
