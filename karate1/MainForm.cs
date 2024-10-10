using karate1.Views;
using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace karate1
{
    public partial class categorias : Form
    {
        private string filePath;
        public categorias()
        {
            InitializeComponent();
            // Definimos la ruta del archivo en la carpeta Documentos
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SystemLite.dat");
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
            if (File.Exists(filePath))
            {
                try
                {
                    // Leer el archivo y desencriptar el contador
                    byte[] encryptedCounter = File.ReadAllBytes(filePath);
                    int currentCounter = DecryptCounter(encryptedCounter);

                    if (currentCounter <= 0)
                    {
                        MessageBox.Show("Su prueba gratuita ha concluido, contáctese con el soporte para comprar la licencia de uso completa de KarateLite.\n" +
                            "\n" +
                            "Whats App: 2634410191      - Damián Sortino\n" +
                            "Whats App 2634631839       - Pablo Martinez\n" +
                            "damiansortino@gmail.com.ar\n" +
                            "pm32192@gmail.com");
                        this.Close();
                        return;
                    }

                    // Decrementar el contador y volver a guardar
                    currentCounter--;
                    byte[] newEncryptedCounter = EncryptCounter(currentCounter);
                    File.WriteAllBytes(filePath, newEncryptedCounter);

                    MessageBox.Show($"Le quedan {currentCounter} usos de prueba.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer o desencriptar el archivo: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Programa corrupto. Archivo faltante.");
                this.Close();
            }

        }

        

        private byte[] EncryptCounter(int counter)
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV(); // Generar un nuevo IV
                aes.Key = GenerateKey(); // Generar la clave de cifrado
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Almacenar el IV en el inicio del archivo
                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] counterBytes = BitConverter.GetBytes(counter);
                            cs.Write(counterBytes, 0, counterBytes.Length);
                        }
                    }
                    return ms.ToArray();
                }
            }
        }

        private int DecryptCounter(byte[] encryptedCounter)
        {
            using (Aes aes = Aes.Create())
            {
                // Extraer el IV del principio del archivo
                byte[] iv = new byte[16];
                Array.Copy(encryptedCounter, 0, iv, 0, iv.Length);
                aes.IV = iv;

                // La clave debe ser la misma que la utilizada para cifrar
                aes.Key = GenerateKey();
                using (var ms = new MemoryStream(encryptedCounter, iv.Length, encryptedCounter.Length - iv.Length))
                {
                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] counterBytes = new byte[4]; // Asumiendo que el contador es un entero de 4 bytes
                            cs.Read(counterBytes, 0, counterBytes.Length);
                            return BitConverter.ToInt32(counterBytes, 0);
                        }
                    }
                }
            }
        }

        private byte[] GenerateKey()
        {
            // La clave debe ser de 32 bytes para AES-256
            return Encoding.UTF8.GetBytes("B3a7rF8@dZ4pQ3w6!n1xY8m2@e9T0bA5");
        }



    }
    
}
