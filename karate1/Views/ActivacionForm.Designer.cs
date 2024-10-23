namespace karate1.Views
{
    partial class ActivacionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Licencia = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Validar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_WhatsApp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_EnviarMac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(574, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese su licencia para activar el producto";
            // 
            // tb_Licencia
            // 
            this.tb_Licencia.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.tb_Licencia.Location = new System.Drawing.Point(672, 113);
            this.tb_Licencia.Name = "tb_Licencia";
            this.tb_Licencia.Size = new System.Drawing.Size(488, 51);
            this.tb_Licencia.TabIndex = 1;
            this.tb_Licencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Licencia_KeyPress);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(12, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 48);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Validar
            // 
            this.btn_Validar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Validar.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.btn_Validar.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Validar.Location = new System.Drawing.Point(1010, 170);
            this.btn_Validar.Name = "btn_Validar";
            this.btn_Validar.Size = new System.Drawing.Size(150, 48);
            this.btn_Validar.TabIndex = 3;
            this.btn_Validar.Text = "Validar";
            this.btn_Validar.UseVisualStyleBackColor = false;
            this.btn_Validar.Click += new System.EventHandler(this.btn_Validar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(652, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(508, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Puedes adquirir tu licencia de uso en";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(750, 417);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(410, 37);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://KarateSolutions.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_WhatsApp
            // 
            this.btn_WhatsApp.BackColor = System.Drawing.Color.Transparent;
            this.btn_WhatsApp.BackgroundImage = global::karate1.Properties.Resources.whatsappbtn1;
            this.btn_WhatsApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_WhatsApp.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.btn_WhatsApp.ForeColor = System.Drawing.Color.Green;
            this.btn_WhatsApp.Location = new System.Drawing.Point(1071, 474);
            this.btn_WhatsApp.Name = "btn_WhatsApp";
            this.btn_WhatsApp.Size = new System.Drawing.Size(80, 76);
            this.btn_WhatsApp.TabIndex = 6;
            this.btn_WhatsApp.UseVisualStyleBackColor = false;
            this.btn_WhatsApp.Click += new System.EventHandler(this.btn_WhatsApp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MintCream;
            this.label3.Location = new System.Drawing.Point(829, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Asistencia ===>";
            // 
            // btn_EnviarMac
            // 
            this.btn_EnviarMac.BackColor = System.Drawing.Color.Transparent;
            this.btn_EnviarMac.Font = new System.Drawing.Font("MV Boli", 16.2F);
            this.btn_EnviarMac.ForeColor = System.Drawing.Color.OliveDrab;
            this.btn_EnviarMac.Location = new System.Drawing.Point(12, 513);
            this.btn_EnviarMac.Name = "btn_EnviarMac";
            this.btn_EnviarMac.Size = new System.Drawing.Size(175, 61);
            this.btn_EnviarMac.TabIndex = 8;
            this.btn_EnviarMac.Text = "Enviar Id";
            this.btn_EnviarMac.UseVisualStyleBackColor = false;
            // 
            // ActivacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::karate1.Properties.Resources.background_lic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1200, 630);
            this.Controls.Add(this.btn_EnviarMac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_WhatsApp);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Validar);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tb_Licencia);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivacionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivacionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Licencia;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Validar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btn_WhatsApp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_EnviarMac;
    }
}