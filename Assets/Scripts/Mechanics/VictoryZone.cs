using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// Instead of triggering a win animation, it moves the player to a specific position.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                // Move player to the specified coordinates
                p.transform.position = new Vector2(-3.67f, -11.67f);
            }
        }
    }
}
