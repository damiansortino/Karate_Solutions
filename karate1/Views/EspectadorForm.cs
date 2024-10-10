using karate1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace karate1.Views
{
    public partial class EspectadorForm : Form
    {
        public EspectadorForm()
        {
            InitializeComponent();
        }

        public void ActualizarDatos(EspectadorData data)
        {
            lbl_MostrarKinshi1.Text = data.MostrarKinshi1;
            lbl_MostrarAtenai1.Text = data.MostrarAtenai1;
            lbl_MostrarKiken1.Text = data.MostrarKiken1;
            lbl_MostrarHansoku1.Text = data.MostrarHansoku1;

            lbl_MostrarKinshi2.Text = data.MostrarKinshi2;
            lbl_MostrarAtenai2.Text = data.MostrarAtenai2;
            lbl_MostrarKiken2.Text = data.MostrarKiken2;
            lbl_MostrarHansoku2.Text = data.MostrarHansoku2;

            lbl_KumiteKata.Text = data.KumiteKata;
            lbl_Tiempo.Text = data.Tiempo;
            lbl_PTS1.Text = data.PTS1;
            lbl_PTS2.Text = data.PTS2;
            lbl_Modalidad.Text = data.Modalidad;

            if (data.Ganador != "3")
            {
                if (data.Ganador == "1")
                {
                    
                    lblnokachi_rojo.Visible = true;
                    lbl_nokachi_blanco.Visible = false;
                    
                }
                else
                {
                   
                    lbl_nokachi_blanco.Visible = true;
                    lblnokachi_rojo.Visible = false;
                    
                }
            }
            else
            {
                lblnokachi_rojo.Visible = false;
                lbl_nokachi_blanco.Visible = false;
                
            }
        }

        
    }
}
