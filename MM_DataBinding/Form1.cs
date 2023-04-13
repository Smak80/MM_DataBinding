using System.ComponentModel;

namespace MM_DataBinding
{
    public partial class Form1 : Form
    {
        BindingList<Group> groups = new();
        private DBHelper dbh;
        public Form1()
        {
            InitializeComponent();
            dbh = new DBHelper(
                "localhost",
                3306,
                "root",
                "",
                "student"
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groups = dbh.GetGroups();
            dataGridView1.DataSource = groups;
        }

        private void Û‚ÂÎË˜ËÚ¸√Ó‰Õ‡1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var group in groups)
            {
                group.Year++;
            }
        }

        private void ‰Ó·‡‚ËÚ¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newGr = new Group()
            {
                Department = "»ÃÃ",
                Year = DateTime.Now.Year
            };
            var ef = new EditForm(newGr);
            if (ef.ShowDialog() == DialogResult.OK)
            {
                groups.Add(newGr);
                dbh.InsertNew(newGr);
            }
        }
        
    }
}