using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMouseMove : MonoBehaviour
{
    public Camera MainMenuCam;

    private Vector3 startPos;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = MainMenuCam.ScreenToViewportPoint(Input.mousePosition);
        pos.z = 0;

        transform.position = pos;
        transform.position = new Vector3(startPos.x + (pos.x * offset), startPos.y + (pos.y * offset), 0);
        
            /*float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        GetComponent<RectTransform>().position = new Vector2(
        (x / Screen.width) * offset,
        (y / Screen.height) * offset
        );*/
    }
}

