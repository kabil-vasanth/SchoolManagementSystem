using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system.UI.GradeSubject
{
    public partial class GradeSubjectMaster : Form
    {
        Boolean is_addNew=false;
        public GradeSubjectMaster()
        {
            InitializeComponent();
        }

        private void GradeSubjectMaster_Load(object sender, EventArgs e)
        {
            DataTable dt = DAL.GradeSubjectDal.GetAll();
            dgvGrade.DataSource = dt;
            dgvGrade.Columns["id"].Visible = false;
            dgvGrade.Columns["grade_id"].Visible = false;
            dgvGrade.Columns["subject_id"].Visible = false;
            DataTable dtGrade = DAL.GradeDal.GetAll();
            GScom1.DataSource = dtGrade;
            GScom1.DisplayMember = "name";
            GScom1.ValueMember = "id";

          ;
            DataTable dtSubject = DAL.SubjectDal.GetAll();
            GScom2.DataSource = dtSubject;
            GScom2.DisplayMember = "subject_name";
            GScom2.ValueMember = "id";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (is_addNew)
            {
                Int32 countGradeSubject = DAL.GradeSubjectDal.countGradeSubject(GScom1.SelectedValue.ToString(), GScom2.SelectedValue.ToString());
                MessageBox.Show(countGradeSubject.ToString());
                if(countGradeSubject==0)
                {
                    DAL.GradeSubjectDal.insert(GScom1.SelectedValue.ToString(), GScom2.SelectedValue.ToString());
                    MessageBox.Show("Save success fully....");
                    DataTable dt = DAL.GradeSubjectDal.GetAll();
                    dgvGrade.DataSource = dt;
                    dgvGrade.Columns["id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("This Gradesubject already exits");
                }

             
                
            }
            else
            {
                //Update function
            }

            buttonEnable(false);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            buttonEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            buttonEnable(false);
        }

        private void dgvGrade_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GScom1.SelectedValue =dgvGrade.SelectedRows[0].Cells["grade_id"].Value;
            GScom2.SelectedValue = dgvGrade.SelectedRows[0].Cells["subject_id"].Value;

        }
    }
}
