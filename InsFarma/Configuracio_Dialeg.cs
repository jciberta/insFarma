using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsFarma
{
    public partial class FrmConfiguracioDialeg : Form
    {
        public FrmConfiguracioDialeg()
        {
            InitializeComponent();
        }

        private void FrmConfiguracioDialeg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fIPDataSet.SISTEMA' table. You can move, or remove it, as needed.
            this.sISTEMATableAdapter.Fill(this.fIPDataSet.SISTEMA);
        }

        private void btnDAcord_Click(object sender, EventArgs e)
        {
            // Desa les dades
            try
            {
                this.Validate();
                this.sISTEMABindingSource.EndEdit();
                this.sISTEMATableAdapter.Update(this.fIPDataSet.SISTEMA);
            }
            catch 
            {
                MessageBox.Show("Error en desar les dades.");
            }
            this.Close();
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
