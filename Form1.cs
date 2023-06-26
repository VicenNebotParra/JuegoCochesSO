using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using juegocochesSO;

namespace CLIENTEPARCHIS
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atenderalservidor;
        


        private void atenderservidor()
        {

            while (true)
            {
                int x;
                byte[] msg2 = new byte[512];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                x = Convert.ToInt32(trozos[0]);
                string mensajereal = trozos[1].Split('\0')[0];


                switch (x)
                {

                    case 0:
                       //server.Shutdown(SocketShutdown.Both);
                        //server.Close();
                        MessageBox.Show("Sesión cerrada");
                        break;

                    case 1: //casos 1 2 i 3 son las consultas  
                        MessageBox.Show(mensajereal);
                        break;

                    case 2:
                        MessageBox.Show(mensajereal);
                        break;

                    case 3:
                        MessageBox.Show(mensajereal);
                        break;

                    case 4: //Login
                        if (mensajereal == "Logueado correctamente")
                        {
                            MessageBox.Show(mensajereal);
                            //ahora se tendra que mostrar la lista de conectados
                        }
                        else
                        {
                            MessageBox.Show(mensajereal);
                        }
                        break;

                    case 5: //Registrarse
                        if (mensajereal == "Registrado")
                        {
                            MessageBox.Show(mensajereal);
                            //Ahora se muestra la lista de conectados

                        }
                        else
                        {
                            MessageBox.Show(mensajereal);
                        }
                        break;

                    case 6:

                        this.Invoke(new Action(() => { listaconectados(mensajereal); }));
                        break;

                    case 7:

                        DialogResult respuesta;
                        string[] trozos3 = mensajereal.Split('/');
                        int id_partida = Convert.ToInt32(trozos[1]);
                        respuesta = MessageBox.Show(trozos[2] + " te ha invitado a jugar con:" + trozos[3].Replace('-', ' '), "Invitación", MessageBoxButtons.OKCancel);
                        if (respuesta == DialogResult.OK)
                        {
                            string mensaje = "8/" + id_partida + "/" + textBox1.Text + "/0";

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else
                        {
                            string mensaje = "8/" + id_partida + "/" + textBox1.Text + "/1";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        break;

                    case 8:


                        int acepta = Convert.ToInt32(trozos[3]);
                        if (acepta == 0)
                        {
                            MessageBox.Show(" Se ha aceptado la invitación");
                            this.Invoke(new Action(() =>
                            {
                                muestrabotonfrente();
                            }));
                            
                        }
                        else if (acepta == 1)
                        {
                            MessageBox.Show(" Se ha rechazado la invitación");

                        }
                        else
                        {

                        }

                        break;

                    case 9:

                        string frase = trozos[1];
                       
                        this.Invoke(new Action(() =>
                        {
                            muestralistBox(frase);
                        }));
                       
                        break;

                    case 11:

                        MessageBox.Show(mensajereal);

                        break;

                    case 12:

                        this.Invoke(new Action(() =>
                        {
                            notificacion(mensajereal);
                        }));

                        this.Invoke(new Action(() =>
                        {
                            jugar2visible();
                        }));
                        
                        break;

                    case 13:

                        juegocochesSO.Form2 f2 = new juegocochesSO.Form2(server);
                        f2.label2.Text = textBox1.Text;
                        
                        f2.ShowDialog();
                        this.Invoke(new Action(() =>
                        {
                            terminarvisible();
                        }));


                        break;

                    case 14:


                        this.Invoke(new Action(() =>
                        {
                            jugarinvisible();
                        }));

                        break;

                    case 15:


                        this.Invoke(new Action(() =>
                        {
                            reiniciar();
                        }));

                        MessageBox.Show("Partida terminada");

                        break;


                   
                }

            }
        }

        private void notificacion(string notificacion)
        {
            label4.Text = notificacion;
        }


        private void listaconectados(string trozo)
        {
           
            matrizconectados.ColumnCount = 1;
            matrizconectados.Rows.Clear();
            matrizconectados.Refresh();
            matrizconectados.AutoResizeColumns();
            if (trozo != null && trozo !="")
            {
                string[] usuarios = trozo.Split('|');
                int numero = Convert.ToInt32(usuarios[0]);
                for(int i=0; i<numero; i++)
                {
                    matrizconectados.Rows[matrizconectados.Rows.Add()].Cells[0].Value = usuarios[i + 1];
                    matrizconectados.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }

        }

        private void reiniciar()
        {
            listBox1.Items.Clear();
            label4.Text = "";
            Jugar.BringToFront();
            TerminarPartida.Visible = false;
        }

        private void muestralistBox(string frase)
        {
            listBox1.Items.Add(frase);
        }

        private void muestrabotonfrente()
        {
            Jugar2.BringToFront();
        }
        private void jugar2visible()
        {
            Jugar2.Visible = true;
        }

        private void jugarinvisible()
        {
            Jugar.Visible = false;
        }

        private void terminarvisible()
        {
            TerminarPartida.Visible = true;
        }

        public Form1()
        {
            InitializeComponent();

            pictureBox1.BringToFront();
            Jugar.BringToFront();
            textBox2.PasswordChar = '*';
            Jugar2.Visible = false;
            TerminarPartida.Visible = false;



            //Conectarse al servidor al iniciar el form
            IPAddress direc = IPAddress.Parse("192.168.56.102"); //147.83.117.22
            IPEndPoint ipep = new IPEndPoint(direc, 9040);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                MessageBox.Show("Conectado!");
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            ThreadStart ts = delegate { atenderservidor(); };
            atenderalservidor = new Thread(ts);
            atenderalservidor.Start();

            

        }

        private void conectar_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102"); //147.83.117.22
            IPEndPoint ipep = new IPEndPoint(direc, 9045);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                MessageBox.Show("Conectado!");
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            ThreadStart ts = delegate { atenderservidor(); };
            atenderalservidor = new Thread(ts);
            atenderalservidor.Start();

            desconectar.BringToFront();
        

        }

        private void matrizconectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void enviar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Eliminar_Usuario.Checked)
                {
                    string username = Convert.ToString(textBox1.Text);
                    string contrasenya = Convert.ToString(textBox2.Text);
                    string mensaje = "11/" + username + "/" + contrasenya;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }

               
                if (Login.Checked)
                {
                    string username = Convert.ToString(textBox1.Text);
                    string contrasenya = Convert.ToString(textBox2.Text);
                    string mensaje = "4/" + username + "/" + contrasenya;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    Eliminar_Usuario.Visible = false;
                }
                if (Registrarse.Checked)
                {
                    string username = Convert.ToString(textBox1.Text);
                    string contrasenya = Convert.ToString(textBox2.Text);
                    string mensaje = "5/" + username + "/" + contrasenya;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    Eliminar_Usuario.Visible = false;
                }
                
            }
            catch (SocketException ex)
            {
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void desconectar_Click(object sender, EventArgs e) // boton cerrar sesión
        {
            string mensaje = "0/" + textBox1.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            matrizconectados.Rows.Clear();
            Eliminar_Usuario.Visible = true;
            textBox1.Clear();
            textBox2.Clear();


        }

        private void Jugar_Click(object sender, EventArgs e)
        {
           

            juegocochesSO.MenuJugar f3 = new juegocochesSO.MenuJugar();
            f3.ShowDialog();
        }

        private void Invitar_Click(object sender, EventArgs e)
        {
            bool FirstValue = true;
            string invitados = "";
            if (matrizconectados.SelectedCells.Count == 0)
            {
                MessageBox.Show("Selecciona 3 usuarios");
            }
            else
            {
                foreach (DataGridViewCell cell in matrizconectados.SelectedCells)
                {
                    if (!FirstValue)
                    {
                        invitados += "-";
                    }
                    invitados += cell.Value.ToString();
                    FirstValue = false;
                }
                string mensaje = "7/" + invitados;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comentar_Click(object sender, EventArgs e)
        { 
            if (textBox7.Text != "")
            {
                string mensaje = "10/" + textBox1.Text + "/"+ textBox1.Text + ": " + textBox7.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                textBox7.Clear();
            }
            else
            {
                MessageBox.Show("Escribe un mensaje");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //ver contraseña
            pictureBox2.BringToFront();
            textBox2.PasswordChar = '\0';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //ocultar contraseña
            pictureBox1.BringToFront();
            textBox2.PasswordChar = '*';
        }

        private void Eliminar_Usuario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Jugar2_Click(object sender, EventArgs e) // jugar con el jugador invitado
        {
            string mensaje = "9/" + textBox1.Text ;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            
        }

        private void TerminarPartida_Click(object sender, EventArgs e)
        {
            string mensaje = "12/" + textBox1.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


        }
    }
}
