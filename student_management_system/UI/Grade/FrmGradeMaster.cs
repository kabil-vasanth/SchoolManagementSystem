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
    public partial class FrmGradeMaster : Form
    {
        Boolean is_addNew = false;

        public FrmGradeMaster()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            buttonEnable(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            String grdName=txtGrdName.Text;
            String grdClr=txtColor.Text;
            String grdOrd=txtGrdOrder.Text;
            String grdGrp=txtGrdGrp.Text;
            if (is_addNew)
            {
              DAL.GradeDal.insert(grdName, grdClr, grdOrd, grdGrp);
                MessageBox.Show("Save success fully....");
                DataTable dt = DAL.GradeDal.GetAll();
                dgvGrade.DataSource = dt;
                txtColor.Text=null;
                txtGrdGrp.Text = null;
                txtGrdName.Text = null;
                txtGrdOrder.Text=null;
            } 
            else
            {
                //Update function
            }

            buttonEnable(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
            is_addNew= false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
                this.Close();
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Delete ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DAL.GradeDal.delete(3);
            }
            else
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Frmload();
        }

        private void FrmGadeMaster_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FrmGradeMaster_Load(object sender, EventArgs e)
        {
            Frmload();
        }
        private void Frmload()
        {
            DataTable dt = DAL.GradeDal.GetAll();
            dgvGrade.DataSource = dt;
        }
    }
}
