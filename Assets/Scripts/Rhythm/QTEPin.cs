using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEPin : MonoBehaviour
{

    public KeyCode KickoutButton;

    public Animator moveHolder;

    [Header("Main Variables")]
    public bool active;
    public bool kickout;
    public bool complete;
    public float pinCount;
    public float pinSpeed;


    [Header("Animation Names")]
    public string animationSetup;
    public string animationFinish;

    [Header("UI")]
    public Image kickoutButtonImage;
    public Text pinText;

    [Header("Colours")]
    //--- SAVED OPACITY FOR INPUT
    public Color imageOpacityDefault;
    public Color imageOpacityPressed;

    public void Awake()
    {
        pinCount = 0;
    }

    public void Update()
    {
        if (!kickout)
        {
            if (pinCount < 3)
                pinCount += pinSpeed * Time.deltaTime;

            if (pinCount < 1)
                pinText.gameObject.SetActive(false);
            else
                pinText.gameObject.SetActive(true);


            pinText.text = pinCount.ToString("0");


            if (Input.GetKey(KickoutButton))
            {
                kickoutButtonImage.color = imageOpacityPressed;
                moveHolder.SetTrigger(animationFinish);
                kickout = true;

                StartCoroutine(animationTime(2f));
            }
            else
            {
                kickoutButtonImage.color = imageOpacityDefault;
            }
        }
    }


    public IEnumerator animationTime(float time)
    {

        yield return new WaitForSeconds(time);

        complete = true;

    }
}
