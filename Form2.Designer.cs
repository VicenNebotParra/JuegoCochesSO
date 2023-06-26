namespace juegocochesSO
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.Label();
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtciudad = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtScore2 = new System.Windows.Forms.Label();
            this.imagenCiudad = new System.Windows.Forms.PictureBox();
            this.imagenCiudad2 = new System.Windows.Forms.PictureBox();
            this.premio2 = new System.Windows.Forms.PictureBox();
            this.AI22 = new System.Windows.Forms.PictureBox();
            this.AI11 = new System.Windows.Forms.PictureBox();
            this.explosion2 = new System.Windows.Forms.PictureBox();
            this.jugador2 = new System.Windows.Forms.PictureBox();
            this.Carretera22 = new System.Windows.Forms.PictureBox();
            this.Carretera11 = new System.Windows.Forms.PictureBox();
            this.premio = new System.Windows.Forms.PictureBox();
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.jugador = new System.Windows.Forms.PictureBox();
            this.Carretera2 = new System.Windows.Forms.PictureBox();
            this.Carretera1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCiudad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCiudad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.premio);
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.explosion);
            this.panel1.Controls.Add(this.jugador);
            this.panel1.Controls.Add(this.Carretera2);
            this.panel1.Controls.Add(this.Carretera1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 519);
            this.panel1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Orange;
            this.btnStart.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(454, 581);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(127, 53);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.Reiniciar);
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(12, 541);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(475, 37);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Puntuación: 0";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerJuego
            // 
            this.timerJuego.Interval = 20;
            this.timerJuego.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Agency FB", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 661);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ubicación del circuito:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtciudad
            // 
            this.txtciudad.Font = new System.Drawing.Font("Poor Richard", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtciudad.ForeColor = System.Drawing.Color.DarkRed;
            this.txtciudad.Location = new System.Drawing.Point(284, 705);
            this.txtciudad.Name = "txtciudad";
            this.txtciudad.Size = new System.Drawing.Size(475, 55);
            this.txtciudad.TabIndex = 5;
            this.txtciudad.Text = " ";
            this.txtciudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.premio2);
            this.panel2.Controls.Add(this.AI22);
            this.panel2.Controls.Add(this.AI11);
            this.panel2.Controls.Add(this.explosion2);
            this.panel2.Controls.Add(this.jugador2);
            this.panel2.Controls.Add(this.Carretera22);
            this.panel2.Controls.Add(this.Carretera11);
            this.panel2.Location = new System.Drawing.Point(544, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 519);
            this.panel2.TabIndex = 6;
            // 
            // txtScore2
            // 
            this.txtScore2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore2.Location = new System.Drawing.Point(544, 541);
            this.txtScore2.Name = "txtScore2";
            this.txtScore2.Size = new System.Drawing.Size(475, 37);
            this.txtScore2.TabIndex = 7;
            this.txtScore2.Text = "Puntuación: 0";
            this.txtScore2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imagenCiudad
            // 
            this.imagenCiudad.Location = new System.Drawing.Point(154, 611);
            this.imagenCiudad.Name = "imagenCiudad";
            this.imagenCiudad.Size = new System.Drawing.Size(174, 124);
            this.imagenCiudad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagenCiudad.TabIndex = 9;
            this.imagenCiudad.TabStop = false;
            // 
            // imagenCiudad2
            // 
            this.imagenCiudad2.Location = new System.Drawing.Point(704, 611);
            this.imagenCiudad2.Name = "imagenCiudad2";
            this.imagenCiudad2.Size = new System.Drawing.Size(174, 124);
            this.imagenCiudad2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagenCiudad2.TabIndex = 8;
            this.imagenCiudad2.TabStop = false;
            // 
            // premio2
            // 
            this.premio2.Image = global::juegocochesSO.Properties.Resources.ganar;
            this.premio2.Location = new System.Drawing.Point(33, 213);
            this.premio2.Name = "premio2";
            this.premio2.Size = new System.Drawing.Size(415, 103);
            this.premio2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.premio2.TabIndex = 6;
            this.premio2.TabStop = false;
            // 
            // AI22
            // 
            this.AI22.Image = global::juegocochesSO.Properties.Resources.carGrey;
            this.AI22.Location = new System.Drawing.Point(376, 90);
            this.AI22.Name = "AI22";
            this.AI22.Size = new System.Drawing.Size(44, 99);
            this.AI22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI22.TabIndex = 5;
            this.AI22.TabStop = false;
            this.AI22.Tag = "cochederecha2";
            // 
            // AI11
            // 
            this.AI11.Image = global::juegocochesSO.Properties.Resources.CarRed;
            this.AI11.Location = new System.Drawing.Point(76, 84);
            this.AI11.Name = "AI11";
            this.AI11.Size = new System.Drawing.Size(44, 91);
            this.AI11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI11.TabIndex = 5;
            this.AI11.TabStop = false;
            this.AI11.Tag = "cocheizquierda2";
            // 
            // explosion2
            // 
            this.explosion2.Image = global::juegocochesSO.Properties.Resources.explosion;
            this.explosion2.Location = new System.Drawing.Point(33, 359);
            this.explosion2.Name = "explosion2";
            this.explosion2.Size = new System.Drawing.Size(64, 64);
            this.explosion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explosion2.TabIndex = 5;
            this.explosion2.TabStop = false;
            // 
            // jugador2
            // 
            this.jugador2.Image = global::juegocochesSO.Properties.Resources.carPink;
            this.jugador2.Location = new System.Drawing.Point(218, 401);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(47, 93);
            this.jugador2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.jugador2.TabIndex = 5;
            this.jugador2.TabStop = false;
            // 
            // Carretera22
            // 
            this.Carretera22.Image = global::juegocochesSO.Properties.Resources.roadTrack;
            this.Carretera22.Location = new System.Drawing.Point(0, 0);
            this.Carretera22.Name = "Carretera22";
            this.Carretera22.Size = new System.Drawing.Size(475, 519);
            this.Carretera22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Carretera22.TabIndex = 4;
            this.Carretera22.TabStop = false;
            // 
            // Carretera11
            // 
            this.Carretera11.Image = global::juegocochesSO.Properties.Resources.roadTrack;
            this.Carretera11.Location = new System.Drawing.Point(0, -519);
            this.Carretera11.Name = "Carretera11";
            this.Carretera11.Size = new System.Drawing.Size(475, 519);
            this.Carretera11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Carretera11.TabIndex = 7;
            this.Carretera11.TabStop = false;
            // 
            // premio
            // 
            this.premio.Image = global::juegocochesSO.Properties.Resources.perder;
            this.premio.Location = new System.Drawing.Point(57, 213);
            this.premio.Name = "premio";
            this.premio.Size = new System.Drawing.Size(372, 114);
            this.premio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.premio.TabIndex = 5;
            this.premio.TabStop = false;
            // 
            // AI2
            // 
            this.AI2.Image = global::juegocochesSO.Properties.Resources.carGrey;
            this.AI2.Location = new System.Drawing.Point(376, 84);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(53, 91);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI2.TabIndex = 5;
            this.AI2.TabStop = false;
            this.AI2.Tag = "cochederecha";
            // 
            // AI1
            // 
            this.AI1.Image = global::juegocochesSO.Properties.Resources.CarRed;
            this.AI1.Location = new System.Drawing.Point(76, 75);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(43, 88);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI1.TabIndex = 5;
            this.AI1.TabStop = false;
            this.AI1.Tag = "cocheizquierda";
            // 
            // explosion
            // 
            this.explosion.Image = global::juegocochesSO.Properties.Resources.explosion;
            this.explosion.Location = new System.Drawing.Point(33, 359);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(64, 64);
            this.explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explosion.TabIndex = 5;
            this.explosion.TabStop = false;
            // 
            // jugador
            // 
            this.jugador.Image = global::juegocochesSO.Properties.Resources.carOrange;
            this.jugador.Location = new System.Drawing.Point(232, 401);
            this.jugador.Name = "jugador";
            this.jugador.Size = new System.Drawing.Size(52, 93);
            this.jugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.jugador.TabIndex = 5;
            this.jugador.TabStop = false;
            // 
            // Carretera2
            // 
            this.Carretera2.Image = global::juegocochesSO.Properties.Resources.roadTrack;
            this.Carretera2.Location = new System.Drawing.Point(0, 0);
            this.Carretera2.Name = "Carretera2";
            this.Carretera2.Size = new System.Drawing.Size(475, 519);
            this.Carretera2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Carretera2.TabIndex = 4;
            this.Carretera2.TabStop = false;
            // 
            // Carretera1
            // 
            this.Carretera1.Image = global::juegocochesSO.Properties.Resources.roadTrack;
            this.Carretera1.Location = new System.Drawing.Point(0, -519);
            this.Carretera1.Name = "Carretera1";
            this.Carretera1.Size = new System.Drawing.Size(475, 519);
            this.Carretera1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Carretera1.TabIndex = 0;
            this.Carretera1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1033, 781);
            this.Controls.Add(this.imagenCiudad);
            this.Controls.Add(this.imagenCiudad2);
            this.Controls.Add(this.txtScore2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtciudad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtScore);
            this.Name = "Form2";
            this.Text = "Jugador1 vs Jugador2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCiudad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenCiudad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox Carretera2;
        private System.Windows.Forms.PictureBox Carretera1;
        private System.Windows.Forms.PictureBox AI2;
        private System.Windows.Forms.PictureBox AI1;
        private System.Windows.Forms.PictureBox premio;
        private System.Windows.Forms.PictureBox explosion;
        private System.Windows.Forms.PictureBox jugador;
        private System.Windows.Forms.Timer timerJuego;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtciudad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox premio2;
        private System.Windows.Forms.PictureBox Carretera11;
        private System.Windows.Forms.PictureBox AI22;
        private System.Windows.Forms.PictureBox AI11;
        private System.Windows.Forms.PictureBox explosion2;
        private System.Windows.Forms.PictureBox jugador2;
        private System.Windows.Forms.PictureBox Carretera22;
        private System.Windows.Forms.Label txtScore2;
        private System.Windows.Forms.PictureBox imagenCiudad2;
        private System.Windows.Forms.PictureBox imagenCiudad;
    }
}

