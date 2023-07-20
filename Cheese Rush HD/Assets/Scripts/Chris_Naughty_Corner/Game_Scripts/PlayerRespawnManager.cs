using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    // Create a public enum to represent the sections
    public enum RespawnSection
    {
        Section1,
        Section2,
        Section3,
        Section4
    }

    public Transform respawnPointSection1;
    public Transform respawnPointSection2;
    public Transform respawnPointSection3;
    public Transform respawnPointSection4;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void RespawnPlayer(RespawnSection section)
    {
        // Reset player's velocity and position based on the section
        playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerTransform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // Determine which section to respawn in and move the player to that respawn point
        switch (section)
        {
            case RespawnSection.Section1:
                playerTransform.position = respawnPointSection1.position;
                Debug.Log("hdshsdshd");
                break;
            case RespawnSection.Section2:
                playerTransform.position = respawnPointSection2.position;
                break;
            case RespawnSection.Section3:
                playerTransform.position = respawnPointSection3.position;
                break;
            case RespawnSection.Section4:
                playerTransform.position = respawnPointSection4.position;
                break;
            default:
                // If the section is not recognized, respawn at the first checkpoint
                playerTransform.position = respawnPointSection1.position;
                break;
        }
    }
}
