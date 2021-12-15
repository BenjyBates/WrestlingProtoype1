
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraPosition.eulerAngles.y, transform.eulerAngles.z);
    }

}