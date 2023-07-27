using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove_Top : MonoBehaviour
{
    public GameObject[] stovetops; // Assign all the stovetop GameObjects in the Inspector
    public GameObject fireHolderPrefab; // Assign the fire_holder prefab in the Inspector

    private void Start()
    {
        // Start the coroutine to toggle the stovetops' fire
        StartCoroutine(ToggleStovetopFire());
    }

    private IEnumerator ToggleStovetopFire()
    {
        while (true) // Infinite loop to keep the behavior looping forever
        {
            // Toggle the fire state for the first 5 seconds
            for (int i = 0; i < stovetops.Length; i++)
            {
                // Check if the stove is odd-numbered (using 1-based index)
                if ((i + 1) % 2 == 1)
                {
                    // Enable fire on odd-numbered stovetops
                    stovetops[i].transform.Find("Fire").gameObject.SetActive(true);
                }
                else
                {
                    // Disable fire on even-numbered stovetops
                    stovetops[i].transform.Find("Fire").gameObject.SetActive(false);
                }
            }

            // Wait for 5 seconds
            yield return new WaitForSeconds(2f);

            // Toggle the fire state for the next 5 seconds
            for (int i = 0; i < stovetops.Length; i++)
            {
                // Check if the stove is even-numbered (using 1-based index)
                if ((i + 1) % 2 == 0)
                {
                    // Enable fire on even-numbered stovetops
                    stovetops[i].transform.Find("Fire").gameObject.SetActive(true);
                }
                else
                {
                    // Disable fire on odd-numbered stovetops
                    stovetops[i].transform.Find("Fire").gameObject.SetActive(false);
                }
            }

            // Wait for 5 seconds
            yield return new WaitForSeconds(2f);
        }
    }
}
