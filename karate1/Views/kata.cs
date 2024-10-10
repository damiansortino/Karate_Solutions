using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace karate1.Views
{
    public partial class kata : Form
    {
        public kata()
        {
            InitializeComponent();
        }

        private void btn_CalcularPuntos_Click(object sender, EventArgs e)
        {
            List<decimal> puntajes = new List<decimal>
    {
        decimal.Parse(tb_pts1.Text, CultureInfo.InvariantCulture),
        decimal.Parse(tb_pts2.Text, CultureInfo.InvariantCulture),
        decimal.Parse(tb_pts3.Text, CultureInfo.InvariantCulture),
        decimal.Parse(tb_pts4.Text, CultureInfo.InvariantCulture),
        decimal.Parse(tb_pts5.Text, CultureInfo.InvariantCulture)
    };

            decimal resultado;

            if (radioButton_3jueces.Checked)
            {
                // Elimina el valor más alto
                puntajes.Remove(puntajes.Max());
                resultado = puntajes.Sum(); // Sumar los restantes
            }
            else if (radioButton_5jueces.Checked)
            {
                // Elimina el mayor y el menor valor
                puntajes.Remove(puntajes.Max());
                puntajes.Remove(puntajes.Min());
                resultado = puntajes.Sum(); // Sumar los restantes
            }
            else
            {
                return; // Sale si no hay jueces seleccionados
            }

            lbl_MostrarPuntos.Text = resultado.ToString("F1");
            MessageBox.Show($"El resultado es: {resultado:F1}"); // Muestra el resultado con 2 decimales
        }

        private void btn_Reiniciar_Click(object sender, EventArgs e)
        {
            //reinicia todos los valores de puntos
            ReiniciarValores();
            lbl_MostrarPuntos.Text = "Ingrese los puntajes...";
        }

        

        private void tb_pts1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de 'ding' que ocurre cuando se presiona Enter en un TextBox
                e.Handled = true;

                // Enviar el foco al siguiente control en el orden del tabulador
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void tb_pts2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de 'ding' que ocurre cuando se presiona Enter en un TextBox
                e.Handled = true;

                // Enviar el foco al siguiente control en el orden del tabulador
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void tb_pts3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de 'ding' que ocurre cuando se presiona Enter en un TextBox
                e.Handled = true;

                // Enviar el foco al siguiente control en el orden del tabulador
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void tb_pts4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de 'ding' que ocurre cuando se presiona Enter en un TextBox
                e.Handled = true;

                // Enviar el foco al siguiente control en el orden del tabulador
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        

        private void tb_pts5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de 'ding' que ocurre cuando se presiona Enter en un TextBox
                e.Handled = true;

                // Enviar el foco al siguiente control en el orden del tabulador
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void tb_pts1_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Expresión regular para validar solo números y un punto decimal
            string pattern = @"^[0-9]*\.?[0-9]+$";

            // Validar si el contenido del TextBox no cumple con el patrón
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
            {
                // Mostrar el mensaje de error
                MessageBox.Show("Por favor, ingrese solo números o un punto decimal.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el contenido del TextBox si no es válido
                textBox.Clear();

                // Regresar el foco al TextBox para corregir la entrada
                textBox.Focus();
            }
        }

        private void tb_pts2_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Expresión regular para validar solo números y un punto decimal
            string pattern = @"^[0-9]*\.?[0-9]+$";

            // Validar si el contenido del TextBox no cumple con el patrón
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
            {
                // Mostrar el mensaje de error
                MessageBox.Show("Por favor, ingrese solo números o un punto decimal.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el contenido del TextBox si no es válido
                textBox.Clear();

                // Regresar el foco al TextBox para corregir la entrada
                textBox.Focus();
            }
        }

        private void tb_pts3_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Expresión regular para validar solo números y un punto decimal
            string pattern = @"^[0-9]*\.?[0-9]+$";

            // Validar si el contenido del TextBox no cumple con el patrón
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
            {
                // Mostrar el mensaje de error
                MessageBox.Show("Por favor, ingrese solo números o un punto decimal.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el contenido del TextBox si no es válido
                textBox.Clear();

                // Regresar el foco al TextBox para corregir la entrada
                textBox.Focus();
            }
        }

        private void tb_pts4_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Expresión regular para validar solo números y un punto decimal
            string pattern = @"^[0-9]*\.?[0-9]+$";

            // Validar si el contenido del TextBox no cumple con el patrón
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
            {
                // Mostrar el mensaje de error
                MessageBox.Show("Por favor, ingrese solo números o un punto decimal.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el contenido del TextBox si no es válido
                textBox.Clear();

                // Regresar el foco al TextBox para corregir la entrada
                textBox.Focus();
            }
        }

        private void tb_pts5_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Expresión regular para validar solo números y un punto decimal
            string pattern = @"^[0-9]*\.?[0-9]+$";

            // Validar si el contenido del TextBox no cumple con el patrón
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
            {
                // Mostrar el mensaje de error
                MessageBox.Show("Por favor, ingrese solo números o un punto decimal.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar el contenido del TextBox si no es válido
                textBox.Clear();

                // Regresar el foco al TextBox para corregir la entrada
                textBox.Focus();
            }
        }

        private void kata_Load(object sender, EventArgs e)
        {
            ReiniciarValores();
            radioButton_3jueces.Checked = true;

            if (radioButton_3jueces.Checked)
            {
                tb_pts4.Enabled = false;
                tb_pts5.Enabled = false;
            }
            else
            {
                tb_pts4.Enabled = true;
                tb_pts5.Enabled = true;
            }
        }

        private void ReiniciarValores()
        {
            tb_pts1.Text = "0";
            tb_pts2.Text = "0";
            tb_pts3.Text = "0";
            tb_pts4.Text = "0";
            tb_pts5.Text = "0";
            
        }

        private void radioButton_3jueces_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_3jueces.Checked)
            {
                tb_pts4.Enabled = false;
                tb_pts5.Enabled = false;
            }
            else
            {
                tb_pts4.Enabled = true;
                tb_pts5.Enabled = true;
            }
        }

        private void radioButton_5jueces_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_3jueces.Checked)
            {
                tb_pts4.Enabled = false;
                tb_pts5.Enabled = false;
            }
            else
            {
                tb_pts4.Enabled = true;
                tb_pts5.Enabled = true;
            }
        }
    }
}
