using MQClientNS;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private MQClientNS.MQClient cliente;

        public void inicializacion_cliente(string ip, int port, int user)
        {
            cliente = new MQClientNS.MQClient(ip, port, user);
        }

        public bool validacionIP(string IP)
        {
            string[] partesIP = IP.Split(".");

            if (partesIP.Length != 4)
            {
                return false;
            }

            int contador = 0;

            while (contador < 4)
            {
                if (!int.TryParse(partesIP[contador], out int numero))
                    return false;

                if (numero < 0 || numero > 255)
                    return false;

                contador++;
            }

            return true;
        }

        public bool recepcionDatosCliente()
        {

            string ip_entrada = IPBox.Text;
            string port_entrada = portBox.Text;
            string AppID_entrada = AppIDBox.Text;

            int numeroPort = -1;
            int numeroID = -1;


            if (validacionIP(ip_entrada))
            {
                Advertencia_IP.Hide();
            }
            else
            {
                Advertencia_IP.Show();
            }

            if (int.TryParse(port_entrada, out numeroPort))
            {
                Advertencia_Port.Hide();

            }
            else
            {
                Advertencia_Port.Show();
            }

            if (int.TryParse(AppID_entrada, out numeroID))
            {
                Advertencia_ID.Hide();
            }
            else
            {
                Advertencia_ID.Show();
            }

            if (numeroPort != -1 && validacionIP(ip_entrada) == true && numeroID != -1)
            {
                inicializacion_cliente(ip_entrada, numeroPort, numeroID);

                IP_Label.Show();
                IP_Label.Text = "IP: " + ip_entrada;

                Port_Label.Show();
                Port_Label.Text = "Port: " + numeroPort.ToString();

                Advertencia_conexion.Hide();
                Advertencia_Tema.Show();
                return true;
            }
            else
            {
                Advertencia_conexion.Show();
                return false;
            }

        }

        private void botonSubs_Click(object sender, EventArgs e)
        {
            bool validacion_datos_cliente = recepcionDatosCliente();
            Console.WriteLine(validacion_datos_cliente);

            string topic_entrada = topicBox.Text;

            if (cliente != null)
            {

                if (topic_entrada == null || topic_entrada == "")
                {
                    Advertencia_Tema.Show();

                }
                else
                {
                    if (validacion_datos_cliente == true)
                    {
                        MQClientNS.Topic topic = new MQClientNS.Topic(topic_entrada);
                        Console.WriteLine("1212");
                        cliente.Subscribe(topic);
                    }
                    Advertencia_Tema.Hide();
                }
            }

        }

        private void BotonDesubs_Click(object sender, EventArgs e)
        {
            bool validacion_datos_cliente = recepcionDatosCliente();

            string topic_entrada = topicBox.Text;

            if (cliente != null)
            {

                if (topic_entrada == null || topic_entrada == "")
                {
                    Advertencia_Tema.Show();

                }
                else
                {
                    if (validacion_datos_cliente)
                    {
                        MQClientNS.Topic topic = new MQClientNS.Topic(topic_entrada);
                        cliente.Unsubscribe(topic);
                    }
                    Advertencia_Tema.Hide();
                }
            }

        }

        private void botonPublicar_Click(object sender, EventArgs e)
        {
            bool validacion_datos_cliente = recepcionDatosCliente();
            string mensaje_entrada = publishText.Text;
            string topic_entrada = topicBox.Text;

            if (cliente != null)
            {

                if (topic_entrada == null || topic_entrada == "")
                {
                    Advertencia_Tema.Show();
                }
                else
                {
                    Advertencia_Tema.Hide();
                }

                if (mensaje_entrada == null || mensaje_entrada == "")
                {

                    Publish_Advertencia.Show();
                }


                if (mensaje_entrada != null && mensaje_entrada != "" && topic_entrada != null && topic_entrada != "")
                {
                    Publish_Advertencia.Hide();

                    if (validacion_datos_cliente)
                    {
                        MQClientNS.Message mensaje = new MQClientNS.Message(mensaje_entrada);
                        MQClientNS.Topic topic = new MQClientNS.Topic(topic_entrada);
                        cliente.publish(topic, mensaje);
                    }

                }
            }
        }

        private void botonRecibir_Click(object sender, EventArgs e)
        {
            bool validacion_datos_cliente = recepcionDatosCliente();
            string topic_entrada = topicBox.Text;

            if (cliente != null)
            {

                if (topic_entrada == null || topic_entrada == "")
                {
                    Advertencia_Tema.Show();
                }
                else
                {
                    Advertencia_Tema.Hide();
                }

                if (topic_entrada != null && topic_entrada != "")
                {

                    if (validacion_datos_cliente)
                    {
                        MQClientNS.Topic topic = new Topic(topic_entrada);
                        MQClientNS.Message message = cliente.receive(topic);

                        string display_message = "";

                        display_message = message.ToString();

                        receiveText.Text = display_message;
                        receiveTopicBox.Text = topic_entrada;
                    }

                }
            }
        }
    }
}
