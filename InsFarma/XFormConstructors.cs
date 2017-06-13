using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace InsFarma
{
    [Flags]
    public enum FormFitxaOpcions
    {
        Cap = 0x0,
        Obligatori = 0x1,
        NomesLectura = 0x2,
        AlCostat = 0x4,
        ExecutaSQL = 0x8
    }

    public enum ModalitatFormulari
    {
        Alta,
        Mostra,
        Busca
    }

    /// <summary>
    /// Classe base per als formularis.
    /// </summary>
    public class XFormConstructor
    {
        protected Form FForm;
        protected ToolStrip FBarraEines = new ToolStrip();
        protected ToolStripButton tsbNou = new ToolStripButton();
        protected ToolStripButton tsbDesa = new ToolStripButton();
        protected ToolStripButton tsbElimina = new ToolStripButton();
        protected ToolStripButton tsbActualitza = new ToolStripButton();
        protected ToolStripButton tsbFiltre = new ToolStripButton();
        protected ToolStripButton tsbOpcions = new ToolStripButton();
        protected ToolStripButton tsbImpressora = new ToolStripButton();
        protected ToolStripButton tsbSurt = new ToolStripButton();
        Assembly _assembly;
        Stream _imageStream;

        /// <summary>
        /// Constructor de l'objecte.
        /// </summary>
        public XFormConstructor()
        {
            FForm = new Form();
            FForm.MdiParent = Application.OpenForms[0];
            FForm.Width = 400;
            FForm.Height = 400;
            FForm.StartPosition = FormStartPosition.CenterScreen;
            CreaBarraEines();
        }

        /// <summary>
        /// Crea la barra d'eines.
        /// </summary>
        private void CreaBarraEines()
        {
            // Cal posar les imatges com a Embedded Resource!
            _assembly = Assembly.GetExecutingAssembly();

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Nou.bmp");
            tsbNou.ImageTransparentColor = Color.Fuchsia;
            tsbNou.Image = new Bitmap(_imageStream);
            tsbNou.ToolTipText = "Nou";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Desa.bmp");
            tsbDesa.ImageTransparentColor = Color.Fuchsia;
            tsbDesa.Image = new Bitmap(_imageStream);
            tsbDesa.ToolTipText = "Desa";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Elimina.bmp");
            tsbElimina.ImageTransparentColor = Color.Fuchsia;
            tsbElimina.Image = new Bitmap(_imageStream);
            tsbElimina.ToolTipText = "Elimina";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Actualitza.bmp");
            tsbActualitza.ImageTransparentColor = Color.Fuchsia;
            tsbActualitza.Image = new Bitmap(_imageStream);
            tsbActualitza.ToolTipText = "Actualitza";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Filtre.bmp");
            tsbFiltre.ImageTransparentColor = Color.Fuchsia;
            tsbFiltre.Image = new Bitmap(_imageStream);
            tsbFiltre.ToolTipText = "Filtra";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Opcions.bmp");
            tsbOpcions.ImageTransparentColor = Color.Fuchsia;
            tsbOpcions.Image = new Bitmap(_imageStream);
            tsbOpcions.ToolTipText = "Opcions";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Impressora.bmp");
            tsbImpressora.ImageTransparentColor = Color.Fuchsia;
            tsbImpressora.Image = new Bitmap(_imageStream);
            tsbImpressora.ToolTipText = "Imprimeix";

            _imageStream = _assembly.GetManifestResourceStream("InsFarma.16x16_Surt.bmp");
            tsbSurt.ImageTransparentColor = Color.Fuchsia;
            tsbSurt.Image = new Bitmap(_imageStream);
            tsbSurt.ToolTipText = "Surt";
            tsbSurt.Click += tsbSurt_Click;

            FBarraEines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                tsbNou,
                tsbDesa,
                tsbElimina,
                new ToolStripSeparator(),
                tsbActualitza,
                tsbFiltre,
                new ToolStripSeparator(),
                tsbOpcions,
                new ToolStripSeparator(),
                tsbImpressora,
                new ToolStripSeparator(),
                tsbSurt
            });
            FBarraEines.Location = new Point(0, 0);
            FBarraEines.Size = new Size(628, 31);
            FBarraEines.Dock = DockStyle.Top;
            FForm.Controls.Add(FBarraEines);
        }

        private void tsbSurt_Click(object sender, EventArgs e)
        {
            FForm.Close();
        }
    }

    /// <summary>
    /// Formularis de recerca.
    /// </summary>
    public class XFormRecercaConstructor : XFormConstructor
    {
        private ModalitatFormulari FModalitatFormulari;
        protected SqlConnection FConnexio;
        protected String FTaula;
        protected String FCampId;
        private String FCampsRecerca;
        private SqlCommand FSqlCommand = new SqlCommand();
        protected BindingSource FBindingSource = new BindingSource();
        protected SqlDataAdapter FSqlDataAdapter = new SqlDataAdapter();
        protected DataSet FDataSet = new DataSet();
        protected DataTable FDataTable = new DataTable();
        private ImageList FImageList = new ImageList();
        protected DataGridView FDataGridView = new DataGridView();
        protected Panel FPanel = new Panel();
        private TextBox edtCerca = new TextBox();
        private Label lblCerca = new Label();
        private Type FClasseFitxa = null;
        protected string SQL = "";
        public string ValorRetorn = "";

        /// <summary>
        /// Constructor de l'objecte.
        /// </summary>
        /// <param name="con">Connexió a la base de dades.</param>
        /// <param name="sTaula">Taula de la base de dades.</param>
        /// <param name="sCampId">Clau primària de la taula.</param>
        /// <param name="sCampsRecerca">Llistat de camps per fer la recerca separats per comes.</param>
        public XFormRecercaConstructor(SqlConnection con, String sTaula, String sCampId, String sCampsRecerca = "")
        {
            FConnexio = con;
            FForm.Text = sTaula; // Títol per defecte
            FForm.Width = 800;
            FTaula = sTaula;
            FCampId = sCampId;
            FCampsRecerca = sCampsRecerca;

            // Elements visuals
            CreaPanellCerca();

            tsbNou.Click += tsbNou_Click;
            tsbDesa.Visible = false;
            tsbElimina.Visible = false;
            tsbActualitza.Click += tsbActualitza_Click;
            FForm.KeyPreview = true;
            FForm.KeyDown += FForm_KeyDown;

            FForm.Controls.Add(FDataGridView);
            FDataGridView.Dock = DockStyle.Fill;
            FDataGridView.ReadOnly = true;
            FDataGridView.AllowUserToAddRows = false;
            FDataGridView.KeyPress += FDataGridView_KeyPress;
            FDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            FDataGridView.CellDoubleClick += FDataGridView_CellDoubleClick;

            // Ordenació dels panells
            // http://stackoverflow.com/questions/154543/panel-dock-fill-ignoring-other-panel-dock-setting
            FBarraEines.BringToFront();
            FPanel.BringToFront();
            FDataGridView.BringToFront();
        }

        /// <summary>
        /// Fa visible el formulari en mode llista.
        /// </summary>
        public void Mostra()
        {
            FModalitatFormulari = ModalitatFormulari.Mostra;
            if (FClasseFitxa == null)
                tsbNou.Visible = false;
            ExecutaSQL();
            FForm.Show();
        }

        /// <summary>
        /// Es mostra el formulari en mode recerca (diàleg).
        /// </summary>
        public string Busca()
        {
            FModalitatFormulari = ModalitatFormulari.Busca;
            tsbNou.Visible = false;
            FForm.MdiParent = null;
            FForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            ExecutaSQL();
            FForm.ShowDialog();
            return ValorRetorn;
        }

        /// <summary>
        /// Indica la classe que fa de fitxa.
        /// </summary>
        /// <param name="classe">Classe que fa de fitxa.</param>
        public void AfegeixFitxa(Type classe)
        {
            FClasseFitxa = classe;
        }

        /// <summary>
        /// Afegeix el títol a la recerca.
        /// </summary>
        /// <param name="sTitol">Títol del formulari.</param>
        public void AfegeixTitol(String sTitol)
        {
            this.FForm.Text = sTitol;
        }

        /// <summary>
        /// Afegeix la SQL a la recerca. Si no s'expecifica, la construeix per defecte.
        /// </summary>
        /// <param name="sTitol">SQL del formulari.</param>
        public void AfegeixSQL(String sSQL)
        {
            this.SQL = sSQL;
        }
        
        /// <summary>
        /// Crea el panell de cerca.
        /// </summary>
        private void CreaPanellCerca()
        {
            lblCerca.AutoSize = true;
            lblCerca.Location = new Point(12, 16);
            lblCerca.Size = new Size(35, 13);
            lblCerca.Text = "Cerca";

            edtCerca.Location = new Point(53, 13);
            edtCerca.Size = new Size(FForm.Size.Width - 170, 20);
            edtCerca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            edtCerca.KeyDown += edtCerca_KeyDown;

            FPanel.Controls.Add(lblCerca);
            FPanel.Controls.Add(edtCerca);
            FPanel.Dock = DockStyle.Top;
            FPanel.Location = new Point(0, 31);
            FPanel.Size = new Size(628, 47);
            FForm.Controls.Add(FPanel);
        }

        private void tsbNou_Click(object sender, EventArgs e)
        {
            MethodInfo info = FClasseFitxa.GetMethod(
                "Alta",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            object value = info.Invoke(null, new object[] { FConnexio });

        }

        private void tsbDesa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No implementat.");
        }

        private void tsbElimina_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in FDataGridView.SelectedCells)
            {
                if (oneCell.Selected)
                    FBindingSource.RemoveAt(oneCell.RowIndex);
            }
            FBindingSource.EndEdit();
            SqlCommandBuilder cb = new SqlCommandBuilder(FSqlDataAdapter);
            if (FDataSet.HasChanges(DataRowState.Deleted))
                FSqlDataAdapter.Update((DataTable)FDataSet.Tables[FTaula]);
        }

        private void tsbActualitza_Click(object sender, EventArgs e)
        {
            ExecutaSQL();
        }

        private void tsbImprimeix_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No implementat.");
        }

        private void FForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                ExecutaSQL();
        }

        private void edtCerca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                ExecutaSQL();
            else if (e.KeyCode == Keys.Escape)
                edtCerca.Text = "";
        }

        private void FDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            edtCerca.Text += e.KeyChar;
            FForm.ActiveControl = edtCerca;
            edtCerca.Select(edtCerca.Text.Length, 0);
        }

        private void FDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            string sId;

            switch (FModalitatFormulari)
            {
                case ModalitatFormulari.Mostra:
                    if (FClasseFitxa == null) return;
                    foreach (DataGridViewCell oneCell in FDataGridView.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            sId = (FDataSet.Tables[FTaula].Rows[oneCell.RowIndex])[0].ToString();
                            id = Int32.Parse(sId);

                            // Usem Reflection (https://msdn.microsoft.com/en-us/library/mt656691.aspx)
                            // Jeff Richter shows that calling a method by reflection is about 1000 times slower than calling it normally.
                            // http://stackoverflow.com/questions/25458/how-costly-is-net-reflection
                            MethodInfo info = FClasseFitxa.GetMethod(
                                "Mostra",
                                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                            object value = info.Invoke(null, new object[] { FConnexio, id });
                        }
                    }
                    break;
                case ModalitatFormulari.Busca:
                    foreach (DataGridViewCell oneCell in FDataGridView.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            sId = (FDataSet.Tables[FTaula].Rows[oneCell.RowIndex])[0].ToString();
                            id = Int32.Parse(sId);
                            ValorRetorn = sId;
                        }
                    }
                    FForm.Close();
                    break;
            }
        }

        /// <summary>
        /// Construeix la sentència SQL, excepte si s'ha especificat amb AfegeixSQL.
        /// </summary>
        private string CreaSQL()
        {
            string sSQL;

            if (SQL == "")
            {
                sSQL = " SELECT * FROM " + FTaula + " WHERE (0=0) ";
                if (FCampsRecerca != "" && edtCerca.Text != "")
                {
                    sSQL += " AND ( ";
                    string[] asCampsRecerca = FCampsRecerca.Split(',');
                    for (int i = 0; i < asCampsRecerca.Length; i++)
                    {
                        if (i != 0)
                            sSQL += " OR ";
                        sSQL += asCampsRecerca[i].Trim() + " LIKE '%" + edtCerca.Text + "%' ";
                    }
                    sSQL += " ) ";
                }
            }
            else
                sSQL = SQL;
            return sSQL;
        }

        /// <summary>
        /// Executa la sentència SQL.
        /// </summary>
        private void ExecutaSQL()
        {
            FDataSet.Clear();
            FSqlDataAdapter = new SqlDataAdapter(CreaSQL(), FConnexio);
            FSqlDataAdapter.Fill(FDataSet, FTaula);
            FBindingSource.DataSource = FDataSet.Tables[FTaula];
            FDataGridView.DataSource = FBindingSource;
            //FDataGridView.AutoGenerateColumns = false;
            FDataSet.Tables[FTaula].Columns[FCampId].ColumnMapping = MappingType.Hidden;
            //FDataGridView.Refresh();
        }
    }

    /// <summary>
    /// Formularis de fitxa simple. 
    /// </summary>
    public class XFormFitxaSimpleConstructor : XFormConstructor
    {
        private const int MARGE_DRET = 18;
        private const int MARGE_ESQUERRE = 18;
        private const int MARGE_SUPERIOR = 20 + 30; // tbMenu=30
        private const int MARGE_INFERIOR = 16;
        private const int MRGZONES = 8;
        private const int ALTURA_BOTO = 25;
        private const int AMPLADA_BOTO = 74;
        private const int AMPLADA_ENTRE_ETIQUETA = 10; //< Amplada entre l'etiqueta (label) i l'objecte
        private const int AMPLADA_ENTRE_OBJECTES = 20; //< Amplada entre 2 objectes
        private const int ALTURA_ENTRE_OBJECTES = 24; //< Altura entre 2 objectes

        protected Form FForm;
        protected Panel FPanel;
        private ModalitatFormulari FModalitatFormulari;
        protected SqlConnection FConnexio;
        protected String FTaula;
        protected String FCampId;

        private SqlCommand FSqlCommand = new SqlCommand();
        protected BindingSource FBindingSource = new BindingSource();
        protected SqlDataAdapter FSqlDataAdapter = new SqlDataAdapter();
        protected DataSet FDataSet = new DataSet();
        protected DataTable FDataTable = new DataTable();

        protected int x, y;
        // Última posició de la coordenada X ocupada per un objecte.
        protected int iUltimaPosX;

        //private Type FClasseRecerca = null;


        /// <summary>
        /// Constructor de l'objecte.
        /// </summary>
        /// <param name="con">Connexió a la base de dades.</param>
        /// <param name="sTaula">Taula de la base de dades.</param>
        /// <param name="sCampId">Clau primària de la taula.</param>
        public XFormFitxaSimpleConstructor(SqlConnection con, String sTaula, String sCampId)
        {
            FConnexio = con;
            FForm = new Form();
            FForm.MdiParent = Application.OpenForms[0];
            FForm.Width = 400;
            FForm.Height = 400;
            FForm.StartPosition = FormStartPosition.CenterScreen;
            FTaula = sTaula;
            FCampId = sCampId;

            FPanel = new Panel();
            FPanel.Dock = DockStyle.Fill;
            FForm.Controls.Add(FPanel);

            x = MARGE_ESQUERRE;
            y = 14;
            iUltimaPosX = 0;
        }

        /// <summary>
        /// Afegeix un camp booleà en forma de CheckBox.
        /// </summary>
        /// <param name="sTitol">Títol del camp.</param>
        /// <param name="sCamp">Nom del camp (de la base de dades).</param>
        /// <param name="ffo">Opcions.</param>
        public void AfegeixBoolea(String sTitol, String sCamp, FormFitxaOpcions ffo = FormFitxaOpcions.Cap)
        {
            AfegeixEtiqueta(sTitol, ffo);

            CheckBox cb = new CheckBox();
            cb.DataBindings.Add("Checked", FBindingSource, sCamp, true);
            cb.Left = x + 100;
            cb.Top = y;
            //tb.Width = iLongitud;
            iUltimaPosX = x + cb.Width;
            //            ComprovaPrimerElement(obj);
            //            if not Encolumnat then
            y = y + ALTURA_ENTRE_OBJECTES;
            FPanel.Controls.Add(cb);
        }

        public void AfegeixEtiqueta(String sTitol, FormFitxaOpcions ffo = FormFitxaOpcions.Cap, int iTag = 0)
        {
            if ((ffo & FormFitxaOpcions.AlCostat) == FormFitxaOpcions.AlCostat)
            {
                x = iUltimaPosX;
                // Si no hi ha label, no cal tant d'espai
                if (sTitol != "")
                    x = x + AMPLADA_ENTRE_OBJECTES;
                y = y - ALTURA_ENTRE_OBJECTES;
            }
            else
                x = 0;

            Label lbl = new Label();
            lbl.Text = sTitol;
            lbl.Left = x;
            lbl.Top = y + 4;
            lbl.AutoSize = true;
            FPanel.Controls.Add(lbl);

            if ((ffo & FormFitxaOpcions.AlCostat) == FormFitxaOpcions.AlCostat)
            {
                SizeF size = lbl.CreateGraphics().MeasureString(lbl.Text, lbl.Font);
                x = x + (int)size.Width + AMPLADA_ENTRE_ETIQUETA;
            }
            else
                x = x + 50;
        }

        public void AfegeixCadena(String sTitol, String sCamp, int iLongitud, FormFitxaOpcions ffo = FormFitxaOpcions.Cap)
        {
            AfegeixEtiqueta(sTitol, ffo);

            TextBox tb = new TextBox();
            tb.DataBindings.Add("Text", FBindingSource, sCamp, true);
            tb.Left = x + 100;
            tb.Top = y;
            tb.Width = iLongitud;
            iUltimaPosX = x + tb.Width;
            //            ComprovaPrimerElement(obj);
            //            if not Encolumnat then
            y = y + ALTURA_ENTRE_OBJECTES;
            FPanel.Controls.Add(tb);
        }

        public void AfegeixData(String sTitol, String sCamp, FormFitxaOpcions ffo = FormFitxaOpcions.Cap)
        {
            AfegeixEtiqueta(sTitol, ffo);

            DateTimePicker tb = new DateTimePicker();
            tb.DataBindings.Add("Text", FBindingSource, sCamp, true);
            tb.Left = x + 100;
            tb.Top = y;
            iUltimaPosX = x + tb.Width;
            //            ComprovaPrimerElement(obj);
            //            if not Encolumnat then
            y = y + ALTURA_ENTRE_OBJECTES;
            FPanel.Controls.Add(tb);
        }

        /// <summary>
        /// Afegeix un espai vertical entre els controls.
        /// </summary>
        /// <param name="iEspai">Espai en píxels.</param>
        public void AfegeixEspai(int iEspai = ALTURA_ENTRE_OBJECTES)
        {
            y = y + iEspai;
        }

        /// <summary>
        /// Afegeix un desplegable amb una llista d'opcions. Les opcions tenen el format clau-valor.
        /// </summary>
        /// <param name="sTitol">Etiqueta del desplegable.</param>
        /// <param name="sCamp">Nom del camp de la base de dades.</param>
        /// <param name="iLongitud">Amplada del desplegable.</param>
        /// <param name="Codis">Llista de codis (valor intern que es desarà a la base de dades) del desplegable.</param>
        /// <param name="Codis">Llista de valors que es mostraran al desplegable.</param>
        public void AfegeixLlista(String sTitol, String sCamp, int iLongitud, int[] Codis, string[] Valors, FormFitxaOpcions ffo = FormFitxaOpcions.Cap)
        {
            AfegeixEtiqueta(sTitol, ffo);

            ComboBox cb = new ComboBox();
            cb.DataBindings.Add(new Binding("SelectedValue", FBindingSource, sCamp, true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Left = x + 100;
            cb.Top = y;
            iUltimaPosX = x + cb.Width;

            DataTable dsTbl = new DataTable("ds"+ sCamp);
            dsTbl.Columns.Add("key", typeof(string));
            dsTbl.Columns.Add("value", typeof(string));
            // Iterem 2 arrays amb un sol bucle
            // http://stackoverflow.com/questions/1955766/iterate-two-lists-or-arrays-with-one-foreach-statement-in-c-sharp
            foreach (var CodiValor in Codis.Zip(Valors, Tuple.Create))
            {
                object[] row = new object[2];
                row[0] = CodiValor.Item1;
                row[1] = CodiValor.Item2;
                dsTbl.Rows.Add(row);
            }
            cb.DataSource = dsTbl;
            cb.ValueMember = "key";
            cb.DisplayMember = "value";

            y = y + ALTURA_ENTRE_OBJECTES;
            FPanel.Controls.Add(cb);
        }

        public void AfegeixLlistaDB(String sTitol, String sCamp, int iLongitud, String sTaula, String sCampClau, String sCampValor, Type ClasseRecerca, FormFitxaOpcions ffo = FormFitxaOpcions.Cap)
        {
            AfegeixEtiqueta(sTitol, ffo);

            XEditLookup eb = new XEditLookup();
            eb.Connexio = FConnexio;
            eb.Taula = sTaula;
            eb.CampClau = sCampClau;
            eb.CampValor = sCampValor;
            eb.DataBindings.Add("Text", FBindingSource, sCamp, true);
            eb.Left = x + 100;
            eb.Top = y;
            iUltimaPosX = x + eb.Width;
            eb.ButtonClick += eb_Click;
            eb.ClasseRecerca = ClasseRecerca;
            //FClasseRecerca = ClasseRecerca;
            //            ComprovaPrimerElement(obj);
            //            if not Encolumnat then
            y = y + ALTURA_ENTRE_OBJECTES;
            FPanel.Controls.Add(eb);
        }

        private int AmpladaLabelMesLlarg(Panel pnl)
        {
            int i, iAmplada = 0;

            for (i=0; i<FPanel.Controls.Count; i++)
            {
                if ((FPanel.Controls[i] is Label) && (FPanel.Controls[i].Left == MARGE_ESQUERRE) /*&& (FPanel.Controls[i].Tag == 0)*/)
                    iAmplada = Math.Max(iAmplada, FPanel.Controls[i].Width);
            }
            /* 
             *var
    i: integer;
begin
    Result := 0;
    // Cerquem el label més llarg de la 1a columna
    for i := 0 to pnl.ControlCount - 1 do
        if (pnl.Controls[i] is TLabel) and (TLabel(pnl.Controls[i]).Left = 0) and (TLabel(pnl.Controls[i]).Tag = 0) then
            Result := Max(Result, TLabel(pnl.Controls[i]).Width);
             */
            return iAmplada;
        }

        private void GestionaGeometria()
        {
            int i, xMax, yMax, xPanelMax;

            // Cerquem el label més llarg de la 1a columna
            xMax = AmpladaLabelMesLlarg(FPanel);

            // Desplacem els altres components la distància del label més llarg
            xMax = xMax - 50;
            for (i = 0; i < FPanel.Controls.Count; i++)
                if (!((FPanel.Controls[i] is Label) && (FPanel.Controls[i]).Left == 0) && !(FPanel.Controls[i] is Panel)) {
                    FPanel.Controls[i].Left = FPanel.Controls[i].Left + xMax + AMPLADA_ENTRE_ETIQUETA;
                }

            // Dimensiona la finestra
            xMax = 0;
            yMax = 0;
            for (i = 0; i < FPanel.Controls.Count; i++)
            {
                xMax = Math.Max(xMax, FPanel.Controls[i].Left + FPanel.Controls[i].Width);
                yMax = Math.Max(yMax, FPanel.Controls[i].Top + FPanel.Controls[i].Height);
            }
            FForm.Width = MARGE_DRET + xMax + MARGE_ESQUERRE + 8;
            FForm.Height = MARGE_SUPERIOR + yMax + MARGE_INFERIOR + ALTURA_BOTO + MRGZONES + 32;
                 


            /*          var
              i: integer;
                      xMax, yMax, xPanelMax: integer;
                      begin
                          // Cerquem el label més llarg de la 1a columna
                          xMax := AmpladaLabelMesLlarg(pnl);

                  // Cerquem els panels que formen les columnes i els hi gestionem la geometria
                  xPanelMax:= 0;
                      for i := 0 to pnl.ControlCount - 1 do
                              if (pnl.Controls[i] is TPanel) then
                      if (TPanel(pnl.Controls[i]).Left = 0) then
                          GestionaGeometriaPanel(TPanel(pnl.Controls[i]), xPanelMax, xMax)
                      else
                          GestionaGeometriaPanel(TPanel(pnl.Controls[i]), xPanelMax);

                  // Desplacem els altres components la distància del label més llarg
                  xMax:= xMax - 50;
                      for i := 0 to pnl.ControlCount - 1 do
                              if not((pnl.Controls[i] is TLabel) and(TLabel(pnl.Controls[i]).Left = 0)) and not (pnl.Controls[i] is TPanel) then

                                pnl.Controls[i].Left := pnl.Controls[i].Left + xMax + AMPLADA_ENTRE_ETIQUETA;

                  // Dimensiona la finestra
                  xMax:= 0;
                  yMax:= 0;
                      for i := 0 to pnl.ControlCount - 1 do
                              begin
                                  xMax := Max(xMax, pnl.Controls[i].Left + pnl.Controls[i].Width);
                  yMax:= Max(yMax, pnl.Controls[i].Top + pnl.Controls[i].Height);
                      end;
                  Width:= MARGE_DRET + xMax + MARGE_ESQUERRE + 8;
                  Height:= MARGE_SUPERIOR + yMax + MARGE_INFERIOR + ALTURA_BOTO + MRGZONES + 32;*/
        }

        private void eb_Click(object sender, EventArgs e)
        {
            XEditLookup lkp;
            lkp = (sender as Button).Parent as XEditLookup;

            // MethodBase.Invoke Method (Object, Object[])
            // https://msdn.microsoft.com/en-us/library/a89hcwhh(v=vs.110).aspx
//            MethodInfo info = FClasseRecerca.GetMethod("Busca");
            MethodInfo info = lkp.ClasseRecerca.GetMethod("Busca");
            object value = info.Invoke(null, new object[] { FConnexio });
            //string s = value as string;
            //FForm.Close();

            if (sender is Button)
            {
                lkp = (sender as Button).Parent as XEditLookup;
                lkp.Clau = value as string; 
            }
        }

        private void CreaBotons()
        {
            Button btnAccepta = new Button();
            btnAccepta.Text = "Accepta";
            btnAccepta.Left = FForm.Width - 200;
            btnAccepta.Width = 75;
            btnAccepta.Top = FForm.Height - 80;
            FPanel.Controls.Add(btnAccepta);
            btnAccepta.Click += btnAccepta_Click;

            Button btnCancella = new Button();
            btnCancella.Text = "Cancel·la";
            btnCancella.Left = FForm.Width - 100;
            btnCancella.Width = 75;
            btnCancella.Top = FForm.Height - 80;
            FPanel.Controls.Add(btnCancella);
            btnCancella.Click += btnCancella_Click;
        }

        private void btnAccepta_Click(object sender, EventArgs e)
        {
            switch (FModalitatFormulari)
            {
                case ModalitatFormulari.Mostra:
                    break;
                case ModalitatFormulari.Alta:
                    break;
            }
            FBindingSource.EndEdit();
            SqlCommandBuilder cb = new SqlCommandBuilder(FSqlDataAdapter);
            FSqlDataAdapter.Update(FDataTable);
            FForm.Close();
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            FForm.Close();
        }

        public void Mostra(int id)
        {
            FModalitatFormulari = ModalitatFormulari.Mostra;
            GestionaGeometria();
            CreaBotons();

            FSqlDataAdapter = new SqlDataAdapter("SELECT * FROM " + FTaula + " WHERE " + FCampId + "=" + id.ToString(), FConnexio);
            FSqlDataAdapter.Fill(FDataTable);
            FBindingSource.DataSource = FDataTable;

            FForm.Visible = true;
        }

        public void Alta()
        {
            FModalitatFormulari = ModalitatFormulari.Alta;
            GestionaGeometria();
            CreaBotons();

            FSqlDataAdapter = new SqlDataAdapter("SELECT * FROM " + FTaula + " WHERE 0=1", FConnexio);
            FSqlDataAdapter.Fill(FDataTable);
            FBindingSource.DataSource = FDataTable;
            FBindingSource.AddNew();

            FForm.Visible = true;
        }
    }

    /// <summary>
    /// Formularis de recerca que es poden entrar dades.</summary>
    /// <remarks>
    /// Per a taules senzilles que no cal fer fitxa.</remarks>
    public class XFormRecercaFitxaConstructor : XFormRecercaConstructor
    {
        /// <summary>
        /// Constructor de l'objecte.
        /// </summary>
        /// <param name="con">Connexió a la base de dades.</param>
        /// <param name="sTaula">Taula de la base de dades.</param>
        /// <param name="sCampId">Clau primària de la taula.</param>
        /// <param name="sCampsRecerca">Llistat de camps per fer la recerca separats per comes.</param>
        public XFormRecercaFitxaConstructor(SqlConnection con, String sTaula, String sCampId, String sCampsRecerca) : base(con, sTaula, sCampId, sCampsRecerca)
        {
            FForm.Width = 400;
            FForm.Height = 600;
            tsbDesa.Visible = false;
            tsbActualitza.Visible = false;
            tsbFiltre.Visible = false;
            tsbOpcions.Visible = false;

            // Ordenació dels panells
            // http://stackoverflow.com/questions/154543/panel-dock-fill-ignoring-other-panel-dock-setting
            FDataGridView.BringToFront();

            FDataGridView.ReadOnly = false;
            FDataGridView.AllowUserToAddRows = true;
            FDataGridView.KeyPress += null;
            FDataGridView.RowLeave += new DataGridViewCellEventHandler(DataGridView_RowLeave);
            FPanel.Visible = false;
        }

        private void DataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            FForm.Validate();
            FDataGridView.EndEdit();
            SqlCommandBuilder cb = new SqlCommandBuilder(FSqlDataAdapter);
            if (FDataSet.HasChanges(DataRowState.Modified | DataRowState.Added))
                FSqlDataAdapter.Update((DataTable)FDataSet.Tables[FTaula]);
        }
    }
}