using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using TMPro;
using UnityEngine.SceneManagement;

public class CheeseCollect : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI myScore;
    public TextMeshProUGUI highScore;
    //public GameObject timer;
    public GameObject cheeserush;
    public GameObject finishline;
    public TMP_Text hitScore;
    public Animation hitScoreAnime;
    private bool isHitAnimationPlaying = false;
    [SerializeField]
    public int score { get; private set; }
    [Header("Cheese")]
    public GameObject transparentcheese;
    public GameObject rushcheese;
    //public GameObject lap2;
    //public GameObject transparentlap2;
    public GameObject transparentcheesewalls;
    public GameObject transparentcheesewallscheeserush;
    public GameObject solidcheesewalls;
    public GameObject solidcheesewallscheeserush;
    private List<GameObject> cheesePool = new List<GameObject>();

    [Header("Music + Ranks")]
    public GameObject cheeserushmusic;
    public GameObject levelmusic;
    public GameObject level2music;
    public AudioClip cheeseCollectClip;
    public AudioClip largeCheeseCollectClip;
    public GameObject rankD;
    public GameObject rankC;
    public GameObject rankB;
    public GameObject rankA;
    public GameObject rankS;
    //public GameObject ranklap1;
    //public GameObject ranklap2;
    //public GameObject ranklap3;

    [Header("CheeseFace")]
    public GameObject cheeseFace;
    public GameObject cheeseFaceStart;
    public GameObject startTimer;

    [Header("PlayerSTuff")]
    public PlayerRespawnManager prm;
    public GameObject skyBoxChange;

    [Header("PlayerRespawn")]
    public GameObject respawn1;
    public GameObject respawn2;
    public GameObject respawn3;
    public GameObject respawn4;

    [Header("PlayerNewRespawn")]
    public GameObject newRespawn1;
    public GameObject newRespawn2;
    public GameObject newRespawn3;
    public GameObject newRespawn4;
    //public AudioClip lapCompleteClip;
    //public AudioClip finalLapCompleteClip;

    public AudioSource audioHurt;
    public AudioClip hurtAudioClip;





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
        if ((other.name.Contains("Knife") || other.name.Contains("Fork") || other.name.Contains("Fire") && !isHitAnimationPlaying))
        {
            score -= 50;
            if (audioHurt != null && hurtAudioClip != null)
            {
                audioHurt.PlayOneShot(hurtAudioClip);
            }

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

            //Respawn Stuff
            respawn1.SetActive(false);
            respawn2.SetActive(false);
            respawn3.SetActive(false);
            respawn4.SetActive(false);
            newRespawn1.SetActive(true);
            newRespawn2.SetActive(true);
            newRespawn3.SetActive(true);
            newRespawn4.SetActive(true);
            //BreakLine
            skyBoxChange.SetActive(true);

            cheeseFace.SetActive(true);
            cheeseFaceStart.SetActive(false);
            startTimer.SetActive(false);
            //gameObject.GetComponent<AudioSource>().Play();
            cheeserushmusic.SetActive(true);
            levelmusic.SetActive(false);
            level2music.SetActive(false);
            //timer.SetActive(true);
            cheeserush.SetActive(true);
            finishline.SetActive(true);
            transparentcheesewalls.SetActive(true);
            transparentcheesewallscheeserush.SetActive(false);
            solidcheesewalls.SetActive(false);
            solidcheesewallscheeserush.SetActive(true);
            transparentcheese.SetActive(false);
            rushcheese.SetActive(true);
            prm.EnableNewRespawnPoints();
            Debug.Log("EnableNewRespawnPoints() method called from CheeseCollect script.");
            //lap2.SetActive(true);
            //transparentlap2.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.name.Contains("CF"))
        {
            SceneManager.LoadScene("Lose Scene");
        }

        #endregion

        #region Ranks
        //Ranks
        if (score < 1500)
        {
            rankD.SetActive(true);
            rankC.SetActive(false);
        }
        if (score >= 1500 && score < 3500)
        {
            rankD.SetActive(false);
            rankC.SetActive(true);
            rankB.SetActive(false);
        }
        if (score >= 3500 && score <7000)
        {
            rankC.SetActive(false);
            rankB.SetActive(true);
            rankA.SetActive(false);
        }
        if (score >= 7000 && score <10000)
        {
            rankB.SetActive(false);
            rankA.SetActive(true);
            rankS.SetActive(false);
        }
        if (score >= 10000)
        {
            rankA.SetActive(false);
            rankS.SetActive(true);
        }
        Score();
    }
    #endregion

    public void Score()
    {
        //myScore.text = score.ToString();
        //if(score > PlayerPrefs.GetInt("HighScore", 0))
        //{
        //    PlayerPrefs.SetInt("HighScore", score);
        //    highScore.text = score.ToString();
        //}
        myScore.text = score.ToString();

        // Save the score
        PlayerPrefs.SetInt("CurrentScore", score);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
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
