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
        private bool newRow;
        private Exception _bindingException;
        public EditForm(Group gr, bool newRow = false)
        {
            this.newRow = newRow;
            InitializeComponent();
            button1.Text = newRow ? "Добавить" : "Изменить";
            _gr = gr;
            textBox1.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Num));
            numericUpDown1.DataBindings.Add(nameof(NumericUpDown.Value), _gr, nameof(Group.Year));
            textBox2.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Spec));
            textBox3.DataBindings.Add(nameof(TextBox.Text), _gr, nameof(Group.Department));
            var cbBinding = comboBox1.DataBindings.Add(nameof(ComboBox.Text), _gr, nameof(Group.Level));
            cbBinding.FormattingEnabled = true;
            cbBinding.BindingComplete += CbBindingOnBindingComplete;
        }

        private void CbBindingOnBindingComplete(object? sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception)
            {
                e.Cancel = false;
                // e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
                comboBox1.BackColor = Color.LightCoral;
            }
            _bindingException = e.Exception;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bindingException != null)
                {
                    MessageBox.Show("Указаны неверные данные!");
                }
                else
                {
                    if (newRow) DBHelper.GetInstance().InsertNew(_gr);
                    else
                    {

                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления новой записи в базу данных");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }
    }
}
