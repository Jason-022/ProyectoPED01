﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

       
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Inicio rP = new Inicio();
            rP.Show();
            this.Hide();
        }
    }
}
