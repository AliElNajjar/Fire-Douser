using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileScreenResolution : MonoBehaviour
{
    public bool maintainWidth = true;
    [Range(-1,1)]
    public int adaptPosition;

    float defaultWidth;
    float defaultHeight;

    Vector3 CameraPos;

    private void Start()
    {
        CameraPos = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    private void Update()
    {
        if (maintainWidth)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(CameraPos.x, adaptPosition * (defaultHeight - Camera.main.orthographicSize), CameraPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(adaptPosition * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), CameraPos.y, CameraPos.z);
        }
    }
}