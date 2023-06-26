using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace juegocochesSO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            {
                using (var player = new SoundPlayer(Properties.Resources.fortnite))
                {
                    player.Load();
                    player.PlayLooping();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form3());

                    player.Stop();
                }
            }
        }
    }
}
