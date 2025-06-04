namespace ProyectoCatedra
{
    partial class TiposDeCortes
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
            this.dataGridViewTipoCorte = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEliminarPeinado = new System.Windows.Forms.Button();
            this.btnModificarPeinado = new System.Windows.Forms.Button();
            this.btnBuscarPeinado = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAgregarCorte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoCorte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTipoCorte
            // 
            this.dataGridViewTipoCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTipoCorte.Location = new System.Drawing.Point(10, 194);
            this.dataGridViewTipoCorte.Name = "dataGridViewTipoCorte";
            this.dataGridViewTipoCorte.RowHeadersWidth = 51;
            this.dataGridViewTipoCorte.Size = new System.Drawing.Size(749, 304);
            this.dataGridViewTipoCorte.TabIndex = 34;
            this.dataGridViewTipoCorte.SelectionChanged += new System.EventHandler(this.dataGridViewTipoCorte_SelectionChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 33;
            // 
            // btnEliminarPeinado
            // 
            this.btnEliminarPeinado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnEliminarPeinado.FlatAppearance.BorderSize = 0;
            this.btnEliminarPeinado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPeinado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnEliminarPeinado.Location = new System.Drawing.Point(644, 154);
            this.btnEliminarPeinado.Name = "btnEliminarPeinado";
            this.btnEliminarPeinado.Size = new System.Drawing.Size(98, 23);
            this.btnEliminarPeinado.TabIndex = 32;
            this.btnEliminarPeinado.Text = "Eliminar";
            this.btnEliminarPeinado.UseVisualStyleBackColor = false;
            this.btnEliminarPeinado.Click += new System.EventHandler(this.btnEliminarPeinado_Click);
            // 
            // btnModificarPeinado
            // 
            this.btnModificarPeinado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnModificarPeinado.FlatAppearance.BorderSize = 0;
            this.btnModificarPeinado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPeinado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnModificarPeinado.Location = new System.Drawing.Point(508, 154);
            this.btnModificarPeinado.Name = "btnModificarPeinado";
            this.btnModificarPeinado.Size = new System.Drawing.Size(103, 23);
            this.btnModificarPeinado.TabIndex = 31;
            this.btnModificarPeinado.Text = "Modificar";
            this.btnModificarPeinado.UseVisualStyleBackColor = false;
            this.btnModificarPeinado.Click += new System.EventHandler(this.btnModificarPeinado_Click);
            // 
            // btnBuscarPeinado
            // 
            this.btnBuscarPeinado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnBuscarPeinado.FlatAppearance.BorderSize = 0;
            this.btnBuscarPeinado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPeinado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnBuscarPeinado.Location = new System.Drawing.Point(358, 154);
            this.btnBuscarPeinado.Name = "btnBuscarPeinado";
            this.btnBuscarPeinado.Size = new System.Drawing.Size(121, 23);
            this.btnBuscarPeinado.TabIndex = 30;
            this.btnBuscarPeinado.Text = "Buscar peinado";
            this.btnBuscarPeinado.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::ProyectoCatedra.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(10, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(32, 37);
            this.btnBack.TabIndex = 36;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAgregarCorte
            // 
            this.btnAgregarCorte.FlatAppearance.BorderSize = 0;
            this.btnAgregarCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCorte.Image = global::ProyectoCatedra.Properties.Resources.boton_circular_plus;
            this.btnAgregarCorte.Location = new System.Drawing.Point(10, 144);
            this.btnAgregarCorte.Name = "btnAgregarCorte";
            this.btnAgregarCorte.Size = new System.Drawing.Size(39, 44);
            this.btnAgregarCorte.TabIndex = 35;
            this.btnAgregarCorte.UseVisualStyleBackColor = true;
            this.btnAgregarCorte.Click += new System.EventHandler(this.btnAgregarCorte_Click);
            // 
            // TiposDeCortes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(779, 516);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAgregarCorte);
            this.Controls.Add(this.dataGridViewTipoCorte);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEliminarPeinado);
            this.Controls.Add(this.btnModificarPeinado);
            this.Controls.Add(this.btnBuscarPeinado);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TiposDeCortes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TiposDeCortes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoCorte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAgregarCorte;
        private System.Windows.Forms.DataGridView dataGridViewTipoCorte;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEliminarPeinado;
        private System.Windows.Forms.Button btnModificarPeinado;
        private System.Windows.Forms.Button btnBuscarPeinado;
    }
}