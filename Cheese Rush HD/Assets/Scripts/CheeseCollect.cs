using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheeseCollect : MonoBehaviour
{
    public TextMeshProUGUI myScore;
    public GameObject timer;
    public GameObject cheeserush;
    public GameObject finishline;
    public GameObject transparentcheese;
    public GameObject rushcheese;
    public GameObject lap2;
    public GameObject transparentlap2;
    public GameObject cheeserushmusic;
    public GameObject levelmusic;

    [SerializeField]
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Cheese"))
        {
            score += 10;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Contains("Large"))
        {
            score += 90;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.name.Contains("Lap"))
        {
            score += 1000;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (other.name.Contains("Final"))
        {
            score += 990;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            timer.SetActive(true);
            cheeserush.SetActive(true);
            finishline.SetActive(true);
            transparentcheese.SetActive(false);
            rushcheese.SetActive(true);
            lap2.SetActive(true);
            transparentlap2.SetActive(false);
            cheeserushmusic.SetActive(true);
            levelmusic.SetActive(false);
        }
        myScore.text = score.ToString();
    }
}
