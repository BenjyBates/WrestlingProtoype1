using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEManager : MonoBehaviour
{
    public enum moveState { idle, standing, grounded }

    public static QTEManager QTEMan;

    public QTEString[] moveInputs;

    public GameObject moveDummy;
    public Animator anim;
    public moveState currentMoveState;

    public KeyCode keyZ;
    public KeyCode keyX;
    public KeyCode keyC;
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;

    public GameObject choiceStanding;
    public GameObject choiceStandingZ;
    public GameObject choiceStandingX;
    public GameObject choiceStandingC;
    public GameObject choiceGrounded;

    private void Awake()
    {
        anim = moveDummy.GetComponent<Animator>();
        QTEMan = this;
    }

    private void Update()
    {
        switch (currentMoveState)
        {
            case moveState.idle:

                choiceStanding.gameObject.SetActive(false);
                choiceGrounded.gameObject.SetActive(false);

                break;


            case moveState.standing:


                choiceStanding.gameObject.SetActive(true);


                if(Input.GetKey(keyZ))
                {
                    choiceStandingZ.gameObject.SetActive(true);
                    
                    if(Input.GetKeyUp(keyUp))
                    {
                        moveInputs[1].active = true;
                        moveInputs[1].gameObject.SetActive(true);
                        currentMoveState = moveState.idle;
                    }
                }
                else
                    choiceStandingZ.gameObject.SetActive(false);


                if (Input.GetKey(keyX))
                {
                    choiceStandingX.gameObject.SetActive(true);
                }
                else
                    choiceStandingX.gameObject.SetActive(false);


                if (Input.GetKey(keyC))
                {
                    choiceStandingC.gameObject.SetActive(true);
                }
                else
                    choiceStandingC.gameObject.SetActive(false);


                choiceGrounded.gameObject.SetActive(false);


                break;


            case moveState.grounded:

                choiceGrounded.gameObject.SetActive(true);


             
                choiceStanding.gameObject.SetActive(false);
                break;
        }
    }
}
