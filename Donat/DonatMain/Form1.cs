using DonatAbstract;
using DonatOutput;

namespace DonatMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            Output outp = new Output((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, new Vector(0, 0, 0), new Vector(0, 0, 100), (int)numericUpDown4.Value);
            outp.Show();
            //Manager manager = new Manager(typeof(Input), typeof(Input), typeof(Input));
        }

        private void InputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void OutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }
    }
}