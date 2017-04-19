
// XEditNumber
// http://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace InsFarma
{
    public partial class frmMain : Form
    {
        private SqlConnection conFarma = new SqlConnection();

        public frmMain()
        {
            InitializeComponent();
        }

        private void quantAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuantADialeg f = new FrmQuantADialeg();
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }
        }

        private void configuracióToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracioDialeg f = new FrmConfiguracioDialeg();
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            // Connexió a la base de dades
            // Persist Security Info=True, sinó s'esborra el password
            // http://stackoverflow.com/questions/12467335/connectionstring-loses-password-after-connection-open
            String sConnexio = "Data Source=ORD203012; Initial Catalog=FIP; User ID=sa; Password=00Coordno+*mi; Persist Security Info=True";
            conFarma.ConnectionString = sConnexio;
            conFarma.Open();
        }

        private void marquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarcaArticleRecercaFitxa.Mostra(conFarma);
        }

        private void famíliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamiliaArticleRecercaFitxa.Mostra(conFarma);
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgendaRecerca.Mostra(conFarma);
        }

        private void classificacióAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassificacioAgendaRecercaFitxa.Mostra(conFarma);
        }

        private void articlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticleRecerca.Mostra(conFarma);
        }

    }
}
