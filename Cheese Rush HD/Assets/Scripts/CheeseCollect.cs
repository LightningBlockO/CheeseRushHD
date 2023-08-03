using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using TMPro;

public class CheeseCollect : MonoBehaviour
{
    public TextMeshProUGUI myScore;
    public TextMeshProUGUI highScore;
    public GameObject timer;
    public GameObject cheeserush;
    public GameObject finishline;
    public GameObject transparentcheese;
    public GameObject rushcheese;
    //public GameObject lap2;
    //public GameObject transparentlap2;
    public GameObject transparentcheesewalls;
    public GameObject transparentcheesewallscheeserush;
    public GameObject cheeserushmusic;
    public GameObject levelmusic;
    public GameObject rankD;
    public GameObject rankC;
    public GameObject rankB;
    public GameObject rankA;
    public GameObject rankS;
    //public GameObject ranklap1;
    //public GameObject ranklap2;
    //public GameObject ranklap3;

    public TMP_Text hitScore;
    public Animation hitScoreAnime;
    private bool isHitAnimationPlaying = false;

    private List<GameObject> cheesePool = new List<GameObject>();

    [SerializeField]
    public int score {get; private set;}

    public AudioClip cheeseCollectClip;
    public AudioClip largeCheeseCollectClip;
    public AudioClip lapCompleteClip;
    public AudioClip finalLapCompleteClip;

    public PlayerRespawnManager prm;



    public void Start()
    {
        prm = FindObjectOfType<PlayerRespawnManager>();
        Debug.Log("PlayerRespawnManager found: " + (prm != null));
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        //hitScore = GameObject.Find("Hit").GetComponent<TMP_Text>();
        //foreach (GameObject cheese in GameObject.FindGameObjectsWithTag("Cheese"))
        //{
        //    cheesePool.Add(cheese);
        //    cheese.SetActive(false);
        //}
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            PlayerPrefs.DeleteAll();
            highScore.text = "0";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Enemy Reduce Points
        if ((other.name.Contains("Knife") || other.name.Contains("Fork")) && !isHitAnimationPlaying)
        {
            score -= 50;

            hitScore.gameObject.SetActive(true);
            hitScoreAnime.Stop();
            hitScoreAnime.Play();
            isHitAnimationPlaying = true;
            Score(); 
            StartCoroutine(ResetHitAnimation(hitScoreAnime.clip.length));
        }

        #endregion



        #region Points
        //Points

        if (other.name.Contains("Cheese"))
        {
            SoundManager.Instance.PlaySFX(cheeseCollectClip);
            score += 10;
            Score();
            Destroy(other.gameObject);
            Analytics.CustomEvent("CheeseCollect");
            Debug.Log("Cheese Hopefully Tracked");
            
        }
        if (other.name.Contains("Large"))
        {
            SoundManager.Instance.PlaySFX(largeCheeseCollectClip);
            score += 90;
            Score();
            Destroy(other.gameObject);
        }
        if (other.name.Contains("Lap"))
        {
            score += 1000;
            //gameObject.GetComponent<AudioSource>().Play();
            //ranklap1.SetActive(false);
            //ranklap2.SetActive(true);
            Score();
        }
        if (other.name.Contains("Final"))
        {
            score += 990;
            Score();
            //gameObject.GetComponent<AudioSource>().Play();
            cheeserushmusic.SetActive(true);
            levelmusic.SetActive(false);
            timer.SetActive(true);
            cheeserush.SetActive(true);
            finishline.SetActive(true);
            //transparentcheesewalls.SetActive(true);
            //transparentcheesewallscheeserush.SetActive(false);
            //transparentcheese.SetActive(false);
            //rushcheese.SetActive(true);
            prm.EnableNewRespawnPoints();
            Debug.Log("EnableNewRespawnPoints() method called from CheeseCollect script.");
            //lap2.SetActive(true);
            //transparentlap2.SetActive(false);
            Destroy(other.gameObject);
        }

        #endregion

        #region Ranks
        //Ranks

        if (score >= 2500 && score < 4000)
        {
            rankD.SetActive(false);
            rankC.SetActive(true);
        }
        if (score >= 4000 && score <6000)
        {
            rankC.SetActive(false);
            rankB.SetActive(true);
        }
        if (score >= 6000 && score <7500)
        {
            rankB.SetActive(false);
            rankA.SetActive(true);
        }
        if (score >= 7500)
        {
            rankA.SetActive(false);
            rankS.SetActive(true);
        }
        Score();
    }
    #endregion

    public void Score()
    {
        myScore.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
        
    }

    public void Reset()
    {
       
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }

    private IEnumerator ResetHitAnimation(float animationDuration)
    {

        yield return new WaitForSeconds(2f);
        hitScore.gameObject.SetActive(false);

        //yield return new WaitForSeconds(1f);
        hitScoreAnime.Stop();
        //hitScore.gameObject.SetActive(true);
        isHitAnimationPlaying = false;

    }
}
