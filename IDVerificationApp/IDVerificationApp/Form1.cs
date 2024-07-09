using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDVerificationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long ID = long.Parse(txtID.Text);
            int birthYear = int.Parse(txtDate.Text);
            bool status;

            try
            { 
                using(IDVerification.KPSPublicSoapClient service = new 
                IDVerification.KPSPublicSoapClient { })
                {
                    status = service.TCKimlikNoDogrula(ID,txtName.Text,txtSurname.Text,birthYear);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (status == true)
            {
               MessageBox.Show("Save success");
            }
            else
            {
               MessageBox.Show("Save not successful");
            }
           
        }
    }
}
