using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VHMIS
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
           MainForm frm = new MainForm();
         //   frm.MdiParent = ParentForm.ActiveForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
