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
    public GameObject rankD;
    public GameObject rankC;
    public GameObject rankB;
    public GameObject rankA;
    public GameObject rankS;
    public GameObject ranklap1;
    public GameObject ranklap2;
    public GameObject ranklap3;

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
            ranklap1.SetActive(false);
            ranklap2.SetActive(true);
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
        if (score >= 1500)
        {
            rankD.SetActive(false);
            rankC.SetActive(true);
        }
        if (score >= 3000)
        {
            rankC.SetActive(false);
            rankB.SetActive(true);
        }
        if (score >= 5000)
        {
            rankB.SetActive(false);
            rankA.SetActive(true);
        }
        if (score >= 7000)
        {
            rankA.SetActive(false);
            rankS.SetActive(true);
        }
        myScore.text = score.ToString();
    }
}
