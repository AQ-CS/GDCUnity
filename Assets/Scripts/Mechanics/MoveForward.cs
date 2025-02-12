using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

public class MoveForward : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Schedule<PlayerDeath>(); // Triggers the respawn logic
            Destroy(gameObject); // Destroy the bullet upon hitting the player
        }
    }
}

