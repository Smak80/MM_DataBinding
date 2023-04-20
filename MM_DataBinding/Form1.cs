using System.ComponentModel;

namespace MM_DataBinding
{
    public partial class Form1 : Form
    {
        BindingList<Group> groups = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbh = DBHelper.GetInstance(
                "localhost",
                3306,
                "root",
                "",
                "student"
            );
            groups = dbh.GetGroups();
            dataGridView1.DataSource = groups;
        }

        private void óâåëè÷èòüÃîäÍà1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var group in groups)
            {
                group.Year++;
            }
        }

        private void äîáàâèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newGr = new Group()
            {
                Department = "ÈÌÌ",
                Year = DateTime.Now.Year
            };
            var ef = new EditForm(newGr, true);
            if (ef.ShowDialog() == DialogResult.OK)
            {
                groups.Add(newGr);
            }
        }

        private void èçìåíèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var gr = groups[index];
                var gr_copy = new Group();
                gr.CopyTo(gr_copy);
                var ef = new EditForm(gr_copy);
                if (ef.ShowDialog() == DialogResult.OK)
                {

                    gr_copy.CopyTo(gr);
                }
            }
        }
    }
}