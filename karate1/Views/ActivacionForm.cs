using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace karate1.Views
{
    public partial class ActivacionForm : Form
    {
        public ActivacionForm()
        {
            InitializeComponent();
        }
        public string LicenciaIngresada = "";

        private void btn_Validar_Click(object sender, EventArgs e)
        {
            LicenciaIngresada = tb_Licencia.Text.ToUpper().Trim();
            if (!string.IsNullOrEmpty(LicenciaIngresada))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se ha ingresado ninguna licencia válida");
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_WhatsApp_Click(object sender, EventArgs e)
        {
            Process.Start("https://api.whatsapp.com/send/?phone=+5492634410191&text=%C2%A1Hola%21%2C+me+gustar%C3%ADa+informaci%C3%B3n+para+adquirir+una+licencia+de+uso+de+KarateSoftware&type=phone_number&app_absent=0");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://damiansortino.github.io/Karate_Solutions/");
        }

        private void tb_Licencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Validar.PerformClick();
                e.Handled = true;
            }
        }
    }
}
