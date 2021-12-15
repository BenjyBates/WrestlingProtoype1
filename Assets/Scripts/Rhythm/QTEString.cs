using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEString : MonoBehaviour
{
    //--- ARRAYS FOR IMAGE AND KEYS
    public Image[] imageInputs;
    public KeyCode[] keyInputs;

    public Animator moveHolder;

    [Header("Main Variables")]
    public bool active;   
    public float cooldownTime;
    public float timerLimit;
    public float timerLimitCurrent;
    public float timerSpeed;
    public bool timer;
    public bool fail;
    public bool complete;
    public int nextInput;

    [Header("Animation Names")]
    public string animationSetup;
    public string animationFinish;

    [Header("Colours")]
    //--- SAVED OPACITY FOR INPUT
    public Color imageOpacityDefault;
    public Color imageOpacityPressed;

    public Image timerBar;


    public void Awake()
    {
        nextInput = 0;

        timerLimitCurrent = timerLimit;

        if(animationSetup == "")
        {

        }

        moveHolder.SetTrigger(animationSetup);

        for (int i = 0; i < keyInputs.Length; i++)
        {
            imageInputs[i].color = imageOpacityDefault;
        }

        timer = true;
        active = true;
    }

    public void Update()
    {

        if(active)
        {
            if(timer)
            {
                timerLimitCurrent -= timerSpeed * Time.deltaTime;
                timerBar.fillAmount = timerLimitCurrent / timerLimit;
            }




            if (Input.GetKeyUp(keyInputs[nextInput]))
            {
                imageInputs[nextInput].color = imageOpacityPressed;

                if (nextInput < keyInputs.Length - 1)
                    nextInput++;
                else
                {
                    moveHolder.SetTrigger(animationFinish);

                    StartCoroutine(animationTime(2f));
                }
            }

            if (Input.anyKey && !Input.GetKey(keyInputs[nextInput]))
            {

                StartCoroutine(failQTE(cooldownTime));

            }
                
        }

        if( timerLimitCurrent <= 0)
        {
            fail = true;
        }

    }



    public IEnumerator failQTE(float time)
    {
        for (int i = 0; i < keyInputs.Length; i++)
        {
            imageInputs[i].color = imageOpacityDefault;
        }

        nextInput = 0;

        yield return new WaitForSeconds(time);
        fail = false;
    }

    public IEnumerator animationTime(float time)
    {
        timer = false;

        yield return new WaitForSeconds(time);

        complete = true;

    }
}
