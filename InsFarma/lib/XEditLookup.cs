using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

// How to: Create a Windows Forms Control That Shows Progress
// https://msdn.microsoft.com/en-us/library/ms229628(v=vs.110).aspx

namespace InsFarma
{
    /// <summary>
    /// Component que lliga un valor amb una taula associada a través del parell <clau, valor>
    /// Cada vegada que es canvia la propietat Clau, cerca a la taula associada les dades corresponents.
    /// </summary>
    public class XEditLookup_old : ComboBox
    {
        private string FClau = "";
        private string FValor = "";
        private SqlConnection FConnexio = null;
        private string FTaula = "";
        private string FCampClau = "";
        private string FCampText = "";
        DataTable dsTbl = new DataTable();

        #region Constructor

        /// <summary>
        /// Inicialitza una nova instància de la classe <see cref="XEditLookup_old"/>.
        /// </summary>
        public XEditLookup_old()
        {
            //DropDownHeight = 1;
            //DropDownStyle = ComboBoxStyle.Simple;
            //MaxDropDownItems = 1;

            dsTbl.Columns.Add("key", typeof(string));
            dsTbl.Columns.Add("value", typeof(string));
            object[] row = new object[2];
            row[0] = "TEST";
            row[1] = "PROVA";
            dsTbl.Rows.Add(row);
            row[0] = "TEST2";
            row[1] = "PROVA2";
            dsTbl.Rows.Add(row);
            DataSource = dsTbl;
            ValueMember = "key";
            DisplayMember = "value";

            DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            //IntegralHeight = false;
            FormattingEnabled = true;

            //edtIntern.TextChanged += edtIntern_TextChanged;
        }

        #endregion

        #region Propietats

        /// <summary>
        /// Valor de la clau interna del component.
        /// </summary>
        public string Valor {
            get
            {
                return FValor;
            }
            set
            {
                FValor = value;
                if (FValor == "")
                {
                    DataSource = null;
                    Items.Clear();
                    dsTbl.Columns.Clear();
                    DisplayMember = "";
                    ValueMember = "";
                    Text = "";
                    ResetText();
                }
                else
                {
                    Text = "";

                    dsTbl.Columns.Clear();
                    dsTbl.Columns.Add("key", typeof(string));
                    dsTbl.Columns.Add("value", typeof(string));
                    object[] row = new object[2];
                    row[0] = "20";
                    row[1] = "PROVA2";
                    dsTbl.Rows.Add(row);
                    DataSource = dsTbl;
                    ValueMember = "key";
                    DisplayMember = "value";

                    //SelectedValue = FValor;
                    //SelectedValue = dsTbl.Rows[0];
                    //SelectedValue = FValor;

                    //SelectedIndex = 1;
                    SelectedItem = "20";

                    this.Refresh();

                    /* dsTbl.Rows[0][0] = FValor;
                     dsTbl.Rows[0][1] = CarregaText(FValor);
                     SelectedIndex = 1;*/
                }
            }
        }

        /// <summary>
        /// Connexió a la base de dades.
        /// </summary>
        public SqlConnection Connexio { get { return FConnexio; } set { FConnexio = value; } }

        /// <summary>
        /// Taula associada.
        /// </summary>
//        public string Taula { get { return FTaula; } set { FTaula = value; } }
        public string Taula { get; set; }

        /// <summary>
        /// Camp de la clau primària de la taula associada.
        /// </summary>
        public string CampClau { get { return FCampClau; } set { FCampClau = value; } }

        /// <summary>
        /// Camp de la taula associada que es mostrarà.
        /// </summary>
        public string CampText { get { return FCampText; } set { FCampText = value; } }

        #endregion
     
