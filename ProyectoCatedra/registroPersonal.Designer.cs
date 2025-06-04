namespace ProyectoCatedra
{
    partial class registroPersonal
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
            this.dataGridViewPersonal = new System.Windows.Forms.DataGridView();
            this.btnEliminarPersonal = new System.Windows.Forms.Button();
            this.btnModificarPersonal = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAgregarPersonal = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPersonal
            // 
            this.dataGridViewPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersonal.Location = new System.Drawing.Point(13, 50);
            this.dataGridViewPersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPersonal.Name = "dataGridViewPersonal";
            this.dataGridViewPersonal.RowHeadersWidth = 51;
            this.dataGridViewPersonal.Size = new System.Drawing.Size(999, 562);
            this.dataGridViewPersonal.TabIndex = 6;
            this.dataGridViewPersonal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPersonal_CellContentClick);
            // 
            // btnEliminarPersonal
            // 
            this.btnEliminarPersonal.BackColor = System.Drawing.Color.Brown;
            this.btnEliminarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarPersonal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarPersonal.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPersonal.Location = new System.Drawing.Point(717, 14);
            this.btnEliminarPersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarPersonal.Name = "btnEliminarPersonal";
            this.btnEliminarPersonal.Size = new System.Drawing.Size(113, 27);
            this.btnEliminarPersonal.TabIndex = 5;
            this.btnEliminarPersonal.Text = "Eliminar";
            this.btnEliminarPersonal.UseVisualStyleBackColor = false;
            this.btnEliminarPersonal.Click += new System.EventHandler(this.btnEliminarPersonal_Click);
            // 
            // btnModificarPersonal
            // 
            this.btnModificarPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnModificarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPersonal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnModificarPersonal.Location = new System.Drawing.Point(477, 14);
            this.btnModificarPersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificarPersonal.Name = "btnModificarPersonal";
            this.btnModificarPersonal.Size = new System.Drawing.Size(113, 27);
            this.btnModificarPersonal.TabIndex = 3;
            this.btnModificarPersonal.Text = "Modificar";
            this.btnModificarPersonal.UseVisualStyleBackColor = false;
            this.btnModificarPersonal.Click += new System.EventHandler(this.btnModificarPersonal_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Image = global::ProyectoCatedra.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(13, 14);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 39);
            this.btnBack.TabIndex = 0;
            this.btnBack.TabStop = false;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAgregarPersonal
            // 
            this.btnAgregarPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnAgregarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPersonal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPersonal.Location = new System.Drawing.Point(597, 14);
            this.btnAgregarPersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarPersonal.Name = "btnAgregarPersonal";
            this.btnAgregarPersonal.Size = new System.Drawing.Size(113, 27);
            this.btnAgregarPersonal.TabIndex = 4;
            this.btnAgregarPersonal.Text = "Agregar";
            this.btnAgregarPersonal.UseVisualStyleBackColor = false;
            this.btnAgregarPersonal.Click += new System.EventHandler(this.btnAgregarPersonal_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(100, 14);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(249, 32);
            this.txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(357, 14);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(113, 27);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // registroPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1025, 626);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnModificarPersonal);
            this.Controls.Add(this.btnAgregarPersonal);
            this.Controls.Add(this.btnEliminarPersonal);
            this.Controls.Add(this.dataGridViewPersonal);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "registroPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Personal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPersonal;
        private System.Windows.Forms.Button btnEliminarPersonal;
        private System.Windows.Forms.Button btnModificarPersonal;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAgregarPersonal;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}