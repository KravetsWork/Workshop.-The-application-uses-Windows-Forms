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
    public partial class Price_comparison : Form
    {
        List<Lumber> lumber = new List<Lumber>();
        public Price_comparison()
        {
            InitializeComponent();
        }
        public Price_comparison(List<Lumber> lum)
        {
            InitializeComponent();
            pictureBox4.Visible = true;
            lumber = lum;
            try
            {
                for (int i = 0; i < lumber.Count; i++)
                {
                    listBoxLumber1.Items.Add(lumber[i].BriefStr());
                    listBoxLumber2.Items.Add(lumber[i].BriefStr());
                }
            }
            catch (IndexOutOfRangeException) { }
        }

        private void listBoxLumber1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelLumber1.Text = $"{lumber[listBoxLumber1.SelectedIndex].TypeOfWood} {lumber[listBoxLumber1.SelectedIndex].PriceAmountOfWood()} $";
                PriceComp();
            }
            catch { }
        }

        private void listBoxLumber2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelLumber2.Text = $"{lumber[listBoxLumber2.SelectedIndex].TypeOfWood} {lumber[listBoxLumber2.SelectedIndex].PriceAmountOfWood()} $";
                PriceComp();
            }
            catch { }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            pictureBox1.Visible = false;
        }
        private void PriceComp()
        {
            if (lumber[listBoxLumber1.SelectedIndex] > lumber[listBoxLumber2.SelectedIndex])
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            else if (lumber[listBoxLumber1.SelectedIndex] < lumber[listBoxLumber2.SelectedIndex])
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox3.Visible = true;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox4.Visible = false;
            }
        }
    }
}
