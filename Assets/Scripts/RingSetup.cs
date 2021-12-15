using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSetup : MonoBehaviour
{
    [Header("Randomiser")]
    public bool RandomApron;
    public bool RandomMat;
    public bool RandomPost;
    public bool RandomTurnbuckle;
    public bool RandomRopes;
    public bool RandomLineRopes;
    public bool TriRopes;

    [Header("Materials")]
    public LineRenderer[] lineRopes1;
    public LineRenderer[] lineRopes2;
    public LineRenderer[] lineRopes3;

    [Header("Materials")]
    public Material apron;
    public Material mat;    
    public Material post;
    public Material turnbuckle;
    public Material ropes1;
    public Material ropes2;
    public Material ropes3;

    [Header("Colors")]
    public Color apronColor;
    public Color matColor;
    public Color postColor;
    public Color turnbuckleColor;
    public Color ropesColor1;
    public Color ropesColor2;
    public Color ropesColor3;

    private void Awake()
    {
        Color rope1 = Random.ColorHSV();
        Color rope2 = Random.ColorHSV();
        Color rope3 = Random.ColorHSV();


        if(RandomApron)
            apron.color = Random.ColorHSV();
        else
            apron.color = apronColor;
        
        if(RandomMat)
            mat.color = Random.ColorHSV();
        else
            mat.color = matColor;

        if(RandomPost)
            post.color = Random.ColorHSV();
        else
            post.color = postColor;

        if(RandomTurnbuckle)
            turnbuckle.color = Random.ColorHSV();
        else
            turnbuckle.color = turnbuckleColor;

        if (RandomRopes)
        {
            if (TriRopes)
            {
                ropes1.color = rope1;
                ropes2.color = rope2;
                ropes3.color = rope3;
            }
            else
            {
                ropes1.color = rope1;
                ropes2.color = rope1;
                ropes3.color = rope1;
            }
        }
        else
        {
            if (TriRopes)
            {
                ropes1.color = ropesColor1;
                ropes2.color = ropesColor2;
                ropes3.color = ropesColor3;
            }
            else
            {
                ropes1.color = ropesColor1;
                ropes2.color = ropesColor1;
                ropes3.color = ropesColor1;
            }
        }

        if (RandomLineRopes)
        {
            if (TriRopes)
            {

                for (int i = 0; i < lineRopes1.Length; i++)
                {
                    lineRopes1[i].startColor = rope1;
                    lineRopes1[i].endColor = rope1;
                }

                for (int i = 0; i < lineRopes2.Length; i++)
                {
                    lineRopes2[i].startColor = rope2;
                    lineRopes2[i].endColor = rope2;
                }

                for (int i = 0; i < lineRopes3.Length; i++)
                {
                    lineRopes3[i].startColor = rope3;
                    lineRopes3[i].endColor = rope3;
                }

            }
            else
            {

                for (int i = 0; i < lineRopes1.Length; i++)
                {
                    lineRopes1[i].startColor = rope1;
                    lineRopes1[i].endColor = rope1;
                }

                for (int i = 0; i < lineRopes2.Length; i++)
                {
                    lineRopes2[i].startColor = rope1;
                    lineRopes2[i].endColor = rope1;
                }

                for (int i = 0; i < lineRopes3.Length; i++)
                {
                    lineRopes3[i].startColor = rope1;
                    lineRopes3[i].endColor = rope1;
                }

            }
        }
        else
        {

            for (int i = 0; i < lineRopes1.Length; i++)
            {
                lineRopes1[i].startColor = ropesColor1;
                lineRopes1[i].endColor = ropesColor1;
            }

            for (int i = 0; i < lineRopes2.Length; i++)
            {
                lineRopes2[i].startColor = ropesColor1;
                lineRopes2[i].endColor = ropesColor1;
            }

            for (int i = 0; i < lineRopes3.Length; i++)
            {
                lineRopes3[i].startColor = ropesColor1;
                lineRopes3[i].endColor = ropesColor1;
            }
        }

    }


    public void RingRandomiser()
    {
        apron.color = Random.ColorHSV();
        mat.color = Random.ColorHSV();
        post.color = Random.ColorHSV();
        turnbuckle.color = Random.ColorHSV();
        ropes1.color = Random.ColorHSV();
    }

}
