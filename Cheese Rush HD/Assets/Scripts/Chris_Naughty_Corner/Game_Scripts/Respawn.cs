using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlayerRespawnManager respawnManager;
    public PlayerRespawnManager.RespawnSection section;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has fallen off the map
        if (other.CompareTag("Player"))
        {
            respawnManager.RespawnPlayer(section);
        }
    }
}
