using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{

    public float RotationSpeed = 50;

    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}