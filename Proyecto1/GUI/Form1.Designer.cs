
namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            IPBox = new TextBox();
            portBox = new TextBox();
            AppIDBox = new TextBox();
            topicBox = new TextBox();
            botonSubs = new Button();
            BotonDesubs = new Button();
            publishText = new RichTextBox();
            botonPublicar = new Button();
            botonRecibir = new Button();
            receiveText = new RichTextBox();
            receiveTopicBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            Advertencia_IP = new Label();
            Advertencia_Port = new Label();
            IP_Label = new Label();
            Port_Label = new Label();
            Advertencia_conexion = new Label();
            label7 = new Label();
            Advertencia_ID = new Label();
            Advertencia_Tema = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 111);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "MQBroker IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 195);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 1;
            label2.Text = "MQBroker Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 290);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 2;
            label3.Text = "AppID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(560, 56);
            label4.Name = "label4";
            label4.Size = new Size(57, 23);
            label4.TabIndex = 3;
            label4.Text = "Tema:";
            // 
            // IPBox
            // 
            IPBox.Location = new Point(171, 108);
            IPBox.Name = "IPBox";
            IPBox.Size = new Size(218, 27);
            IPBox.TabIndex = 4;
            // 
            // portBox
            // 
            portBox.Location = new Point(171, 195);
            portBox.Name = "portBox";
            portBox.Size = new Size(218, 27);
            portBox.TabIndex = 5;
            // 
            // AppIDBox
            // 
            AppIDBox.Location = new Point(171, 290);
            AppIDBox.Name = "AppIDBox";
            AppIDBox.Size = new Size(218, 27);
            AppIDBox.TabIndex = 6;
            // 
            // topicBox
            // 
            topicBox.Location = new Point(480, 105);
            topicBox.Name = "topicBox";
            topicBox.Size = new Size(220, 27);
            topicBox.TabIndex = 7;
            // 
            // botonSubs
            // 
            botonSubs.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            botonSubs.Location = new Point(533, 178);
            botonSubs.Name = "botonSubs";
            botonSubs.Size = new Size(114, 66);
            botonSubs.TabIndex = 8;
            botonSubs.Text = "Suscribirse";
            botonSubs.UseVisualStyleBackColor = true;
            botonSubs.Click += botonSubs_Click;
            // 
            // BotonDesubs
            // 
            BotonDesubs.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            BotonDesubs.Location = new Point(533, 259);
            BotonDesubs.Name = "BotonDesubs";
            BotonDesubs.Size = new Size(114, 66);
            BotonDesubs.TabIndex = 9;
            BotonDesubs.Text = "Desuscribirse";
            BotonDesubs.UseVisualStyleBackColor = true;
            BotonDesubs.Click += BotonDesubs_Click;
            // 
            // publishText
            // 
            publishText.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            publishText.Location = new Point(802, 81);
            publishText.Name = "publishText";
            publishText.Size = new Size(232, 252);
            publishText.TabIndex = 10;
            publishText.Text = "";
            // 
            // botonPublicar
            // 
            botonPublicar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            botonPublicar.Location = new Point(856, 357);
            botonPublicar.Name = "botonPublicar";
            botonPublicar.Size = new Size(106, 66);
            botonPublicar.TabIndex = 11;
            botonPublicar.Text = "Publicar";
            botonPublicar.UseVisualStyleBackColor = true;
            botonPublicar.Click += botonPublicar_Click;
            // 
            // botonRecibir
            // 
            botonRecibir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            botonRecibir.Location = new Point(1181, 357);
            botonRecibir.Name = "botonRecibir";
            botonRecibir.Size = new Size(106, 66);
            botonRecibir.TabIndex = 13;
            botonRecibir.Text = "Recibir";
            botonRecibir.UseVisualStyleBackColor = true;
            botonRecibir.Click += botonRecibir_Click;
            // 
            // receiveText
            // 
            receiveText.Location = new Point(1127, 121);
            receiveText.Name = "receiveText";
            receiveText.Size = new Size(232, 212);
            receiveText.TabIndex = 12;
            receiveText.Text = "";
            // 
            // receiveTopicBox
            // 
            receiveTopicBox.Location = new Point(1127, 78);
            receiveTopicBox.Name = "receiveTopicBox";
            receiveTopicBox.Size = new Size(232, 27);
            receiveTopicBox.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(802, 47);
            label5.Name = "label5";
            label5.Size = new Size(209, 20);
            label5.TabIndex = 15;
            label5.Text = "Creación de una publicación:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(1127, 47);
            label6.Name = "label6";
            label6.Size = new Size(170, 20);
            label6.TabIndex = 16;
            label6.Text = "Recepción de mensajes:";
            // 
            // Advertencia_IP
            // 
            Advertencia_IP.AutoSize = true;
            Advertencia_IP.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic);
            Advertencia_IP.ForeColor = Color.Red;
            Advertencia_IP.Location = new Point(72, 145);
            Advertencia_IP.Name = "Advertencia_IP";
            Advertencia_IP.Size = new Size(230, 19);
            Advertencia_IP.TabIndex = 17;
            Advertencia_IP.Text = "Debe de ingresar un número válido";
            Advertencia_IP.Visible = false;
            // 
            // Advertencia_Port
            // 
            Advertencia_Port.AutoSize = true;
            Advertencia_Port.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic);
            Advertencia_Port.ForeColor = Color.Red;
            Advertencia_Port.Location = new Point(72, 232);
            Advertencia_Port.Name = "Advertencia_Port";
            Advertencia_Port.Size = new Size(230, 19);
            Advertencia_Port.TabIndex = 18;
            Advertencia_Port.Text = "Debe de ingresar un número válido";
            Advertencia_Port.Visible = false;
            // 
            // IP_Label
            // 
            IP_Label.AutoSize = true;
            IP_Label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IP_Label.Location = new Point(533, 362);
            IP_Label.Name = "IP_Label";
            IP_Label.Size = new Size(26, 20);
            IP_Label.TabIndex = 21;
            IP_Label.Text = "IP:";
            IP_Label.Visible = false;
            // 
            // Port_Label
            // 
            Port_Label.AutoSize = true;
            Port_Label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Port_Label.Location = new Point(533, 402);
            Port_Label.Name = "Port_Label";
            Port_Label.Size = new Size(41, 20);
            Port_Label.TabIndex = 22;
            Port_Label.Text = "Port:";
            Port_Label.Visible = false;
            // 
            // Advertencia_conexion
            // 
            Advertencia_conexion.AutoSize = true;
            Advertencia_conexion.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic);
            Advertencia_conexion.ForeColor = Color.DarkSlateGray;
            Advertencia_conexion.Location = new Point(106, 395);
            Advertencia_conexion.Name = "Advertencia_conexion";
            Advertencia_conexion.Size = new Size(224, 19);
            Advertencia_conexion.TabIndex = 23;
            Advertencia_conexion.Text = "No se pudo establecer la conexión";
            Advertencia_conexion.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(184, 56);
            label7.Name = "label7";
            label7.Size = new Size(86, 23);
            label7.TabIndex = 24;
            label7.Text = "Conexión:";
            // 
            // Advertencia_ID
            // 
            Advertencia_ID.AutoSize = true;
            Advertencia_ID.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic);
            Advertencia_ID.ForeColor = Color.Red;
            Advertencia_ID.Location = new Point(72, 325);
            Advertencia_ID.Name = "Advertencia_ID";
            Advertencia_ID.Size = new Size(230, 19);
            Advertencia_ID.TabIndex = 25;
            Advertencia_ID.Text = "Debe de ingresar un número válido";
            Advertencia_ID.Visible = false;
            // 
            // Advertencia_Tema
            // 
            Advertencia_Tema.AutoSize = true;
            Advertencia_Tema.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic);
            Advertencia_Tema.ForeColor = Color.MidnightBlue;
            Advertencia_Tema.Location = new Point(494, 138);
            Advertencia_Tema.Name = "Advertencia_Tema";
            Advertencia_Tema.Size = new Size(190, 19);
            Advertencia_Tema.TabIndex = 26;
            Advertencia_Tema.Text = "Debe ingresa un tema válido";
            Advertencia_Tema.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 450);
            Controls.Add(Advertencia_Tema);
            Controls.Add(Advertencia_ID);
            Controls.Add(label7);
            Controls.Add(Advertencia_conexion);
            Controls.Add(Port_Label);
            Controls.Add(IP_Label);
            Controls.Add(Advertencia_Port);
            Controls.Add(Advertencia_IP);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(receiveTopicBox);
            Controls.Add(botonRecibir);
            Controls.Add(receiveText);
            Controls.Add(botonPublicar);
            Controls.Add(publishText);
            Controls.Add(BotonDesubs);
            Controls.Add(botonSubs);
            Controls.Add(topicBox);
            Controls.Add(AppIDBox);
            Controls.Add(portBox);
            Controls.Add(IPBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Proyecto I - AEDI";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox IPBox;
        private TextBox portBox;
        private TextBox AppIDBox;
        private TextBox topicBox;
        private Button botonSubs;
        private Button BotonDesubs;
        private RichTextBox publishText;
        private Button botonPublicar;
        private Button botonRecibir;
        private RichTextBox receiveText;
        private TextBox receiveTopicBox;
        private Label label5;
        private Label label6;
        private Label Advertencia_IP;
        private Label Advertencia_Port;
        private Label IP_Label;
        private Label Port_Label;
        private Label Advertencia_conexion;
        private Label label7;
        private Label Advertencia_ID;
        private Label Advertencia_Tema;
    }
}
