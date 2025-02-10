using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A controller for alien enemies that shoot projectiles and die if the player jumps on them.
    /// </summary>
    public class AlienController : EnemyController // Inherit from EnemyController
    {
        public float shootInterval = 2f; // Time between shots
        public GameObject projectile;
        public GameObject confetti; // Confetti effect prefab

        private float lastShotTime;

        void Start()
        {
            lastShotTime = Time.time;
        }

        void Update()
        {
            // Handle shooting
            if (Time.time - lastShotTime >= shootInterval)
            {
                ShootProjectile();
                lastShotTime = Time.time;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                // Check if player landed on top
                if (collision.relativeVelocity.y <= 0)
                {
                    PlayConfetti(); // Show confetti
                    Destroy(gameObject); // Player landed on top, alien dies
                }
                else
                {
                    // Player collided sideways, apply damage (uses EnemyController logic)
                    var ev = Schedule<PlayerEnemyCollision>();
                    ev.player = player;
                    ev.enemy = this; // Now it works because AlienController is an EnemyController
                }
            }
        }

        void ShootProjectile()
        {
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, projectile.transform.rotation);
            }
        }

        void PlayConfetti()
        {
            if (confetti != null)
            {
                Instantiate(confetti, transform.position, Quaternion.identity);
            }
        }
    }
}
