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
    public partial class Form2 : Form
    {
        int velocidadtrafico;
        int velocidadcarretera;
        int velocidadjugador = 12;
        int score, score2;
        int imagenCoche;

        Random rand = new Random();
        Random posicionCoche = new Random();

        bool izquierda, izquierda2;
        bool derecha, derecha2;


        public Form2()
        {
            InitializeComponent();
            instrucciones();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            //jugador1
            if (e.KeyCode == Keys.A)
            {
                izquierda = true;
            }
            if (e.KeyCode == Keys.D)
            {
                derecha = true;
            }

            //jugador2
            if (e.KeyCode == Keys.Left)
            {
                izquierda2 = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                derecha2 = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            //jugador1
            if (e.KeyCode == Keys.A)
            {
                izquierda = false;
            }
            if (e.KeyCode == Keys.D)
            {
                derecha = false;
            }

            //jugador2
            if (e.KeyCode == Keys.Left)
            {
                izquierda2 = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                derecha2 = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Puntuación: " + score;
            score++;
            txtScore2.Text = "Puntuación: " + score2;
            score2++;

            //jugador1 restricción en X
            if (izquierda == true && jugador.Left > 10) //"restriccion de movimiento del jugador dentro de la carreteraer límites (5,415)
            {
                jugador.Left -= velocidadjugador; //.left (posición en las coordenadas X)
            }
            if (derecha == true && jugador.Left < 415)
            {
                jugador.Left += velocidadjugador;
            }
            //jugador2 restricción en X
            if (izquierda2 == true && jugador2.Left > 10) 
            {
                jugador2.Left -= velocidadjugador; 
            }
            if (derecha2 == true && jugador2.Left < 415)
            {
                jugador2.Left += velocidadjugador;
            }

            //bucle para dar el efecto de desplazamiento sobre la carretera siempre y cuando el timer funcione

            //carretera jugador1
            Carretera1.Top += velocidadcarretera;
            Carretera2.Top += velocidadcarretera;
            //carretera jugador2
            Carretera11.Top += velocidadcarretera;
            Carretera22.Top += velocidadcarretera;

            //carretera jugador1
            if (Carretera2.Top > 519)
            {
                Carretera2.Top = -519;
            }
            if (Carretera1.Top > 519)
            {
                Carretera1.Top = -519;
            }

            //carretera jugador2
            if (Carretera22.Top > 519)
            {
                Carretera22.Top = -519;
            }
            if (Carretera11.Top > 519)
            {
                Carretera11.Top = -519;
            }

            //bucle para hacer que los coches AI aparezcan una y otra vez cuando lleguen al final de la carretera

            //AI jugador1  
            AI1.Top += velocidadtrafico;
            AI2.Top += velocidadtrafico;

            //AI jugador2
            AI11.Top += velocidadtrafico;
            AI22.Top += velocidadtrafico;

            //condicion para que las AI del jugador1 aparezcan
            if (AI1.Top > 530)
            {
                changeAIcars(AI1);
            }
            if (AI2.Top > 530)
            {
                changeAIcars(AI2);
            }

            //condicion para que las AI del jugador1 aparezcan
            if (AI11.Top > 530)
            {
                changeAIcars(AI11);
            }
            if (AI22.Top > 530)
            {
                changeAIcars(AI22);
            }

            //condicion en caso de que el jugador1 y/o jugador2 se choque con un obstaculo, tanto AI1/AI11 como AI2//AI22
            if ((jugador.Bounds.IntersectsWith(AI1.Bounds) || jugador.Bounds.IntersectsWith(AI2.Bounds)))
            {
                finalizar();
            }

            if ((jugador2.Bounds.IntersectsWith(AI11.Bounds) || jugador2.Bounds.IntersectsWith(AI22.Bounds)))
            {
                finalizar2();
            }



        }

        private void changeAIcars(PictureBox coche)
        {
            //se genera un random del 1 al 10 para actualizar los pictureboxes de las AI para dar el efecto de circular en una carretera real con coches diferentes
            imagenCoche = rand.Next(1, 3);

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

            coche.Top = posicionCoche.Next(100, 400) * -1;

            if ((string)coche.Tag == "cocheizquierda2")
            {
                coche.Left = posicionCoche.Next(5, 200);
            }
            if ((string)coche.Tag == "cochederecha2")
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
            premio2.Visible = true;
            premio2.BringToFront();
            premio.BringToFront();

            premio.Image = Properties.Resources.perder;
            premio2.Image = Properties.Resources.ganar;

            btnStart.Enabled = true;


        }

        private void finalizar2()
        {
            sonidochoque();
            timerJuego.Stop();

            explosion2.Visible = true;
            jugador2.Controls.Add(explosion2);
            explosion2.Location = new Point(-8, 5);
            explosion2.BackColor = Color.Transparent;

            premio.Visible = true;
            premio2.Visible = true;
            premio2.BringToFront();
            premio.BringToFront();

            premio.Image = Properties.Resources.ganar;
            premio2.Image = Properties.Resources.perder;

            btnStart.Enabled = true;
        }

        private void resetear()
        {
            //jugador1
            izquierda = false;
            derecha = false;
            //jugador2
            izquierda2 = false;
            derecha2 = false;

            btnStart.Enabled = false;

            //jugador1
            explosion.Visible = false;
            premio.Visible = false;
            //jugador2
            explosion2.Visible = false;
            premio2.Visible = false;

            //jugador1
            score = 0;
            premio.Image = Properties.Resources.perder;
            //jugador2
            score2 = 0;
            premio2.Image = Properties.Resources.perder;
       

            velocidadcarretera = 12;
            velocidadtrafico = 15;

            //jugador1
            AI1.Top = posicionCoche.Next(200, 500) *-1;
            AI1.Left = posicionCoche.Next(5, 200);
            AI2.Top = posicionCoche.Next(200, 500) * -1;
            AI2.Left = posicionCoche.Next(245, 422);
            //jugador2
            AI11.Top = posicionCoche.Next(200, 500) * -1;
            AI11.Left = posicionCoche.Next(5, 200);
            AI22.Top = posicionCoche.Next(200, 500) * -1;
            AI22.Left = posicionCoche.Next(245, 422);

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
                    imagenCiudad.Image = Properties.Resources.barcelonafoto;
                    imagenCiudad2.Image = Properties.Resources.barcelonafoto;
                    break;
                case 2:
                    txtciudad.Text = "Castefa";
                    imagenCiudad.Image = Properties.Resources.castefafoto;
                    imagenCiudad2.Image = Properties.Resources.castefafoto;
                    break;
                case 3:
                    txtciudad.Text = "Cádiz";
                    imagenCiudad.Image = Properties.Resources.cadizfoto;
                    imagenCiudad2.Image = Properties.Resources.cadizfoto;
                    break;
                case 4:
                    txtciudad.Text = "Varsovia";
                    imagenCiudad.Image = Properties.Resources.varsoviafoto;
                    imagenCiudad2.Image = Properties.Resources.varsoviafoto;
                    break;
                case 5:
                    txtciudad.Text = "Amsterdam";
                    imagenCiudad.Image = Properties.Resources.amsterdamfoto;
                    imagenCiudad2.Image = Properties.Resources.amsterdamfoto;
                    break;
                case 6:
                    txtciudad.Text = "Sidney";
                    imagenCiudad.Image = Properties.Resources.sydneyfoto;
                    imagenCiudad2.Image = Properties.Resources.sydneyfoto;
                    break;
                case 7:
                    txtciudad.Text = "Moscú";
                    imagenCiudad.Image = Properties.Resources.moscufoto;
                    imagenCiudad2.Image = Properties.Resources.moscufoto;
                    break;
            }
        }
        private void instrucciones()
        {
            MessageBox.Show("INSTRUCCIONES DEL JUEGO");
            MessageBox.Show("Mueve tu coche de izquierda a derecha, Jugador1 (<- ->) y Jugador2 ('A' 'D'), para esquivar al resto de vehículos. Consigue la máxima puntuación para ganar en la ciudad indicada");

        }

        //botón
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
