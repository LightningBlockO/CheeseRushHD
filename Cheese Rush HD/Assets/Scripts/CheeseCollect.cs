using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheeseCollect : MonoBehaviour
{
    public TextMeshProUGUI myScore;

    [SerializeField]
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Cheese"))
        {
            score += 10;
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Contains("Large"))
        {
            score += 90;
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Contains("Final"))
        {
            score += 990;
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        myScore.text = score.ToString();
    }
}
