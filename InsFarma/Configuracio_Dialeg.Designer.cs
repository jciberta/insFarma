namespace InsFarma
{
    partial class FrmConfiguracioDialeg
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
            this.components = new System.ComponentModel.Container();
            this.btnDAcord = new System.Windows.Forms.Button();
            this.btnCancella = new System.Windows.Forms.Button();
            this.edtNomComercial = new System.Windows.Forms.TextBox();
            this.sISTEMABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fIPDataSet = new InsFarma.FIPDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.sISTEMATableAdapter = new InsFarma.FIPDataSetTableAdapters.SISTEMATableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sISTEMABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDAcord
            // 
            this.btnDAcord.Location = new System.Drawing.Point(488, 444);
            this.btnDAcord.Name = "btnDAcord";
            this.btnDAcord.Size = new System.Drawing.Size(75, 23);
            this.btnDAcord.TabIndex = 0;
            this.btnDAcord.Text = "D\'acord";
            this.btnDAcord.UseVisualStyleBackColor = true;
            this.btnDAcord.Click += new System.EventHandler(this.btnDAcord_Click);
            // 
            // btnCancella
            // 
            this.btnCancella.Location = new System.Drawing.Point(569, 444);
            this.btnCancella.Name = "btnCancella";
            this.btnCancella.Size = new System.Drawing.Size(75, 23);
            this.btnCancella.TabIndex = 1;
            this.btnCancella.Text = "Cancel·la";
            this.btnCancella.UseVisualStyleBackColor = true;
            this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
            // 
            // edtNomComercial
            // 
            this.edtNomComercial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "nom_comercial", true));
            this.edtNomComercial.Location = new System.Drawing.Point(112, 38);
            this.edtNomComercial.Name = "edtNomComercial";
            this.edtNomComercial.Size = new System.Drawing.Size(532, 20);
            this.edtNomComercial.TabIndex = 2;
            // 
            // sISTEMABindingSource
            // 
            this.sISTEMABindingSource.DataMember = "SISTEMA";
            this.sISTEMABindingSource.DataSource = this.fIPDataSet;
            // 
            // fIPDataSet
            // 
            this.fIPDataSet.DataSetName = "FIPDataSet";
            this.fIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom comercial:";
            // 
            // sISTEMATableAdapter
            // 
            this.sISTEMATableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "nom_fiscal", true));
            this.textBox1.Location = new System.Drawing.Point(112, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(532, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nom fiscal:";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "nif", true));
            this.textBox2.Location = new System.Drawing.Point(112, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "NIF:";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "adresa", true));
            this.textBox3.Location = new System.Drawing.Point(112, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(532, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "adresa", true));
            this.textBox4.Location = new System.Drawing.Point(217, 161);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(427, 20);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sISTEMABindingSource, "nif", true));
            this.textBox5.Location = new System.Drawing.Point(112, 161);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(99, 20);
            this.textBox5.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Població:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Adreça:";
            // 
            // FrmConfiguracioDialeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 493);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtNomComercial);
            this.Controls.Add(this.btnCancella);
            this.Controls.Add(this.btnDAcord);
            this.Name = "FrmConfiguracioDialeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuració del sistema";
            this.Load += new System.EventHandler(this.FrmConfiguracioDialeg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sISTEMABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDAcord;
        private System.Windows.Forms.Button btnCancella;
        private System.Windows.Forms.TextBox edtNomComercial;
        private System.Windows.Forms.Label label1;
        private FIPDataSet fIPDataSet;
        private System.Windows.Forms.BindingSource sISTEMABindingSource;
        private FIPDataSetTableAdapters.SISTEMATableAdapter sISTEMATableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}