using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM_DataBinding
{
    public partial class EditForm : Form
    {
        private Group _gr;
        public EditForm(Group gr)
        {
            InitializeComponent();
            _gr = gr;
            textBox1.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Num));
            numericUpDown1.DataBindings.Add(nameof(NumericUpDown.Value), _gr, nameof(Group.Year));
            textBox2.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Spec));
            textBox3.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Department));
            comboBox1.DataBindings.Add(nameof(ComboBox.Text), _gr, nameof(Group.Level));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
