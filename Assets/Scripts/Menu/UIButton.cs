using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public Vector3 smallSize;
    public Vector3 bigSize;

    public void Awake()
    {
        transform.localScale = smallSize;
    }

    public void big()
    {
        transform.localScale = bigSize;
    }

    public void small()
    {
        transform.localScale = smallSize;
    }
}
