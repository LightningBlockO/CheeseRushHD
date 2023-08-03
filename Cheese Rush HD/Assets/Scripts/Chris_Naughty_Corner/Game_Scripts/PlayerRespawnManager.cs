using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    public enum RespawnSection
    {
        Section1,
        Section2,
        Section3,
        Section4
    }

    // Create a public enum to represent the sections
    public Transform respawnPointSection1;
    public Transform respawnPointSection2;
    public Transform respawnPointSection3;
    public Transform respawnPointSection4;

    public Transform newRespawnPointSection1;
    public Transform newRespawnPointSection2;
    public Transform newRespawnPointSection3;
    public Transform newRespawnPointSection4;

    private bool usingOriginalRespawnPoints = true;
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
                if (usingOriginalRespawnPoints)
                    playerTransform.position = respawnPointSection1.position;
                else
                    playerTransform.position = newRespawnPointSection1.position;
                break;
            case RespawnSection.Section2:
                if (usingOriginalRespawnPoints)
                    playerTransform.position = respawnPointSection2.position;
                else
                    playerTransform.position = newRespawnPointSection2.position;
                break;
            case RespawnSection.Section3:
                if (usingOriginalRespawnPoints)
                    playerTransform.position = respawnPointSection3.position;
                else
                    playerTransform.position = newRespawnPointSection3.position;
                break;
            case RespawnSection.Section4:
                if (usingOriginalRespawnPoints)
                    playerTransform.position = respawnPointSection4.position;
                else
                    playerTransform.position = newRespawnPointSection4.position;
                break;
            default:
                // If the section is not recognized, respawn at the first checkpoint of the active points
                if (usingOriginalRespawnPoints)
                    playerTransform.position = respawnPointSection1.position;
                else
                    playerTransform.position = newRespawnPointSection1.position;
                break;
        }
    }

    // Call this method when the player collects the final cheese
    public void EnableNewRespawnPoints()
    {
        Debug.Log("EnableNewRespawnPoints() called!");
        usingOriginalRespawnPoints = false;
        respawnPointSection1.gameObject.SetActive(false);
        respawnPointSection2.gameObject.SetActive(false);
        respawnPointSection3.gameObject.SetActive(false);
        respawnPointSection4.gameObject.SetActive(false);

        newRespawnPointSection1.gameObject.SetActive(true);
        newRespawnPointSection2.gameObject.SetActive(true);
        newRespawnPointSection3.gameObject.SetActive(true);
        newRespawnPointSection4.gameObject.SetActive(true);
    }
}
