using karate1.Model;
using karate1.Views;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace karate1
{
    public partial class KarateControl : Form
    {
        private EspectadorForm espectadorForm = null;
        private Timer timer;
        private int tiempoRestante; // Almacena los segundos restantes
        private int ganador = 3;
        public KarateControl()
        {
            InitializeComponent();
            btn_PantallaExterior.BackColor = Color.Red; // Inicializar el botón en rojo
            btn_PantallaExterior.Text = "Mostrar al público"; // Texto inicial

            // Inicializa el tiempo de cuenta regresiva (en segundos)
            tiempoRestante = 180; // 60 segundos, por ejemplo

            // Configura el Timer
            timer = new Timer();
            timer.Interval = 1000; // 1000 ms = 1 segundo
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Reduce el tiempo restante en 1 segundo
            tiempoRestante--;

            // Actualiza el texto del Label con los segundos restantes

            MostrarTiempoEnLabel(tiempoRestante, lbl_Contador);

            // Si el tiempo llega a 0, detiene el Timer
            if (tiempoRestante <= 0)
            {
                timer.Stop();
                lbl_Contador.Text = "0:00";
                MessageBox.Show("Tiempo Terminado");
                combo_Tiempo.Enabled = true;
            }
            ActualizarEspectadorForm(espectadorForm);
        }
        

        private void ActualizarEspectadorForm(EspectadorForm espectadorForm)
        {
            string mod = "";
            if (radioButton_Shobu_ippon.Checked)
            {
                mod = "Shobu ippon";
            }
            else
            {
                if (radioButton_Shobu_nihon.Checked)
                {
                    mod = "Shobu nihon";
                }
                else
                {
                    mod = "Shobu sambon";
                }
            }
            // Crear un objeto con los datos actuales
            EspectadorData data = new EspectadorData
            {
                MostrarKinshi1 = btn_Kinshi1.Text,
                MostrarAtenai1 = btn_Atenai1.Text,
                MostrarKiken1 = btn_Kiken1.Text,
                MostrarHansoku1 = btn_Hansoku1.Text,
                MostrarKinshi2 = btn_Kinshi2.Text,
                MostrarAtenai2 = btn_Atenai2.Text,
                MostrarKiken2 = btn_Kiken2.Text,
                MostrarHansoku2 = btn_Hansoku2.Text,
                Puntos1 = ptos1.ToString(),
                Puntos2 = ptos2.ToString(),
                KumiteKata = "Kumite",
                Tiempo = lbl_Contador.Text,
                PTS1 = ptos1.ToString(),
                PTS2 = ptos2.ToString(),
                Modalidad = mod,
                Ganador = ganador.ToString()
            };

            // Llamar al método del EspectadorForm para actualizar los Labels - primero controla si la ventana está abierta
            if (espectadorForm != null && !espectadorForm.IsDisposed)
            {
                espectadorForm.ActualizarDatos(data);
            }
        }

        private void MostrarTiempoEnLabel(int segundos, Label label)
        {
            // Convierte segundos a minutos y segundos
            int minutos = segundos / 60;
            int segundosRestantes = segundos % 60;

            // Formatea el resultado como m:ss
            string tiempoFormateado = string.Format("{0}:{1:D2}", minutos, segundosRestantes);

            // Muestra el resultado en el Label
            label.Text = tiempoFormateado;
        }


        double ptos1 = 0, ptos2 = 0;
        int pena1_a = 0, pena1_b = 0, pena1_c = 0, pena1_d = 0, pena2_a = 0

            , pena2_b = 0, pena2_c = 0, pena2_d = 0;

        //comentar los nombres de las penas: ejemplo: a = wasaby b = yamamoto

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close(); //esta linea cierra toda la ventana
        }

        private void btn_Wazari2_Click(object sender, EventArgs e)
        {
            Sumarmedio(2);
        }

        private void btn_Ippon2_Click(object sender, EventArgs e)
        {
            Sumarpunto(2);
        }

        private void btn_Kinshi1_Click(object sender, EventArgs e)
        {
            char a = 'a';
            Penalizar(1, a);

        }

        private void Penalizar(int v, char a)
        {
            if (v == 1)
            {
                if (a == 'a')
                {
                    pena1_a++;
                }
                else
                {
                    if (a == 'b')
                    {
                        pena1_b++;
                    }
                    else
                    {
                        if (a == 'c')
                        {
                            pena1_c++;
                        }
                        else
                        {
                            pena1_d++;
                        }
                    }
                }

            }
            else
            {
                if (a == 'a')
                {
                    pena2_a++;
                }
                else
                {
                    if (a == 'b')
                    {
                        pena2_b++;
                    }
                    else
                    {
                        if (a == 'c')
                        {
                            pena2_c++;
                        }
                        else
                        {
                            pena2_d++;
                        }
                    }
                }

            }
            ActualizarbtnPenas();
        }

        private void ActualizarbtnPenas()
        {
            btn_Kinshi1.Text = "Kinshi (" + pena1_a + ")";
            btn_Kinshi2.Text = "Kinshi (" + pena2_a + ")";

            btn_Atenai1.Text = "Atenai (" + pena1_b + ")";
            btn_Atenai2.Text = "Atenai (" + pena2_b + ")";

            btn_Hansoku1.Text = "Hansoku (" + pena1_c + ")";
            btn_Hansoku2.Text = "Hansoku (" + pena2_c + ")";

            btn_Kiken1.Text = "Kiken (" + pena1_d + ")";
            btn_Kiken2.Text = "Kiken (" + pena2_d + ")";
        }

        private void btn_Atenai1_Click(object sender, EventArgs e)
        {
            char b = 'b';
            Penalizar(1, b);
        }

        private void btn_Hansoku1_Click(object sender, EventArgs e)
        {
            char c = 'c';
            Penalizar(1, c);
            ganador = 2;
            ActualizarEspectadorForm(espectadorForm);
            HabilitarControl();
            btn_Ganador2.PerformClick();
        }

        private void HabilitarControl()
        {
            btn_reiniciar_puntos.Enabled = true;
            btn_ReiniciarTiempo.Enabled = true;
            radioButton_Shobu_ippon.Enabled = true;
            radioButton_Shobu_nihon.Enabled = true;
            radioButton_Shobu_sambon.Enabled = true;
            combo_Tiempo.Enabled = true;
        }

        private void btn_kiken1_Click(object sender, EventArgs e)
        {
            char d = 'd';
            Penalizar(1, d);
        }

        private void btn_Kinshi2_Click(object sender, EventArgs e)
        {
            char a = 'a';
            Penalizar(2, a);
        }

        private void btn_Atenai2_Click(object sender, EventArgs e)
        {
            char b = 'b';
            Penalizar(2, b);
        }

        private void btn_Hansoku2_Click(object sender, EventArgs e)
        {
            char c = 'c';
            Penalizar(2, c);
            ganador = 1;
            ActualizarEspectadorForm(espectadorForm);
            HabilitarControl();
            btn_Ganador1.PerformClick();

        }

        private void btn_Kiken2_Click(object sender, EventArgs e)
        {
            char d = 'd';
            Penalizar(2, d);
        }

        private void btn_wazari_Click(object sender, EventArgs e)
        {
            Sumarmedio(1);
            //este botón debería sumarle al competidor robo 0,5 puntos.
            Actualizarlbl(1);
            //debe actualizar el label "lbl_PuntosParticipante_1".

        }

        private  void btn_PlayPause_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"Sound\campana.wav");
            player.Play();

            if (timer.Enabled) //si timer corriendo
            {
                timer.Stop();
                btn_ReiniciarTiempo.Enabled = true;
                btn_reiniciar_puntos.Enabled = true;
                radioButton_Shobu_ippon.Enabled = true;
                radioButton_Shobu_nihon.Enabled = true;
                radioButton_Shobu_sambon.Enabled = true;
            }
            else // timer no corriendo
            {
                radioButton_Shobu_ippon.Enabled = false;
                radioButton_Shobu_nihon.Enabled = false;
                radioButton_Shobu_sambon.Enabled = false;

                btn_ReiniciarTiempo.Enabled = false;
                btn_reiniciar_puntos.Enabled = false;
                if (combo_Tiempo.Enabled == true)
                {
                    btn_reiniciar_puntos.Enabled = false;
                    combo_Tiempo.Enabled = false;

                    int estado = combo_Tiempo.SelectedIndex;

                    switch (estado)
                    {
                        case 0:

                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 60;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 1:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 90;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 2:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 120;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 3:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 150;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 4:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 180;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 5:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 210;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 6:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 240;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 7:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 270;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 8:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 300;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 9:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 330;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 10:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 360;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 11:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 390;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                        case 12:
                            if (timer.Enabled == false)
                            {
                                tiempoRestante = 420;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                            }
                            break;
                    }
                }
                else
                {
                    tiempoRestante = ObtenerSegundosDesdeLabel(lbl_Contador);
                    timer.Start();
                }

            }

        }

        private int ObtenerSegundosDesdeLabel(System.Windows.Forms.Label v)
        {
            // Obtiene el texto del Label en formato "m:ss"
            string tiempo = v.Text;

            // Divide el texto en minutos y segundos
            string[] partes = tiempo.Split(':');

            // Convierte las partes a enteros
            int minutos = int.Parse(partes[0]);
            int segundos = int.Parse(partes[1]);

            // Calcula el total en segundos
            return (minutos * 60) + segundos;

        }


        private void combo_Tiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_Tiempo.Text)
            {
                case "1 min":
                    lbl_Contador.Text = "1:00";
                    break;

                case "1:30 min":
                    lbl_Contador.Text = "1:30";
                    break;

                case "2 min":
                    lbl_Contador.Text = "2:00";
                    break;
                case "2:30 min":
                    lbl_Contador.Text = "2:30";
                    break;
                case "3 min":
                    lbl_Contador.Text = "3:00";
                    break;
                case "3:30 min":
                    lbl_Contador.Text = "3:30";
                    break;
                case "4 min":
                    lbl_Contador.Text = "4:00";
                    break;
                case "4:30 min":
                    lbl_Contador.Text = "4:30";
                    break;
                case "5 min":
                    lbl_Contador.Text = "5:00";
                    break;
                case "5:30 min":
                    lbl_Contador.Text = "5:30";
                    break;
                case "6 min":
                    lbl_Contador.Text = "6:00";
                    break;
                case "6:30 min":
                    lbl_Contador.Text = "6:30";
                    break;
                case "7 min":
                    lbl_Contador.Text = "7:00";
                    break;
            }
        }

        private void btn_menosmedio_1_Click(object sender, EventArgs e)
        {
            ptos1 = ptos1 - 0.5;
            Actualizarlbl(1);
        }

        private void btn_menosmedio_2_Click(object sender, EventArgs e)
        {
            ptos2 = ptos2 - 0.5;
            Actualizarlbl(2);
        }

        private void btn_ReiniciarTiempo_Click(object sender, EventArgs e)
        {
            combo_Tiempo.Enabled = true;
            lbl_Contador.Text = "3:00";
            combo_Tiempo.SelectedIndex = 4;
        }

        
        private void lbl_Contador_TextChanged(object sender, EventArgs e)
        {
            if (lbl_Contador.Text == "0:15")
            {
                SoundPlayer player = new SoundPlayer(@"Sound\advertencia.wav");
                player.Play();
            }
            if (lbl_Contador.Text == "0:00")
            {
                SoundPlayer player = new SoundPlayer(@"Sound\campana.wav");
                player.Play();
                btn_ReiniciarTiempo.Enabled = true;
                btn_reiniciar_puntos.Enabled = true;
            }
        }

        private void btn_PantallaExterior_Click(object sender, EventArgs e)
        {
            // Obtener todas las pantallas conectadas al dispositivo
            Screen[] pantallas = Screen.AllScreens;

            // Verificar si hay más de una pantalla conectada
            if (pantallas.Length > 1)
            {
                // Si la ventana ya está abierta, la cerramos
                if (espectadorForm != null && !espectadorForm.IsDisposed)
                {
                    // Cerrar la ventana
                    espectadorForm.Close();
                    espectadorForm = null;

                    // Cambiar el color del botón a rojo y el texto a "Mostrar al público"
                    btn_PantallaExterior.BackColor = Color.Red;
                    btn_PantallaExterior.Text = "Mostrar al público";
                }
                else
                {
                    // Obtener la segunda pantalla (pantalla adicional)
                    Screen pantallaSecundaria = pantallas[1];

                    // Crear una nueva instancia del formulario "EspectadorForm"
                    espectadorForm = new EspectadorForm();

                    // Establecer la posición del formulario en la pantalla secundaria
                    espectadorForm.StartPosition = FormStartPosition.Manual;
                    espectadorForm.Location = pantallaSecundaria.Bounds.Location;

                    // Mostrar el formulario en la pantalla secundaria
                    espectadorForm.Show();
                    ActualizarEspectadorForm(espectadorForm);

                    // Cambiar el color del botón a verde y el texto a "Ocultar al público"
                    btn_PantallaExterior.BackColor = Color.Green;
                    btn_PantallaExterior.Text = "Ocultar al público";
                }
            }
            else
            {
                MessageBox.Show("No hay una pantalla secundaria conectada.");
            }
            
        }

        private void KarateControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si el EspectadorForm está abierto, cerrarlo
            if (espectadorForm != null && !espectadorForm.IsDisposed)
            {
                espectadorForm.Close();
                espectadorForm = null;
            }

            // Cambiar el color del botón y el texto para reflejar que está cerrado
            btn_PantallaExterior.BackColor = Color.Red;
            btn_PantallaExterior.Text = "Mostrar al público";
        }

        private void radioButton_Shobu_ippon_CheckedChanged(object sender, EventArgs e)
        {
            combo_Tiempo.SelectedIndex = 1;
        }

        private void radioButton_Shobu_nihon_CheckedChanged(object sender, EventArgs e)
        {
            combo_Tiempo.SelectedIndex = 2;
        }

        private void radioButton_Shobu_sambon_CheckedChanged(object sender, EventArgs e)
        {
            combo_Tiempo.SelectedIndex = 4;
        }

        private void KarateControl_Load(object sender, EventArgs e)
        {
            radioButton_Shobu_ippon.Checked = true;
        }

        private void Actualizarlbl(int v)
        {
            if (v == 1)
            {
                lbl_Pts1.Text = ptos1 + " Pts.";
            }
            else
            {
                lbl_Pts2.Text = ptos2 + " Pts.";
            }
        }

        private void Sumarmedio(int v)
        {
            if (v == 1)
            {
                ptos1 = ptos1 + 0.5;
            }
            else
            {
                ptos2 = ptos2 + 0.5;
            }
            Actualizarlbl(v);
        }

        private void btn_Ippon_Click(object sender, EventArgs e)
        {
            Sumarpunto(1);
            //este botón le suma al copetidor rojo 1 punto
            Actualizarlbl(1);
            //Actualizar lbl_puntos_pasdasdasd
        }

        private void Sumarpunto(int v)
        {
            if (v == 1)
            {
                ptos1++;
            }
            else
            {
                ptos2++;
            }
            Actualizarlbl(v);
        }

        private void btn_reiniciar_puntos_Click(object sender, EventArgs e)
        {
            ReiniciarPts();

            Actualizarlbl(1);
            Actualizarlbl(2);
            combo_Tiempo.Text = "1:30 min";
            combo_Tiempo.Enabled = true;
            lbl_Contador.Text = "1:30";
            radioButton_Shobu_ippon.Checked = true;
            ganador = 3;
            ActualizarEspectadorForm(espectadorForm);
        }

        private void ReiniciarPts()
        {
            ptos1 = 0;
            ptos2 = 0;
            pena1_a = 0;
            pena1_b = 0;
            pena1_c = 0;
            pena1_d = 0;

            pena2_a = 0;
            pena2_b = 0;
            pena2_c = 0;
            pena2_d = 0;
            ActualizarbtnPenas();
            Actualizarlbl(1);
            Actualizarlbl(2);
            ganador = 3;
        }

        private void btn_Ganador1_Click(object sender, EventArgs e)
        {
            ganador = 1; 
            ActualizarEspectadorForm(espectadorForm);
            timer.Stop();
            HabilitarControl();
            MessageBox.Show("El competidor 1, resulta Ganador");
        }

        private void btn_Ganador2_Click(object sender, EventArgs e)
        {
            ganador = 2;
            ActualizarEspectadorForm(espectadorForm);
            timer.Stop();
            HabilitarControl();
            MessageBox.Show("El competidor 2, resulta Ganador");   
        }

    }
}
