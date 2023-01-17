namespace SistemaRA._2.frm.Productos
{
    partial class FrmReporteInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteInventario));
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dataGridViewInv = new System.Windows.Forms.DataGridView();
            this.cmbBuscar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconcerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 49;
            this.label4.Text = "BUSCAR :";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(404, 39);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(257, 22);
            this.txtBuscar.TabIndex = 60;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtRMbuscar_TextChanged);
            // 
            // dataGridViewInv
            // 
            this.dataGridViewInv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridViewInv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridViewInv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInv.ColumnHeadersHeight = 30;
            this.dataGridViewInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewInv.EnableHeadersVisualStyles = false;
            this.dataGridViewInv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.dataGridViewInv.Location = new System.Drawing.Point(32, 81);
            this.dataGridViewInv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInv.Name = "dataGridViewInv";
            this.dataGridViewInv.ReadOnly = true;
            this.dataGridViewInv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(148)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewInv.RowHeadersVisible = false;
            this.dataGridViewInv.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(139)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewInv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewInv.RowTemplate.Height = 24;
            this.dataGridViewInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInv.Size = new System.Drawing.Size(1313, 581);
            this.dataGridViewInv.TabIndex = 62;
            this.dataGridViewInv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInv_CellContentClick);
            this.dataGridViewInv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewInv_CellFormatting);
            // 
            // cmbBuscar
            // 
            this.cmbBuscar.FormattingEnabled = true;
            this.cmbBuscar.Items.AddRange(new object[] {
            "Por nombre",
            "Por descripcion",
            "Por marca"});
            this.cmbBuscar.Location = new System.Drawing.Point(137, 36);
            this.cmbBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuscar.Name = "cmbBuscar";
            this.cmbBuscar.Size = new System.Drawing.Size(160, 24);
            this.cmbBuscar.TabIndex = 63;
            this.cmbBuscar.Text = "Por nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 64;
            this.label1.Text = "BUSCAR POR:";
            // 
            // iconcerrar
            // 
            this.iconcerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconcerrar.Image = ((System.Drawing.Image)(resources.GetObject("iconcerrar.Image")));
            this.iconcerrar.Location = new System.Drawing.Point(1347, 12);
            this.iconcerrar.Name = "iconcerrar";
            this.iconcerrar.Size = new System.Drawing.Size(20, 20);
            this.iconcerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconcerrar.TabIndex = 84;
            this.iconcerrar.TabStop = false;
            this.iconcerrar.Visible = false;
            this.iconcerrar.Click += new System.EventHandler(this.iconcerrar_Click);
            // 
            // FrmReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1379, 690);
            this.Controls.Add(this.iconcerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBuscar);
            this.Controls.Add(this.dataGridViewInv);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReporteInventario";
            this.Text = "FrmReporteInventario";
            this.Load += new System.EventHandler(this.FrmReporteInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dataGridViewInv;
        private System.Windows.Forms.ComboBox cmbBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox iconcerrar;
    }
}