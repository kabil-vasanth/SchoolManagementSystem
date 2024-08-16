using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system.DAL
{
    public class StudentDal
    {
        public static void GetAll()
        {
            MessageBox.Show("This is Get All grade details");
        }

        public static void GetId(int id)
        {
            MessageBox.Show("This is Get id from Grade");
        }

        public static void insert(string GradeName, string GradeOrder)
        {
            MessageBox.Show("This is insert by Grade");
        }

        public static void update(string GradeName, string GradeOrder)
        {
            MessageBox.Show("This is update by Grade");
        }

        public static void delete(string GradeName, string GradeOrder)
        {
            MessageBox.Show("This is delete by Grade");
        }
    }
}
 