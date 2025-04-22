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
        bool cerrado=false;
        int tiempo;
        Thread atender;
        FormInvitacion formInvi = new FormInvitacion();

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

        public bool getCerrado()
        {
            return cerrado;
        }

        private void AtenderServidor()
        {
            bool terminar = false;
            while (terminar==false)
            {
                byte[] msg = new byte[80];
                string op;
                string[] trozos;
                string mensaje;
                // recibo mensaje del servidor
                try
                {
                    server.Receive(msg);
                    // Lo convierto a string y lo 'limpio'
                    mensaje = Encoding.ASCII.GetString(msg).Split('\0')[0];
                    // lo divido en trozos
                    trozos = mensaje.Split('/');
                    op = trozos[0];
                }
                catch
                {
                    op = "a";
                    trozos = null;
                    mensaje = null;
                    terminar=true;
                }
                switch (op)
                {
                    case "a"://Cerrar
                        {
                            MessageBox.Show("Desconectado");
                            cerrado = true;
                            this.Close();
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

                    case "recibirInvitacion"://trozos[1]: nombreHost*partida
                        {
                            string[] trozos2 = trozos[1].Split('*'); //trozos2=[nombrehost][partida]
                            formInvi.setHost(trozos2[0]);
                            formInvi.ShowDialog();
                            string respuesta = "7/" + formInvi.getRespuesta() + "/" + trozos[0] + "\0";
                            msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                            server.Send(msg);
                        }
                    break;

                    case "partidaIniciada":
                        {

                        }
                    break;

                    case "partidaRechazada": //	trozos[1]= id de la partida * rechazador
                        {
                            idP = trozos[1].Split('*')[0];
                            MessageBox.Show(trozos[1].Split('*')[1] + " ha rechazado la partida. Por ende, la partida no se iniciará");
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

        private void iNVITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            invitadoBox.Visible = true;
            invitarButton.Visible = true;
            label4.Visible = true;
        }

        private void invitarButton_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            invitadoBox.Visible = false;
            invitarButton.Visible = false;
            label4.Visible = false;
            string invitados=invitadoBox.Text;
            string mensaje = "6/" + id + "/" + contra + "/" + invitados;

            //Lo enviamos por el socket (Codigo 6 - Invitar a jugadores)
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
