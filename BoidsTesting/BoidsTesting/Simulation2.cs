using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BoidsTesting
{
    internal class Simulation2
    {

        public static Window win;
        private static List<Boids2> boids;


        public static void Init()
        {
            win = new Window(1280, 720, "Boids Simulation");
            boids = new List<Boids2>();

        }

        public static void Run()
        {
            bool isPressed = true;
            // Ciclo principale della finestra
            while (win.IsOpened)
            {
                if (win.MouseRight && isPressed == false)
                {
                    Boids2 boid = new Boids2(win.MouseX, win.MouseY);

                boids.Add(boid);

                    isPressed = true;
                }
                else if (!win.MouseRight)
                {
                    isPressed = false;
                }

// Aggiorna e disegna 
    if (boids.Count > 0)
{
    for (int i = 0; i < boids.Count; i++)
    {
        boids[i].Update(boids);
        boids[i].Draw();
    }
}

        win.Update();

      }
    }
  }
}

