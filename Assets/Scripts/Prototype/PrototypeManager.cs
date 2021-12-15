using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrototypeManager : MonoBehaviour
{
    public enum prototypePhase { mainMenu, lockerRoom, prematch, match, postmatch}

    public prototypePhase currentPhase;
    public int matchTime;
    public int starWin;
    public bool matchStart;
    public AudioSource music;
    public AudioSource crowdNoise;
    public AudioLowPassFilter musicEdit1;
    public AudioReverbFilter musicEdit2;

    [Header("Moves")]
    public QTEString move1;
    public GameObject move1Anim;
    public QTEPin move2;
    public GameObject move2Anim;
    public QTEString move3;
    public GameObject move3Anim;
    public QTEString move4;
    public GameObject move4Anim;
    public QTEPin move5;
    public GameObject move5Anim;

    [Header("User Interface")]
    public GameObject MainMenu;
    public GameObject LockerRoomBG;
    public GameObject LockerRoom;
    public GameObject prematchScreen;      
    public GameObject inRing;    
    public GameObject postmatchScreen;
    public Text matchScreen;
    public Image[] starImages;

    [Header("Colours")]
    public Color imageOpacityFail;
    public Color imageOpacityWon;


    public void Awake()
    {
        matchStart = false;
        music.Play();
        musicEdit1.enabled = !musicEdit1.enabled;
        musicEdit2.enabled = !musicEdit2.enabled;

        //-- TURN OFF SCREENS
        MainMenu.gameObject.SetActive(false);
        LockerRoomBG.gameObject.SetActive(false);
        LockerRoom.gameObject.SetActive(false);
        prematchScreen.gameObject.SetActive(false);
        inRing.gameObject.SetActive(false);
        postmatchScreen.gameObject.SetActive(false);
        matchScreen.gameObject.SetActive(false);

        //-- TURN OFF MOVES
        move1.gameObject.SetActive(false);
        move1Anim.gameObject.SetActive(false);
        move2.gameObject.SetActive(false);
        move2Anim.gameObject.SetActive(false);
        move3.gameObject.SetActive(false);
        move3Anim.gameObject.SetActive(false);
        move4.gameObject.SetActive(false);
        move4Anim.gameObject.SetActive(false);
        move5.gameObject.SetActive(false);
        move5Anim.gameObject.SetActive(false);
    }

    public void Update()
    {
        StarCount();
        matchScreen.text = "Minute: " + matchTime;

        switch (currentPhase)
        {
//-------------------------------------------------------------------------- MAIN MENU
            case prototypePhase.mainMenu:
                //-- TURN ON MENU
                MainMenu.gameObject.SetActive(true);
                break;
//------------------------------------------------------------------------ LOCKER ROOM
            case prototypePhase.lockerRoom:
                //--TURN ON LOCKER ROOM
                MainMenu.gameObject.SetActive(false);
                LockerRoomBG.gameObject.SetActive(true);
                LockerRoom.gameObject.SetActive(true);

                //--TURN ON SOUND EFFECTS
                music.volume = .5f;
                musicEdit1.enabled = true;
                musicEdit2.enabled = true;
                break;

            case prototypePhase.prematch:
                LockerRoom.gameObject.SetActive(false);
                prematchScreen.gameObject.SetActive(true);             
                break;
//---------------------------------------------------------------------------- MATCH
            case prototypePhase.match:
                music.volume = 0f;
                crowdNoise.volume = 0.1f;

                LockerRoomBG.gameObject.SetActive(false);

                inRing.gameObject.SetActive(true);
                matchScreen.gameObject.SetActive(true);


                if (matchTime == 1)
                {
                    move1Anim.gameObject.SetActive(true);
                    move1.gameObject.SetActive(true);

                    if(move1.complete)
                    {
                        starWin++;
                        move1Anim.gameObject.SetActive(false);
                        move1.gameObject.SetActive(false);
                        matchTime++;
                    }
                    else if(move1.fail)
                    {
                        move1Anim.gameObject.SetActive(false);
                        move1.gameObject.SetActive(false);
                        matchTime++;
                    }
                }
                
                if(matchTime == 2)
                {
                    move2Anim.gameObject.SetActive(true);
                    move2.gameObject.SetActive(true);

                    if(move2.complete)
                    {
                        if(move2.pinCount > 1 && move2.pinCount < 3)
                        {
                            starWin++;
                            move2Anim.gameObject.SetActive(false);
                            move2.gameObject.SetActive(false);
                            matchTime++;
                        }
                        else
                        {
                            move2Anim.gameObject.SetActive(false);
                            move2.gameObject.SetActive(false);
                            matchTime++;
                        }

                    }
                    else if(move2.pinCount >= 3)
                    {
                        move2Anim.gameObject.SetActive(false);
                        move2.gameObject.SetActive(false);
                        matchTime++;
                    }
                }
                
                if (matchTime == 3)
                {
                    move3Anim.gameObject.SetActive(true);
                    move3.gameObject.SetActive(true);

                    if (move3.complete)
                    {
                        starWin++;
                        move3Anim.gameObject.SetActive(false);
                        move3.gameObject.SetActive(false);
                        matchTime++;
                    }
                    else if (move3.fail)
                    {
                        move3Anim.gameObject.SetActive(false);
                        move3.gameObject.SetActive(false);
                        matchTime++;
                    }
                }

                if (matchTime == 4)
                {
                    move4Anim.gameObject.SetActive(true);
                    move4.gameObject.SetActive(true);

                    if (move4.complete)
                    {
                        starWin++;
                        move4Anim.gameObject.SetActive(false);
                        move4.gameObject.SetActive(false);
                        matchTime++;
                    }
                    else if (move4.fail)
                    {
                        move4Anim.gameObject.SetActive(false);
                        move4.gameObject.SetActive(false);
                        matchTime++;
                    }
                }

                if (matchTime == 5)
                {
                    move5Anim.gameObject.SetActive(true);
                    move5.gameObject.SetActive(true);

                    if (move5.complete)
                    {
                        move5Anim.gameObject.SetActive(false);
                        move5.gameObject.SetActive(false);
                        matchTime++;

                    }
                    else if (move5.pinCount >= 3)
                    {
                        starWin++;
                        move5Anim.gameObject.SetActive(false);
                        move5.gameObject.SetActive(false);
                        matchTime++;
                    }
                }

                if (matchTime >= 6)
                {
                    currentPhase++;
                }

                break;


            case prototypePhase.postmatch:
                inRing.gameObject.SetActive(true);
                prematchScreen.gameObject.SetActive(false);
                matchScreen.gameObject.SetActive(false);
                postmatchScreen.gameObject.SetActive(true);
                break;
        }
    }



    public void StarCount()
    {

        for (int i = 0; i < starImages.Length; i++)
       
        {
            if (starWin >= 5)
                starImages[i].color = imageOpacityWon;
            else if (starWin == 4)
            {
                starImages[i].color = imageOpacityWon;
                starImages[4].color = imageOpacityFail;
            }
            else if (starWin == 3)
            {
                starImages[i].color = imageOpacityWon;
                starImages[3].color = imageOpacityFail;
                starImages[4].color = imageOpacityFail;
            }
            else if (starWin == 2)
            {
                starImages[i].color = imageOpacityFail;
                starImages[0].color = imageOpacityWon;
                starImages[1].color = imageOpacityWon;
            }
            else if (starWin == 1)
            {
                starImages[i].color = imageOpacityFail;
                starImages[0].color = imageOpacityWon;
            }
            else if (starWin <= 0)
                starImages[i].color = imageOpacityFail;

        }

    }

    public void StartButton()
    {
        currentPhase++;
        matchTime = 1;
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void nextPhaseButton()
    {
        currentPhase++;
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
