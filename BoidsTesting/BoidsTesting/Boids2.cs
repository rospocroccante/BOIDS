using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BoidsTesting
{
    internal class Boids2
    {
        public Vector2 Position;
        public Vector2 Velocity;
        private float Speed = 40f;  // Velocità costante
        private float PerceptionRadius = 50f;
        private int windowWidth;
        private int windowHeight;
        public Texture boidTexture;
        private Sprite sprite;

        public Boids2(float x, float y)
        {
            boidTexture = new Texture("boid.png");
            sprite = new Sprite(boidTexture.Width, boidTexture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            Position = new Vector2(x, y);
            Velocity = new Vector2(1, 1);  // Direzione iniziale fissa
            Velocity = Vector2.Normalize(Velocity) * Speed;  // Imposta la velocità costante
        }


        // Metodo per aggiornare la posizione e la velocità del boid
        public void Update(List<Boids2> boids)
        {
            windowWidth = Simulation2.win.Width;
            windowHeight = Simulation2.win.Height;
            Vector2 centerOfMass = new Vector2(0, 0);
            int total = 0;

            foreach (Boids2 boid in boids)
            {
                if (boid != this && Vector2.Distance(Position, boid.Position) < PerceptionRadius)
                {
                    centerOfMass += boid.Position;
                    total++;
                }
            }

            if (total > 0)
            {
                centerOfMass /= total;  // Trova il centro di massa dei vicini
                Vector2 direction = centerOfMass - Position;
                if (direction.Length > 0)
                {
                    Velocity = Vector2.Normalize(direction) * Speed;  // Imposta la velocità verso il centro di massa
                }
            }

            Position += Velocity;

            // Comportamento di wrapping come Pac-Man
            if (Position.X > windowWidth) Position.X = 0;
            if (Position.X < 0) Position.X = windowWidth;
            if (Position.Y > windowHeight) Position.Y = 0;
            if (Position.Y < 0) Position.Y = windowHeight;
        }

        public void Update2()
        {
            Position += Velocity;
        }


        // Metodo per disegnare il boid usando uno sprite
        public void Draw()
        {
            sprite.DrawTexture(boidTexture);
        }
    }
}

