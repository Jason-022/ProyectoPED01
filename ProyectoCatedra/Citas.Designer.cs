namespace ProyectoCatedra
{
    partial class Citas
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
            this.dataGridViewCitas = new System.Windows.Forms.DataGridView();
            this.txtBusquedaData = new System.Windows.Forms.TextBox();
            this.btnEliminarCita = new System.Windows.Forms.Button();
            this.btnModificarCita = new System.Windows.Forms.Button();
            this.btnBuscarCita = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAgregarCita = new System.Windows.Forms.Button();
            this.btnBorrarFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCitas
            // 
            this.dataGridViewCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCitas.Location = new System.Drawing.Point(13, 187);
            this.dataGridViewCitas.Name = "dataGridViewCitas";
            this.dataGridViewCitas.RowHeadersWidth = 51;
            this.dataGridViewCitas.Size = new System.Drawing.Size(749, 304);
            this.dataGridViewCitas.TabIndex = 27;
            // 
            // txtBusquedaData
            // 
            this.txtBusquedaData.Location = new System.Drawing.Point(72, 148);
            this.txtBusquedaData.Name = "txtBusquedaData";
            this.txtBusquedaData.Size = new System.Drawing.Size(179, 20);
            this.txtBusquedaData.TabIndex = 26;
            // 
            // btnEliminarCita
            // 
            this.btnEliminarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnEliminarCita.FlatAppearance.BorderSize = 0;
            this.btnEliminarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnEliminarCita.Location = new System.Drawing.Point(621, 145);
            this.btnEliminarCita.Name = "btnEliminarCita";
            this.btnEliminarCita.Size = new System.Drawing.Size(98, 23);
            this.btnEliminarCita.TabIndex = 25;
            this.btnEliminarCita.Text = "Eliminar";
            this.btnEliminarCita.UseVisualStyleBackColor = false;
            this.btnEliminarCita.Click += new System.EventHandler(this.btnEliminarCita_Click);
            // 
            // btnModificarCita
            // 
            this.btnModificarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnModificarCita.FlatAppearance.BorderSize = 0;
            this.btnModificarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnModificarCita.Location = new System.Drawing.Point(512, 146);
            this.btnModificarCita.Name = "btnModificarCita";
            this.btnModificarCita.Size = new System.Drawing.Size(103, 23);
            this.btnModificarCita.TabIndex = 24;
            this.btnModificarCita.Text = "Modificar";
            this.btnModificarCita.UseVisualStyleBackColor = false;
            this.btnModificarCita.Click += new System.EventHandler(this.btnModificarCita_Click);
            // 
            // btnBuscarCita
            // 
            this.btnBuscarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnBuscarCita.FlatAppearance.BorderSize = 0;
            this.btnBuscarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnBuscarCita.Location = new System.Drawing.Point(257, 146);
            this.btnBuscarCita.Name = "btnBuscarCita";
            this.btnBuscarCita.Size = new System.Drawing.Size(121, 23);
            this.btnBuscarCita.TabIndex = 23;
            this.btnBuscarCita.Text = "Buscar cita";
            this.btnBuscarCita.UseVisualStyleBackColor = false;
            this.btnBuscarCita.Click += new System.EventHandler(this.btnBuscarCita_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::ProyectoCatedra.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(13, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(25, 31);
            this.btnBack.TabIndex = 29;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAgregarCita
            // 
            this.btnAgregarCita.FlatAppearance.BorderSize = 0;
            this.btnAgregarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCita.Image = global::ProyectoCatedra.Properties.Resources.cita32x;
            this.btnAgregarCita.Location = new System.Drawing.Point(13, 146);
            this.btnAgregarCita.Name = "btnAgregarCita";
            this.btnAgregarCita.Size = new System.Drawing.Size(25, 28);
            this.btnAgregarCita.TabIndex = 28;
            this.btnAgregarCita.UseVisualStyleBackColor = true;
            this.btnAgregarCita.Click += new System.EventHandler(this.btnAgregarCita_Click);
            // 
            // btnBorrarFiltro
            // 
            this.btnBorrarFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnBorrarFiltro.FlatAppearance.BorderSize = 0;
            this.btnBorrarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnBorrarFiltro.Location = new System.Drawing.Point(384, 145);
            this.btnBorrarFiltro.Name = "btnBorrarFiltro";
            this.btnBorrarFiltro.Size = new System.Drawing.Size(121, 23);
            this.btnBorrarFiltro.TabIndex = 30;
            this.btnBorrarFiltro.Text = "Borrar Filtro";
            this.btnBorrarFiltro.UseVisualStyleBackColor = false;
            this.btnBorrarFiltro.Click += new System.EventHandler(this.btnBorrarFiltro_Click);
            // 
            // Citas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(774, 522);
            this.Controls.Add(this.btnBorrarFiltro);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAgregarCita);
            this.Controls.Add(this.dataGridViewCitas);
            this.Controls.Add(this.txtBusquedaData);
            this.Controls.Add(this.btnEliminarCita);
            this.Controls.Add(this.btnModificarCita);
            this.Controls.Add(this.btnBuscarCita);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Citas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Citas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCita;
        private System.Windows.Forms.DataGridView dataGridViewCitas;
        private System.Windows.Forms.TextBox txtBusquedaData;
        private System.Windows.Forms.Button btnEliminarCita;
        private System.Windows.Forms.Button btnModificarCita;
        private System.Windows.Forms.Button btnBuscarCita;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnBorrarFiltro;
    }
}