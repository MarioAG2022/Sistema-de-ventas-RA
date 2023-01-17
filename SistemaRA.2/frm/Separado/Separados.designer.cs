namespace SistemaRA._2.frm
{
    partial class Separados
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbSeleccionar = new System.Windows.Forms.ComboBox();
            this.lbnombre = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(851, 492);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrar separado";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 107);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(961, 356);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // cbSeleccionar
            // 
            this.cbSeleccionar.FormattingEnabled = true;
            this.cbSeleccionar.Items.AddRange(new object[] {
            "Por Cliente",
            "Por Fecha Limite",
            "Por Fecha de Registro"});
            this.cbSeleccionar.Location = new System.Drawing.Point(151, 60);
            this.cbSeleccionar.Margin = new System.Windows.Forms.Padding(4);
            this.cbSeleccionar.Name = "cbSeleccionar";
            this.cbSeleccionar.Size = new System.Drawing.Size(176, 24);
            this.cbSeleccionar.TabIndex = 44;
            this.cbSeleccionar.Text = "       ----Seleccionar----";
            // 
            // lbnombre
            // 
            this.lbnombre.AutoSize = true;
            this.lbnombre.Location = new System.Drawing.Point(972, 28);
            this.lbnombre.Name = "lbnombre";
            this.lbnombre.Size = new System.Drawing.Size(0, 17);
            this.lbnombre.TabIndex = 45;
            this.lbnombre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbnombre.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(334, 62);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(171, 22);
            this.txtBuscar.TabIndex = 46;
            this.txtBuscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Separados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lbnombre);
            this.Controls.Add(this.cbSeleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Separados";
            this.Text = "RegistrarSeparado";
            this.Load += new System.EventHandler(this.Separados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSeleccionar;
        private System.Windows.Forms.Label lbnombre;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}