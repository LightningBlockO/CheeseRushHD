using UnityEngine;

public class CheeseFace : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float movementSpeed = 5f;  // Speed at which CheeseFace follows the player

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();  // Normalize the direction vector

            // Move towards the player
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }
}
