namespace InsFarma
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fitxerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classificacióAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.administracióToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracióToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magatzemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.famíliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finestraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitxerToolStripMenuItem,
            this.magatzemToolStripMenuItem,
            this.vendesToolStripMenuItem,
            this.compresToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.finestraToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fitxerToolStripMenuItem
            // 
            this.fitxerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaToolStripMenuItem,
            this.classificacióAgendaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.administracióToolStripMenuItem});
            this.fitxerToolStripMenuItem.Name = "fitxerToolStripMenuItem";
            this.fitxerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fitxerToolStripMenuItem.Text = "&Fitxer";
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.agendaToolStripMenuItem.Text = "Agenda";
            this.agendaToolStripMenuItem.Click += new System.EventHandler(this.agendaToolStripMenuItem_Click);
            // 
            // classificacióAgendaToolStripMenuItem
            // 
            this.classificacióAgendaToolStripMenuItem.Name = "classificacióAgendaToolStripMenuItem";
            this.classificacióAgendaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.classificacióAgendaToolStripMenuItem.Text = "Classificació agenda";
            this.classificacióAgendaToolStripMenuItem.Click += new System.EventHandler(this.classificacióAgendaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // administracióToolStripMenuItem
            // 
            this.administracióToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracióToolStripMenuItem});
            this.administracióToolStripMenuItem.Name = "administracióToolStripMenuItem";
            this.administracióToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.administracióToolStripMenuItem.Text = "Administració";
            // 
            // configuracióToolStripMenuItem
            // 
            this.configuracióToolStripMenuItem.Name = "configuracióToolStripMenuItem";
            this.configuracióToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.configuracióToolStripMenuItem.Text = "Configuració";
            this.configuracióToolStripMenuItem.Click += new System.EventHandler(this.configuracióToolStripMenuItem_Click);
            // 
            // magatzemToolStripMenuItem
            // 
            this.magatzemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marquesToolStripMenuItem,
            this.famíliesToolStripMenuItem,
            this.articlesToolStripMenuItem});
            this.magatzemToolStripMenuItem.Name = "magatzemToolStripMenuItem";
            this.magatzemToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.magatzemToolStripMenuItem.Text = "&Magatzem";
            // 
            // marquesToolStripMenuItem
            // 
            this.marquesToolStripMenuItem.Name = "marquesToolStripMenuItem";
            this.marquesToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.marquesToolStripMenuItem.Text = "Marques";
            this.marquesToolStripMenuItem.Click += new System.EventHandler(this.marquesToolStripMenuItem_Click);
            // 
            // famíliesToolStripMenuItem
            // 
            this.famíliesToolStripMenuItem.Name = "famíliesToolStripMenuItem";
            this.famíliesToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.famíliesToolStripMenuItem.Text = "Famílies";
            this.famíliesToolStripMenuItem.Click += new System.EventHandler(this.famíliesToolStripMenuItem_Click);
            // 
            // articlesToolStripMenuItem
            // 
            this.articlesToolStripMenuItem.Name = "articlesToolStripMenuItem";
            this.articlesToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.articlesToolStripMenuItem.Text = "Articles";
            this.articlesToolStripMenuItem.Click += new System.EventHandler(this.articlesToolStripMenuItem_Click);
            // 
            // vendesToolStripMenuItem
            // 
            this.vendesToolStripMenuItem.Name = "vendesToolStripMenuItem";
            this.vendesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.vendesToolStripMenuItem.Text = "&Vendes";
            // 
            // compresToolStripMenuItem
            // 
            this.compresToolStripMenuItem.Name = "compresToolStripMenuItem";
            this.compresToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.compresToolStripMenuItem.Text = "&Compres";
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "&Informes";
            // 
            // finestraToolStripMenuItem
            // 
            this.finestraToolStripMenuItem.Name = "finestraToolStripMenuItem";
            this.finestraToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.finestraToolStripMenuItem.Text = "Finestra";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quantAToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "&Ajuda";
            // 
            // quantAToolStripMenuItem
            // 
            this.quantAToolStripMenuItem.Name = "quantAToolStripMenuItem";
            this.quantAToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.quantAToolStripMenuItem.Text = "&Quant a...";
            this.quantAToolStripMenuItem.Click += new System.EventHandler(this.quantAToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 313);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "insFarma";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fitxerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magatzemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quantAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracióToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracióToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marquesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem famíliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classificacióAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem articlesToolStripMenuItem;
    }
}

