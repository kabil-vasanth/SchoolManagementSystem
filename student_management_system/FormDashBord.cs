using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class FormDashBord : Form
    {
        public FormDashBord()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student.FormStudentMaster f = new Student.FormStudentMaster();
            f.MdiParent = this;
            f.Show();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject.FrmSubjectMaster subject = new Subject.FrmSubjectMaster();
            subject.MdiParent = this;
            subject.Show();
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGradeMaster grade = new FrmGradeMaster();
            grade.MdiParent = this;
            grade.Show();
        }
    }
}
