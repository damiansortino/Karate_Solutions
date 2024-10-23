using System.Security.Cryptography;
using System.Text;

namespace karate1.Model
{
    public class Seguridad
    {
        public string ConvertirSHA256(string texto)
        {
            // Crear una instancia de SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir el texto en un array de bytes
                byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);

                // Obtener el hash SHA256
                byte[] hashBytes = sha256.ComputeHash(bytesTexto);

                // Convertir el hash en una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Formato hexadecimal
                }

                // Devolver el hash en formato string
                return sb.ToString();
            }
        }
    }
}
