using System;
using System.Windows.Forms;


namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {
        Udvoitel udvoitel = new Udvoitel();
        public Form1()
        {
            InitializeComponent();
            новаяToolStripMenuItem.PerformClick();
        }
        void ShowInfo(Udvoitel udv)
        {
            lblNumber.Text = udv.Finish.ToString();
            lblCount.Text = udv.Count.ToString();
            lblSteps.Text = udv.Steps.ToString();
            lblCurrent.Text = udv.ToString();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            udvoitel.Reset();
            ShowInfo(udvoitel);
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            udvoitel.Plus();
            ShowInfo(udvoitel);
        }
        private void btnMulti_Click(object sender, EventArgs e)
        {
            udvoitel.Multi();
            ShowInfo(udvoitel);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            udvoitel.Back();
            ShowInfo(udvoitel);
        }
        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            udvoitel = new Udvoitel();
            ShowInfo(udvoitel);
        }
    }
}
