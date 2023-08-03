using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public enum PlayerState
    {
        remyidle,remymach
    }
    public static UiManager Instance;

    private PlayerState currentplayerstate;
    [SerializeField]
    private Animator remyTVanim;
    const string REMYIDLE = "Remy Idle";
    const string REMYMACH = "Remy Mach";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {

    }
    public void ChangePlayerState(PlayerState PlayerState)
    {
        if(currentplayerstate != PlayerState)
        {
            switch (PlayerState)
            {
                case PlayerState.remyidle:
                    remyTVanim.Play(REMYIDLE);
                    break;
                case PlayerState.remymach:
                    remyTVanim.Play(REMYMACH);
                    break;
            }
            currentplayerstate = PlayerState;
        }
    }
}