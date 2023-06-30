using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent<CheeseCollect>(out CheeseCollect cheesecollect))
            {
                if (cheesecollect.score < 1500)
                {
                    SceneManager.LoadScene("Rank D");
                }
                else if (cheesecollect.score >= 1500 && cheesecollect.score < 3000)
                {
                    SceneManager.LoadScene("Rank C");
                }
                else if (cheesecollect.score >= 3000 && cheesecollect.score < 5000)
                {
                    SceneManager.LoadScene("Rank B");
                }
                else if (cheesecollect.score >= 5000 && cheesecollect.score < 7000)
                {
                    SceneManager.LoadScene("Rank A");
                }
                else if (cheesecollect.score >= 7000)
                {
                    SceneManager.LoadScene("Rank S");
                }
            }
        }
    }
}
