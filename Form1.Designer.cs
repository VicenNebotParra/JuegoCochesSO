namespace juegocochesSO
{
    partial class Form1
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
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.premio = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.jugador = new System.Windows.Forms.PictureBox();
            this.Carretera2 = new System.Windows.Forms.PictureBox();
            this.carretera1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.Label();
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtciudad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carretera1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.premio);
            this.panel1.Controls.Add(this.explosion);
            this.panel1.Controls.Add(this.jugador);
            this.panel1.Controls.Add(this.Carretera2);
            this.panel1.Controls.Add(this.carretera1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 519);
            this.panel1.TabIndex = 0;
            // 
            // AI2
            // 
            this.AI2.Image = global::juegocochesSO.Properties.Resources.carGrey;
            this.AI2.Location = new System.Drawing.Point(394, 104);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(53, 92);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI2.TabIndex = 5;
            this.AI2.TabStop = false;
            this.AI2.Tag = "cochederecha";
            // 
            // AI1
            // 
            this.AI1.Image = global::juegocochesSO.Properties.Resources.CarRed;
            this.AI1.Location = new System.Drawing.Point(76, 71);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(51, 92);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AI1.TabIndex = 5;
            this.AI1.TabStop = false;
            this.AI1.Tag = "cocheizquierda";
            // 
            // premio
            // 
            this.premio.Image = global::juegocochesSO.Properties.Resources.bronze1;
            this.premio.Location = new System.Drawing.Point(58, 233);
            this.premio.Name = "premio";
            this.premio.Size = new System.Drawing.Size(356, 99);
            this.premio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.premio.TabIndex = 5;
            this.premio.TabStop = false;
            // 
            // explosion
            // 
            this.explosion.Image = global::juegocochesSO.Properties.Resources.explosion;
            this.explosion.Location = new System.Drawing.Point(76, 375);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(64, 64);
            this.explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explosion.TabIndex = 5;
            this.explosion.TabStop = false;
            // 
            // jugador
            // 
            this.jugador.Image = global::juegocochesSO.Properties.Resources.carOrange;
            this.jugador.Location = new System.Drawing.Point(213, 392);
            this.jugador.Name = "jugador";
            this.jugador.Size = new System.Drawing.Size(49, 98);
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
            // carretera1
            // 
            this.carretera1.Image = global::juegocochesSO.Properties.Resources.roadTrack;
            this.carretera1.Location = new System.Drawing.Point(0, -519);
            this.carretera1.Name = "carretera1";
            this.carretera1.Size = new System.Drawing.Size(475, 519);
            this.carretera1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carretera1.TabIndex = 0;
            this.carretera1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Orange;
            this.btnStart.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 537);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 41);
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
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerJuego
            // 
            this.timerJuego.Interval = 20;
            this.timerJuego.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Agency FB", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 621);
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
            this.txtciudad.Location = new System.Drawing.Point(12, 665);
            this.txtciudad.Name = "txtciudad";
            this.txtciudad.Size = new System.Drawing.Size(475, 55);
            this.txtciudad.TabIndex = 5;
            this.txtciudad.Text = " ";
            this.txtciudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 781);
            this.Controls.Add(this.txtciudad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtScore);
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.premio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carretera2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carretera1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox Carretera2;
        private System.Windows.Forms.PictureBox carretera1;
        private System.Windows.Forms.PictureBox AI2;
        private System.Windows.Forms.PictureBox AI1;
        private System.Windows.Forms.PictureBox premio;
        private System.Windows.Forms.PictureBox explosion;
        private System.Windows.Forms.PictureBox jugador;
        private System.Windows.Forms.Timer timerJuego;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtciudad;
    }
}

