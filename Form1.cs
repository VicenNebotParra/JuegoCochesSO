using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegocochesSO
{
    public partial class Form1 : Form
    {
        int velocidadtrafico;
        int velocidadcarretera;
        int velocidadjugador = 12;
        int score;
        int imagenCoche;

        Random rand = new Random();
        Random posicionCoche = new Random();

        bool izquierda;
        bool derecha;


        public Form1()
        {
            InitializeComponent();
            instrucciones();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                izquierda = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                derecha = true;
            }

            //if (e.KeyCode == Keys.A)
            //{
            //    izquierda = true;
            //}
            //if (e.KeyCode == Keys.D)
            //{
            //    derecha = true;
            //}

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                izquierda = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                derecha = false;
            }

            if (e.KeyCode == Keys.A)
            {
                izquierda = true;
            }
            if (e.KeyCode == Keys.D)
            {
                derecha = true;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Puntuación: " + score;
            score++;


            if (izquierda == true && jugador.Left > 10) //"restriccion de movimiento del jugador dentro de la carreteraer límites (5,415)
            {
                jugador.Left -= velocidadjugador; //.left (posición en las coordenadas X)
            }
            if (derecha == true && jugador.Left < 415)
            {
                jugador.Left += velocidadjugador;
            }

            //bucle para dar el efecto de desplazamiento sobre la carretera siempre y cuando el timer funcione
            carretera1.Top += velocidadcarretera;
            Carretera2.Top += velocidadcarretera;

            if (Carretera2.Top > 519)
            {
                Carretera2.Top = -519;
            }
            if (carretera1.Top > 519)
            {
                carretera1.Top = -519;
            }


            //bucle para hacer que los coches AI aparezcan una y otra vez cuando lleguen al final de la carretera
            AI1.Top += velocidadtrafico;
            AI2.Top += velocidadtrafico;

            if (AI1.Top > 530)
            {
                changeAIcars(AI1);
            }
            if (AI2.Top > 530)
            {
                changeAIcars(AI2);
            }

            //condicion en caso de que el jugador se choque con un obstaculo, tanto AI1 como AI2
            if (jugador.Bounds.IntersectsWith(AI1.Bounds) || jugador.Bounds.IntersectsWith(AI2.Bounds))
            {
                finalizar();
            }


            //condiciones para las medallas segun la puntuacion obtenida
            if (score > 40 && score < 500)
            {
                premio.Image = Properties.Resources.bronze1;
            }


            if (score > 500 && score < 2000)
            {
                premio.Image = Properties.Resources.silver1;
                velocidadcarretera = 20;
                velocidadtrafico = 22;
            }

            if (score > 2000)
            {
                premio.Image = Properties.Resources.gold1;
                velocidadtrafico = 27;
                velocidadcarretera = 25;
            }


        }

        private void changeAIcars(PictureBox coche)
        {
            //se genera un random del 1 al 10 para actualizar los pictureboxes de las AI para dar el efecto de circular en una carretera real con coches diferentes
            imagenCoche = rand.Next(1, 10);

            switch (imagenCoche)
            {

                case 1:
                    coche.Image = Properties.Resources.ambulance;
                    break;
                case 2:
                    coche.Image = Properties.Resources.carGreen;
                    break;
                case 3:
                    coche.Image = Properties.Resources.carGrey;
                    break;
                case 4:
                    coche.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    coche.Image = Properties.Resources.carPink;
                    break;
                case 6:
                    coche.Image = Properties.Resources.CarRed;
                    break;
                case 7:
                    coche.Image = Properties.Resources.carYellow;
                    break;
                case 8:
                    coche.Image = Properties.Resources.TruckBlue;
                    break;
                case 9:
                    coche.Image = Properties.Resources.TruckWhite;
                    break;
            }


            //con esto generamos una posicion aleatoria en las AI izquierda y derecha respectivamente
            coche.Top = posicionCoche.Next(100, 400) * -1;

            if ((string)coche.Tag == "cocheizquierda")
            {
                coche.Left = posicionCoche.Next(5, 200);
            }
            if ((string)coche.Tag == "cochederecha")
            {
                coche.Left = posicionCoche.Next(245, 422);
            }
        }

        private void finalizar()
        {
            sonidochoque();

            timerJuego.Stop();

            //cn esto hacemos que cuando se llame la función finalizar el gif de la explosion aparezca sobre el coche del jugador y aparezca el premio correspondiente a la puntuación
            explosion.Visible = true;
            jugador.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            premio.Visible = true;
            premio.BringToFront();

            btnStart.Enabled = true;

        }

        private void resetear()
        {
            izquierda = false;
            derecha = false;
            btnStart.Enabled = false;
            explosion.Visible = false;
            premio.Visible = false;
           
            score = 0;
            premio.Image = Properties.Resources.bronze1;

            velocidadcarretera = 12;
            velocidadtrafico = 15;

            AI1.Top = posicionCoche.Next(200, 500) *-1;
            AI1.Left = posicionCoche.Next(5, 200);

            AI2.Top = posicionCoche.Next(200, 500) * -1;
            AI2.Left = posicionCoche.Next(245, 422);

            cambiarCiudad();

            timerJuego.Start();

        }


        private void cambiarCiudad()
        {

            int Ciudades = rand.Next(1, 7);
            switch (Ciudades)
            {
                case 1:
                    txtciudad.Text = "Barcelona";
                    break;
                case 2:
                    txtciudad.Text = "Castefa";
                    break;
                case 3:
                    txtciudad.Text = "Cádiz";
                    break;
                case 4:
                    txtciudad.Text = "Varsovia";
                    break;
                case 5:
                    txtciudad.Text = "Amsterdam";
                    break;
                case 6:
                    txtciudad.Text = "Sidney";
                    break;
                case 7:
                    txtciudad.Text = "Moscú";
                    break;

            }
        }
        private void instrucciones()
        {
            MessageBox.Show("INSTRUCCIONES DEL JUEGO");
            MessageBox.Show("Mueve tu coche de izquierda a derecha (<- ->) para esquivar al resto de vehículos. Consigue la máxima puntuación para ganar medallas según tu destreza");
        }

        private void Reiniciar(object sender, EventArgs e)
        {
            resetear();
            System.Media.SoundPlayer musica = new System.Media.SoundPlayer(Properties.Resources.audio2);
            musica.Play();
            musica.PlayLooping();
        }

        private void sonidochoque()
        {
            System.Media.SoundPlayer choque = new System.Media.SoundPlayer(Properties.Resources.hit);
            choque.Play();
        }
    }
}