        protected override void OnTextChanged(EventArgs e)
        {
/*            if (!changingText && database != null)
            {
                //searching the first candidate
                string typed = this.Text.Substring(0, this.SelectionStart);
                string candidate = null;
                for (int i = 0; i < database.Length; i++)
                    if (database[i].Substring(0, this.SelectionStart) == typed)
                    {
                        candidate = database[i].Substring(this.SelectionStart, database[i].Length);
                        break;
                    }
                if (candidate != null)
                {
                    changingText = true;
                    this.Text = typed + candidate;
                    this.SelectionStart = typed.Length;
                    this.SelectionLength = candidate.Length;
                }
            }
            else if (changingText)
                changingText = false;*/
            base.OnTextChanged(e);
        }

        private void edtIntern_TextChanged(object sender, EventArgs e)
        {

        }

        private string CarregaText(string sValor)
        {
            SqlConnection con = new SqlConnection(Connexio.ConnectionString);
            string queryString = "SELECT "+ CampText + " FROM "+Taula+" WHERE "+CampClau+"=" + FValor;
            string sText = "";

            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    sText = String.Format("{0}", reader[CampText]);
                }
            }
            finally
            {
                reader.Close();
                con.Close();
            }

            return sText;
        }

    }




    /// <summary>
    /// Component que lliga un valor amb una taula associada a través del parell <clau, valor>
    /// Cada vegada que es canvia la propietat Clau, cerca a la taula associada les dades corresponents.
    /// </summary>
    public class XEditLookup : XEditButton
    {
        //private string FClau = "";
        private string FValor = "";
        private SqlConnection FConnexio = null;
        private string FTaula = "";
        private string FCampClau = "";
        private string FCampValor = "";
        DataTable dsTbl = new DataTable();
        private Type FClasseRecerca = null;

        #region Constructor

        /// <summary>
        /// Inicialitza una nova instància de la classe <see cref="XEditLookup"/>.
        /// </summary>
        public XEditLookup() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        #endregion

        #region Propietats

        /// <summary>
        /// Valor de la clau interna del component.
        /// </summary>
        public string Clau
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
                if (Text == "")
                {
                    FValor = "";
                }
                else
                {
                    FValor = CarregaText(Text);
                }
            }
        }

        /// <summary>
        /// Valor que correspon a la clau interna (cercada a través de la taula a la base de dades).
        /// </summary>
        public string Valor { get { return FValor; } set { FValor = value; } }

        /// <summary>
        /// Connexió a la base de dades.
        /// </summary>
        public SqlConnection Connexio { get { return FConnexio; } set { FConnexio = value; } }

        /// <summary>
        /// Taula associada.
        /// </summary>
        public string Taula { get { return FTaula; } set { FTaula = value; } }

        /// <summary>
        /// Camp de la clau primària de la taula associada.
        /// </summary>
        public string CampClau { get { return FCampClau; } set { FCampClau = value; } }

        /// <summary>
        /// Camp de la taula associada que es mostrarà.
        /// </summary>
        public string CampValor { get { return FCampValor; } set { FCampValor = value; } }

        /// <summary>
        /// Classe del formulari de recerca associat amb el component.
        /// </summary>
        public Type ClasseRecerca { get { return FClasseRecerca; } set { FClasseRecerca = value; } }

        #endregion


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // Si canvia el text (per exemple quan el component està lligat a dades)
            Clau = Text;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class. 
            base.OnPaint(e);

            RectangleF textRect = new RectangleF();
            string toDisplay = FValor;
            SizeF textSize = e.Graphics.MeasureString(toDisplay, Font);
            textRect.Width = Width;
            textRect.Height = Height;
            e.Graphics.Flush();
            e.Graphics.DrawString(toDisplay, Font, new SolidBrush(ForeColor), textRect);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                case Keys.Back:
                    Clau = "";
                    break;
            }
        }

        private string CarregaText(string sClau)
        {
            SqlConnection con = new SqlConnection(Connexio.ConnectionString);
            string sSQL = "SELECT " + CampValor + " FROM " + Taula + " WHERE " + CampClau + "=" + sClau;
            string sText = "";

            SqlCommand command = new SqlCommand(sSQL, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    sText = String.Format("{0}", reader[CampValor]);
                }
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return sText;
        }
    }
}
