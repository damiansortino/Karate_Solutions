using karate1.Model;
using karate1.Views;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace karate1
{
    public partial class categorias : Form
    {
        private string filePath;
        public categorias()
        {
            InitializeComponent();
        }


        private void btn_Kumite_Click(object sender, EventArgs e)
        {
            KarateControl kum = new KarateControl();
            kum.ShowDialog();
        }

        private void btn_Kata_Click(object sender, EventArgs e)
        {
            kata kat = new kata();
            kat.ShowDialog();

        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categorias_Load(object sender, EventArgs e)
        {
            Seguridad se = new Seguridad();
            string mac = ObtenerMAC();
            string MacCifrada = se.ConvertirSHA256(mac + "Damian12");

            // Verificar si la licencia está activada en Mis Documentos
            if (!VerificarLicencia(MacCifrada))
            {
                // Si no está activada, verificar la conexión a internet
                if (HayConexionInternet())
                {
                    // Si hay internet, activar la licencia
                    var result = MessageBox.Show("¿Desea activar este dispositivo para utilizar KarateSoftware?",
                                                  "Activación de Producto", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ActivarLicencia(mac);
                    }
                    else
                    {
                        MessageBox.Show("Debe activar el producto para continuar.");
                        Application.Exit();
                    }
                }
                else
                {
                    // Si no hay internet, solicitar que se conecte
                    var result = MessageBox.Show("No hay conexión a Internet. Conéctese para activar el producto o cierre el programa.",
                                                  "Error de Conexión", MessageBoxButtons.RetryCancel);
                    if (result == DialogResult.Retry)
                    {
                        // Intentar de nuevo verificar la conexión a internet
                        if (HayConexionInternet())
                        {
                            ActivarLicencia(mac);
                        }
                        else
                        {
                            MessageBox.Show("Aún no hay conexión a Internet. El programa se cerrará.");
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                // Si la licencia está activada, continuar normalmente (Agregar form gráfico publicitario propio)
                MessageBox.Show("¡Gracias por adquirir KarateLite!");
            }

        }

        public void ActivarLicencia(string mac)
        {

            // Instanciar el formulario de activación
            ActivacionForm activacionForm = new ActivacionForm();

            // Mostrar el formulario como modal para que el usuario ingrese su licencia
            if (activacionForm.ShowDialog() == DialogResult.OK)
            {
                string licencia = activacionForm.LicenciaIngresada; // Asumimos que 'LicenciaIngresada' es una propiedad en ActivacionForm que contiene la licencia ingresada por el usuario

                if (!string.IsNullOrEmpty(licencia))
                {
                    // Verificar si la licencia es válida y activarla
                    if (VerificarYActivarLicencia(licencia, mac))
                    {
                        MessageBox.Show("Licencia activada con éxito. Bienvenido a KarateSoftware.");
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("No se pudo activar la licencia. ¿Deseas intentar nuevamente?",
                            "Error de activación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            // Si el usuario quiere intentar de nuevo, puedes llamarlo nuevamente o iniciar un flujo de reintento
                            ActivarLicencia(mac);
                        }
                        else
                        {
                            MessageBox.Show("Saliendo de la aplicación.");
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ingresó una licencia válida.");
                }
            }
            else
            {
                MessageBox.Show("Activación cancelada, el programa se cerrará.");
                Application.Exit();
            }
        }
        public string ObtenerMAC()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();
            var macAddress = interfaces
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return macAddress;
        }
        public bool VerificarLicencia(string mac)
        {
            // Obtener la ruta del directorio "Mis Documentos"
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathLicencia = Path.Combine(documentosPath, "licencia_activada.txt");  // El archivo de licencias se espera aquí

            // Verificar si el archivo de licencia existe
            if (!File.Exists(pathLicencia))
            {
                // Si no existe el archivo, iniciar el proceso de activación
                MessageBox.Show("Todavía no ha activado su licencia de uso. Debe activar el producto antes de poder utilizarlo.");
                return false;
            }
            else
            {
                // Leer todas las líneas del archivo y verificar si la MAC está activada
                var licencias = File.ReadAllLines(pathLicencia);
                foreach (var item in licencias)
                {
                    if (item.Contains(mac.Trim()))
                    {
                        return true;
                    }
                }
                return false;
            }


        }
        public bool HayConexionInternet()
        {
            try
            {
                // Intenta hacer ping a Google
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 1000);  // Dirección IP de Google DNS
                    if (reply.Status == IPStatus.Success)
                    {
                        return true;  // Hay conexión a Internet
                    }
                    else
                    {
                        return false;  // No hay conexión
                    }
                }
            }
            catch (Exception)
            {
                return false;  // Si hay un error, asumimos que no hay conexión
            }
        }
        public string ObtenerContenidoArchivoLicencias()
        {
            string urlArchivo = "https://damiansortino.github.io/Karate_Solutions/Licencias_Karate.txt";
            using (WebClient client = new WebClient())
            {
                try
                {
                    // Descargar contenido del archivo licencias.txt desde GitHub Pages
                    string contenido = client.DownloadString(urlArchivo);
                    return contenido;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo obtener el archivo de licencias: {ex.Message}");
                    return null;
                }
            }
        }
        public bool VerificarYActivarLicencia(string licencia, string mac)
        {
            Seguridad se = new Seguridad();
            string MacCifrada = se.ConvertirSHA256(mac + "Damian12");
            string LicenciaCifrada = se.ConvertirSHA256(licencia + "Damian12");
            string contenido = ObtenerContenidoArchivoLicencias();

            if (string.IsNullOrEmpty(contenido))
            {
                return false; // No se pudo obtener el archivo o está vacío
            }

            string[] lineas = contenido.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');

                if (datos[0] == licencia)  // Si coincide la licencia
                {
                    // Verificar cuántos dispositivos ya están activados
                    if (datos.Length == 1)
                    {
                        ActivarNuevoDispositivo(licencia, mac);
                        return true;
                    }
                    else if (Array.Exists(datos, d => d == mac))
                    {
                        // Actualizar el archivo local en My Documents
                        string rutaArchivoLocal = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\licencia_activada.txt";
                        File.WriteAllText(rutaArchivoLocal, $"Licencia: {LicenciaCifrada}, MAC: {MacCifrada}");

                        MessageBox.Show("Este dispositivo ya se encuentra activado.");

                        return true;
                    }
                }
            }

            MessageBox.Show("Licencia no válida.");
            return false;
        }
        public void ActivarNuevoDispositivo(string licencia, string mac)
        {
            // Actualizar el archivo local en My Documents
            string rutaArchivoLocal = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\licencia_activada.txt";
            File.WriteAllText(rutaArchivoLocal, $"Licencia: {licencia}, MAC: {mac}");

            // Actualizar archivo en GitHub Pages
            ActualizarArchivoLicencias(licencia, mac);
        }
        public void ActualizarArchivoLicencias(string licencia, string mac)
        {
            string contenidoActual = ObtenerContenidoArchivoLicencias();
            string[] lineas = contenidoActual.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(',');

                if (datos[0] == licencia)
                {
                    // Añadir la nueva MAC
                    lineas[i] += $",{mac}";
                    break;
                }
            }

            // Guardar localmente el archivo actualizado
            string rutaArchivoActualizado = "Licencias_Karate.txt";
            File.WriteAllLines(rutaArchivoActualizado, lineas);

            // Enviar el archivo por correo electrónico
            EnviarArchivoPorEmail(rutaArchivoActualizado);
        }
        public void EnviarArchivoPorEmail(string rutaArchivo)
        {
            try
            {
                // Configurar cliente SMTP para Gmail
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("damiansortino@gmail.com", "vrmf ifvi gtwv xjmg"), // Cambiar por tus credenciales
                    EnableSsl = true
                };

                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("damiansortino@gmail.com"),  // Cambiar por tu email
                    Subject = "Actualización de licencias - KarateLite",
                    Body = "Adjunto encontrarás el archivo con las licencias actualizadas. Por favor, súbelo a GitHub Pages.",
                    IsBodyHtml = false
                };
                mailMessage.To.Add("damiansortino@gmail.com");

                // Adjuntar el archivo
                Attachment attachment = new Attachment(rutaArchivo);
                mailMessage.Attachments.Add(attachment);

                // Enviar el correo
                client.Send(mailMessage);
                MessageBox.Show("El archivo ha sido enviado por correo electrónico.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar el correo: {ex.Message}");
            }
        }
    }

}
