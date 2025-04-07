using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace version1
{
    public partial class MAIN: Form
    {
        public MAIN()
        {
            InitializeComponent();
        }
        Socket server;
        string id;
        string idP;
        string contra;
        int tiempo;
        Thread atender;

        public void setServer(Socket server)
        {
            this.server = server;
        }
        public void setId(string id)
        {
            this.id = id;
        }
        public void setContra(string contra)
        {
            this.contra = contra;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg = new byte[80];
                // recibo mensaje del servidor
                server.Receive(msg);
                // Lo convierto a string y lo 'limpio'
                string mensaje = Encoding.ASCII.GetString(msg).Split('\0')[0];
                // lo divido en trozos
                string[] trozos = mensaje.Split('/');
                string op = trozos[0];
                switch (op)
                {
                    case "a"://Cerrar
                        {

                        }
                    break;

                    case "l"://Actualizar lista
                        {
                            string[] nombres = new string[100];
                            int n = 0;
                            for (int i = 2; i < trozos.Length; i++)
                            {
                                nombres[n] = trozos[i];//Guardamos solo los nombres llegados del servidor
                                n++;
                            }
                            if (trozos[0] == "l")
                            {
                                labelCon.Invoke(new Action(() => labelCon.Text = string.Join("\n", nombres)));
                            }
                        }
                    break;

                    case "consulta3":
                        { 
                            //Tratamos la respuesta del servidor
                            string[] partes = mensaje.Split('/');
                            string[] resp = new string[partes.Length -1];
                            int n = 0;
                            for (int i = 1; i < partes.Length; i++)
                            {
                                resp[n] = partes[i];
                                n++;
                            }
                            this.Invoke((MethodInvoker)delegate
                            {
                                label1.Visible = false;
                                idPbox.Visible = false;
                                button1.Visible = false;
                                MessageBox.Show("Han jugado las siguientes personas: " + string.Join(", ", resp));
                            });
                            
                        }
                    break;

                    case "consulta4":
                        {
                            string[] partes = mensaje.Split('/');
                            string[] resp = new string[partes.Length - 1];
                            int n = 0;
                            for(int i = 1; i < partes.Length; i++)
                            {
                                resp[n] = partes[i];
                                n++;
                            }
                            MessageBox.Show("Has jugado con las siguientes personas: " + string.Join(", ", resp));
                        }
                    break;

                    case "consulta5":
                        {
                            string[] partes = mensaje.Split('/');
                            if (partes[1] != null)
                            {
                                MessageBox.Show("Has jugado " + partes[1] + " partidas en ese tiempo");
                            }
                            this.Invoke((MethodInvoker)delegate
                            {
                                labeltiempo.Visible = false;
                                TBox.Visible = false;
                                buscartiempo.Visible = false;
                            });
                        }
                    break;
                    default:
                        {

                        }
                    break;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            idPbox.Visible = true;
            button1.Visible = true;
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            loginLabel.Visible = true;
            loginLabel.Text = "ID: " + id;
            atender = new Thread(AtenderServidor);
            atender.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //guardar idP
            idP = idPbox.Text;

            string mensaje = "3/" + id + "/" + idP;
            // Enviamos al servidor el registro tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void conQuePersonasHeJugadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "4/" + id + "/"+ contra;
            // Enviamos al servidor el registro tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MAIN_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labeltiempo.Visible = true;
            TBox.Visible = true;
            buscartiempo.Visible = true;

        }

        private void mENUDECONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void buscartiempo_Click(object sender, EventArgs e)
        {
            try
            {
                tiempo = Convert.ToInt32(TBox.Text);
                string mensaje = "5/" + id + "/" + contra + "/" + tiempo;
                // Enviamos al servidor el registro tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            catch
            {
                MessageBox.Show("Introduce el tiempo en el formato correcto");
            }
        }
    }
}
