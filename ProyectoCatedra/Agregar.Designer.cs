namespace ProyectoCatedra
{
    partial class Agregar
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
            this.panelCita = new System.Windows.Forms.Panel();
            this.panelPersonal = new System.Windows.Forms.Panel();
            this.lblRolEmpleado = new System.Windows.Forms.Label();
            this.cmbRolEmpleado = new System.Windows.Forms.ComboBox();
            this.txtDireccionEmpleado = new System.Windows.Forms.TextBox();
            this.lblDireccionEmpleado = new System.Windows.Forms.Label();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombrePersonal = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtHoraCita = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.dateTimePickerCita = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelCita.SuspendLayout();
            this.panelPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCita
            // 
            this.panelCita.Controls.Add(this.panelPersonal);
            this.panelCita.Controls.Add(this.txtNombreCliente);
            this.panelCita.Controls.Add(this.lblNombreCliente);
            this.panelCita.Controls.Add(this.txtHoraCita);
            this.panelCita.Controls.Add(this.lblHora);
            this.panelCita.Controls.Add(this.dateTimePickerCita);
            this.panelCita.Controls.Add(this.lblFecha);
            this.panelCita.Location = new System.Drawing.Point(12, 12);
            this.panelCita.Name = "panelCita";
            this.panelCita.Size = new System.Drawing.Size(537, 321);
            this.panelCita.TabIndex = 0;
            this.panelCita.Visible = false;
            // 
            // panelPersonal
            // 
            this.panelPersonal.Controls.Add(this.lblRolEmpleado);
            this.panelPersonal.Controls.Add(this.cmbRolEmpleado);
            this.panelPersonal.Controls.Add(this.txtDireccionEmpleado);
            this.panelPersonal.Controls.Add(this.lblDireccionEmpleado);
            this.panelPersonal.Controls.Add(this.txtNombreEmpleado);
            this.panelPersonal.Controls.Add(this.lblNombrePersonal);
            this.panelPersonal.Location = new System.Drawing.Point(3, 0);
            this.panelPersonal.Name = "panelPersonal";
            this.panelPersonal.Size = new System.Drawing.Size(537, 343);
            this.panelPersonal.TabIndex = 6;
            this.panelPersonal.Visible = false;
            // 
            // lblRolEmpleado
            // 
            this.lblRolEmpleado.AutoSize = true;
            this.lblRolEmpleado.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRolEmpleado.Location = new System.Drawing.Point(56, 210);
            this.lblRolEmpleado.Name = "lblRolEmpleado";
            this.lblRolEmpleado.Size = new System.Drawing.Size(116, 16);
            this.lblRolEmpleado.TabIndex = 5;
            this.lblRolEmpleado.Text = "Rol del Empleado";
            // 
            // cmbRolEmpleado
            // 
            this.cmbRolEmpleado.FormattingEnabled = true;
            this.cmbRolEmpleado.Location = new System.Drawing.Point(57, 249);
            this.cmbRolEmpleado.Name = "cmbRolEmpleado";
            this.cmbRolEmpleado.Size = new System.Drawing.Size(178, 24);
            this.cmbRolEmpleado.TabIndex = 4;
            // 
            // txtDireccionEmpleado
            // 
            this.txtDireccionEmpleado.Location = new System.Drawing.Point(57, 160);
            this.txtDireccionEmpleado.Name = "txtDireccionEmpleado";
            this.txtDireccionEmpleado.Size = new System.Drawing.Size(437, 22);
            this.txtDireccionEmpleado.TabIndex = 3;
            // 
            // lblDireccionEmpleado
            // 
            this.lblDireccionEmpleado.AutoSize = true;
            this.lblDireccionEmpleado.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDireccionEmpleado.Location = new System.Drawing.Point(54, 127);
            this.lblDireccionEmpleado.Name = "lblDireccionEmpleado";
            this.lblDireccionEmpleado.Size = new System.Drawing.Size(130, 16);
            this.lblDireccionEmpleado.TabIndex = 2;
            this.lblDireccionEmpleado.Text = "Direccion Empleado";
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(57, 68);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(220, 22);
            this.txtNombreEmpleado.TabIndex = 1;
            // 
            // lblNombrePersonal
            // 
            this.lblNombrePersonal.AutoSize = true;
            this.lblNombrePersonal.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNombrePersonal.Location = new System.Drawing.Point(54, 26);
            this.lblNombrePersonal.Name = "lblNombrePersonal";
            this.lblNombrePersonal.Size = new System.Drawing.Size(144, 16);
            this.lblNombrePersonal.TabIndex = 0;
            this.lblNombrePersonal.Text = "Nombre del Empleado";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(54, 239);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(223, 22);
            this.txtNombreCliente.TabIndex = 5;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNombreCliente.Location = new System.Drawing.Point(51, 210);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(122, 16);
            this.lblNombreCliente.TabIndex = 4;
            this.lblNombreCliente.Text = "Nombre del Cliente";
            // 
            // txtHoraCita
            // 
            this.txtHoraCita.Location = new System.Drawing.Point(54, 160);
            this.txtHoraCita.Name = "txtHoraCita";
            this.txtHoraCita.Size = new System.Drawing.Size(132, 22);
            this.txtHoraCita.TabIndex = 3;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblHora.Location = new System.Drawing.Point(51, 127);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(82, 16);
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "Hora de Cita";
            this.lblHora.Click += new System.EventHandler(this.label_Click);
            // 
            // dateTimePickerCita
            // 
            this.dateTimePickerCita.Location = new System.Drawing.Point(54, 79);
            this.dateTimePickerCita.Name = "dateTimePickerCita";
            this.dateTimePickerCita.Size = new System.Drawing.Size(223, 22);
            this.dateTimePickerCita.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFecha.Location = new System.Drawing.Point(51, 48);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(90, 16);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha de Cita";
            this.lblFecha.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Location = new System.Drawing.Point(220, 384);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(113, 47);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "button1";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(237, 473);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(561, 521);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panelCita);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Agregar";
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.Agregar_Load);
            this.panelCita.ResumeLayout(false);
            this.panelCita.PerformLayout();
            this.panelPersonal.ResumeLayout(false);
            this.panelPersonal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCita;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dateTimePickerCita;
        private System.Windows.Forms.Panel panelPersonal;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtHoraCita;
        private System.Windows.Forms.Label lblRolEmpleado;
        private System.Windows.Forms.ComboBox cmbRolEmpleado;
        private System.Windows.Forms.TextBox txtDireccionEmpleado;
        private System.Windows.Forms.Label lblDireccionEmpleado;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.Label lblNombrePersonal;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCerrar;
    }
}