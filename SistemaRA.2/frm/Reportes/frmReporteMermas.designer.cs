namespace SistemaRA._2.frm
{
    partial class frmReporteMermas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMermas));
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewmermaRe = new System.Windows.Forms.DataGridView();
            this.txtRMbuscar = new System.Windows.Forms.TextBox();
            this.lbtotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmermaRe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 48;
            this.label4.Text = "Generar por fecha:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridViewmermaRe
            // 
            this.dataGridViewmermaRe.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridViewmermaRe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewmermaRe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewmermaRe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridViewmermaRe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewmermaRe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewmermaRe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewmermaRe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewmermaRe.ColumnHeadersHeight = 30;
            this.dataGridViewmermaRe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewmermaRe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewmermaRe.EnableHeadersVisualStyles = false;
            this.dataGridViewmermaRe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.dataGridViewmermaRe.Location = new System.Drawing.Point(40, 114);
            this.dataGridViewmermaRe.Name = "dataGridViewmermaRe";
            this.dataGridViewmermaRe.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(148)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewmermaRe.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewmermaRe.RowHeadersVisible = false;
            this.dataGridViewmermaRe.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(139)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewmermaRe.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewmermaRe.RowTemplate.Height = 24;
            this.dataGridViewmermaRe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewmermaRe.Size = new System.Drawing.Size(936, 369);
            this.dataGridViewmermaRe.TabIndex = 57;
            this.dataGridViewmermaRe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewmermaRe_CellContentClick);
            // 
            // txtRMbuscar
            // 
            this.txtRMbuscar.Location = new System.Drawing.Point(182, 43);
            this.txtRMbuscar.MaxLength = 10;
            this.txtRMbuscar.Name = "txtRMbuscar";
            this.txtRMbuscar.Size = new System.Drawing.Size(148, 22);
            this.txtRMbuscar.TabIndex = 59;
            this.txtRMbuscar.Text = "00/00/0000";
            this.txtRMbuscar.TextChanged += new System.EventHandler(this.txtRMbuscar_TextChanged);
            this.txtRMbuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRMbuscar_KeyPress);
            // 
            // lbtotal
            // 
            this.lbtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtotal.AutoSize = true;
            this.lbtotal.Location = new System.Drawing.Point(909, 520);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(46, 17);
            this.lbtotal.TabIndex = 75;
            this.lbtotal.Text = "lbtotal";
            this.lbtotal.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(794, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 74;
            this.label1.Text = "Perdidas";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpleado.Location = new System.Drawing.Point(348, 82);
            this.txtEmpleado.MaxLength = 50;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(148, 22);
            this.txtEmpleado.TabIndex = 77;
            this.txtEmpleado.TextChanged += new System.EventHandler(this.txtEmpleado_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 76;
            this.label2.Text = "Buscar por:";
            // 
            // cbBuscar
            // 
            this.cbBuscar.FormattingEnabled = true;
            this.cbBuscar.Items.AddRange(new object[] {
            "Por producto",
            "Por Empleado"});
            this.cbBuscar.Location = new System.Drawing.Point(182, 80);
            this.cbBuscar.Name = "cbBuscar";
            this.cbBuscar.Size = new System.Drawing.Size(148, 24);
            this.cbBuscar.TabIndex = 78;
            this.cbBuscar.Text = "--Seleccionar---";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(348, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmReporteMermas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1017, 563);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbBuscar);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbtotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRMbuscar);
            this.Controls.Add(this.dataGridViewmermaRe);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteMermas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteMermas";
            this.Load += new System.EventHandler(this.frmReporteMermas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmermaRe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewmermaRe;
        private System.Windows.Forms.TextBox txtRMbuscar;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}