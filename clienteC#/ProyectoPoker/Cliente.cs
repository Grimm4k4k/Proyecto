using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace version1
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        Socket server;
        FormLogin FLogin = new FormLogin();
        FormRegister FRegister = new FormRegister();
        MAIN FConsulta = new MAIN();
        string nombre, id, dni, contra;
        int edad;
        bool logged = false,connected = false;

        private void BLogin_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {
                MessageBox.Show("Primero conectese al servidor");
            }
            else 
            {
                if (logged == false)
                {
                    FLogin.ShowDialog();
                    this.id = FLogin.getId();
                    this.contra = FLogin.getContra();
                    string mensaje = "2/" + id + "/" + contra;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    //tratar la respuesta bien

                    if (Convert.ToInt32(mensaje) == 1)
                    {
                        logged = true;
                        FConsulta.setId(this.id);
                        FConsulta.setServer(this.server);
                        FConsulta.setContra(this.contra);
                        FConsulta.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido iniciar sesión");
                    }

                }
                else
                {
                    FConsulta.ShowDialog();
                }
            }
        }

        private void BRegister_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {
                MessageBox.Show("Primero conectese al servidor");
            }
            else
            {
                FRegister.ShowDialog();
                this.nombre = FRegister.getNombre();
                this.dni = FRegister.getDni();
                this.edad = FRegister.getEdad();
                this.id = FRegister.getId();
                this.contra = FRegister.getContra();
                string mensaje = "1/" + id + "/" + contra + "/" + dni + "/" + nombre + "/" + edad;
                // Enviamos al servidor el registro tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor si es 0 todo ha ido bien
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "1")
                {
                    MessageBox.Show("Usted se ha registrado correctamente");
                    
                }
                else
                {
                    MessageBox.Show("Error en el registro");
                }
            }
        }

        private void Bcon_Click(object sender, EventArgs e)
        {
            if (Bcon.Text == "Desconectar")
            {
                //Mensaje de desconexión
                string mensaje = "0";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.BackColor = Color.Gray;
                Bcon.Text = "Conectar";
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9001);
                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    Bcon.Text = "Desconectar";
                    MessageBox.Show("Conectado");
                    connected=true;

                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
            }
        }
    }
}
