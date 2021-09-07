using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desay
{
    public partial class frmModulus : Form
    {
        public frmModulus()
        {
            InitializeComponent();
        }

        private void frmModulus_Load(object sender, EventArgs e)
        {
            try
            {
                nudSelectCheckModulus.Value = (decimal)Position.Instance.SelectCheckModulus;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Position.Instance.SelectCheckModulus = Convert.ToInt32(nudSelectCheckModulus.Value);
                this.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
