using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolltex : MonoBehaviour
{
    public float speedX = .5f;
    public float speedY = .5f;
    private Renderer rnd;
    public float colourChangeSpeed;

    private void Awake()
    {
        rnd = GetComponent<Renderer>();
    }
    private void Update()
    {
        Vector2 scrolling = new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime);


        rnd.material.SetTextureOffset("_MainTex",rnd.material.mainTextureOffset + scrolling);
        //rnd.material.color = Random.ColorHSV() * colourChangeSpeed * Time.deltaTime;
    }


}
