
namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    partial class BUSCAR_PRODUCTO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BUSCAR_PRODUCTO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLineas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrincipio = new System.Windows.Forms.TextBox();
            this.txtAccion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.rdPrincipio = new System.Windows.Forms.RadioButton();
            this.rdAccion = new System.Windows.Forms.RadioButton();
            this.rdCodigo = new System.Windows.Forms.RadioButton();
            this.rdDescripcion = new System.Windows.Forms.RadioButton();
            this.dataProductos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProductos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cmbLineas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPrincipio);
            this.panel1.Controls.Add(this.txtAccion);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.rdPrincipio);
            this.panel1.Controls.Add(this.rdAccion);
            this.panel1.Controls.Add(this.rdCodigo);
            this.panel1.Controls.Add(this.rdDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 76);
            this.panel1.TabIndex = 0;
            // 
            // cmbLineas
            // 
            this.cmbLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineas.FormattingEnabled = true;
            this.cmbLineas.Location = new System.Drawing.Point(622, 39);
            this.cmbLineas.Name = "cmbLineas";
            this.cmbLineas.Size = new System.Drawing.Size(140, 21);
            this.cmbLineas.TabIndex = 10;
            this.cmbLineas.SelectedIndexChanged += new System.EventHandler(this.cmbLineas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Línea";
            // 
            // txtPrincipio
            // 
            this.txtPrincipio.Enabled = false;
            this.txtPrincipio.Location = new System.Drawing.Point(476, 39);
            this.txtPrincipio.Name = "txtPrincipio";
            this.txtPrincipio.Size = new System.Drawing.Size(140, 20);
            this.txtPrincipio.TabIndex = 8;
            this.txtPrincipio.TextChanged += new System.EventHandler(this.txtPrincipio_TextChanged);
            // 
            // txtAccion
            // 
            this.txtAccion.Enabled = false;
            this.txtAccion.Location = new System.Drawing.Point(330, 39);
            this.txtAccion.Name = "txtAccion";
            this.txtAccion.Size = new System.Drawing.Size(140, 20);
            this.txtAccion.TabIndex = 7;
            this.txtAccion.TextChanged += new System.EventHandler(this.txtAccion_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(184, 39);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(140, 20);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(38, 39);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(140, 20);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // rdPrincipio
            // 
            this.rdPrincipio.AutoSize = true;
            this.rdPrincipio.Location = new System.Drawing.Point(476, 16);
            this.rdPrincipio.Name = "rdPrincipio";
            this.rdPrincipio.Size = new System.Drawing.Size(97, 17);
            this.rdPrincipio.TabIndex = 4;
            this.rdPrincipio.Text = "Principio activo";
            this.rdPrincipio.UseVisualStyleBackColor = true;
            this.rdPrincipio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdAccion
            // 
            this.rdAccion.AutoSize = true;
            this.rdAccion.Location = new System.Drawing.Point(330, 16);
            this.rdAccion.Name = "rdAccion";
            this.rdAccion.Size = new System.Drawing.Size(114, 17);
            this.rdAccion.TabIndex = 3;
            this.rdAccion.Text = "Acción terapeútica";
            this.rdAccion.UseVisualStyleBackColor = true;
            this.rdAccion.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // rdCodigo
            // 
            this.rdCodigo.AutoSize = true;
            this.rdCodigo.Location = new System.Drawing.Point(184, 16);
            this.rdCodigo.Name = "rdCodigo";
            this.rdCodigo.Size = new System.Drawing.Size(58, 17);
            this.rdCodigo.TabIndex = 2;
            this.rdCodigo.Text = "Código";
            this.rdCodigo.UseVisualStyleBackColor = true;
            this.rdCodigo.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rdDescripcion
            // 
            this.rdDescripcion.AutoSize = true;
            this.rdDescripcion.Checked = true;
            this.rdDescripcion.Location = new System.Drawing.Point(38, 16);
            this.rdDescripcion.Name = "rdDescripcion";
            this.rdDescripcion.Size = new System.Drawing.Size(81, 17);
            this.rdDescripcion.TabIndex = 0;
            this.rdDescripcion.TabStop = true;
            this.rdDescripcion.Text = "Descripción";
            this.rdDescripcion.UseVisualStyleBackColor = true;
            this.rdDescripcion.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dataProductos
            // 
            this.dataProductos.AllowUserToAddRows = false;
            this.dataProductos.AllowUserToDeleteRows = false;
            this.dataProductos.AllowUserToResizeRows = false;
            this.dataProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProductos.BackgroundColor = System.Drawing.Color.White;
            this.dataProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProductos.Location = new System.Drawing.Point(0, 82);
            this.dataProductos.Name = "dataProductos";
            this.dataProductos.RowHeadersVisible = false;
            this.dataProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataProductos.Size = new System.Drawing.Size(800, 328);
            this.dataProductos.TabIndex = 1;
            this.dataProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProductos_CellDoubleClick);
            this.dataProductos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataProductos_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 416);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 34);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Stock mínimo";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(133)))));
            this.panel4.Location = new System.Drawing.Point(112, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sin stock";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.panel3.Location = new System.Drawing.Point(14, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 0;
            // 
            // BUSCAR_PRODUCTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataProductos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BUSCAR_PRODUCTO";
            this.Text = "Buscar producto";
            this.Load += new System.EventHandler(this.BUSCAR_PRODUCTO_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdAccion;
        private System.Windows.Forms.RadioButton rdCodigo;
        private System.Windows.Forms.RadioButton rdDescripcion;
        private System.Windows.Forms.TextBox txtPrincipio;
        private System.Windows.Forms.TextBox txtAccion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.RadioButton rdPrincipio;
        private System.Windows.Forms.ComboBox cmbLineas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataProductos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
    }
}