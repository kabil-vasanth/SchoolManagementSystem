using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system.Subject
{
    public partial class FrmSubjectMaster : Form
    {
        Boolean is_addNew=false;
        public FrmSubjectMaster()
        {
            InitializeComponent();
        }
        private void buttonEnable(bool is_true)
        {
            is_addNew = is_true;
            btnAdd.Enabled = !is_true;
            btnDelete.Enabled = !is_true;
            btnEdit.Enabled = !is_true;
            btnExit.Enabled = !is_true;
            btnRefresh.Enabled = !is_true;

            btnSave.Enabled = is_true;
            btnCancel.Enabled = is_true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSubjectMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to close ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void FrmSubjectMaster_Load(object sender, EventArgs e)
        {

            DataTable dt = DAL.SubjectDal.GetAll();
            dgvSubject.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
            is_addNew = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (is_addNew)
            {
                DAL.SubjectDal.insert(txtSubName.Text.Trim(), txtSubind.Text.Trim(), txtSubOrder.Text.Trim(),subnum.Text.Trim());
                MessageBox.Show("Save success fully....");
                DataTable dt = DAL.SubjectDal.GetAll();
                dgvSubject.DataSource = dt;
             
                txtSubind.Text = null;
                txtSubName.Text = null;
                txtSubOrder.Text = null;
                subnum.Text = null;
            }
            else
            {
                //Update function
            }

            buttonEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Delete ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DAL.SubjectDal.delete(3);
            }
            else
            {

            }
        }
    }
}
