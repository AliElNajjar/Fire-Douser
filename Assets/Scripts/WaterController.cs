using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public LineRenderer waterSpray;
    public GameObject waterMark;
    public GameObject waterSource;
    public GameObject water;
    public float lineDrawSpeed = 3f;

    //private Vector3[] waterLine;
    private Touch touch;
    private float counter;
    private float dist;
    private Vector3 markPosition;
    private Vector3 sourcePosition;

    private void Start()
    {
        markPosition = waterMark.transform.position;
        sourcePosition = waterSource.transform.position;
        //waterLine = new Vector3[]{ markPosition, sourcePosition};
        dist = Vector3.Distance(sourcePosition, markPosition);
        waterSpray.SetPosition(0, sourcePosition);
    }


    void Spray()
    {
        //waterSpray.SetPositions(waterLine);
        water.SetActive(true);
        counter += .1f / lineDrawSpeed;
        float x = Mathf.Lerp(0, dist, counter);
        Vector3 waterLine = x * Vector3.Normalize(markPosition - sourcePosition) + sourcePosition;

        waterSpray.SetPosition(1, waterLine);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
           {
            Spray();
           }
           else if (Input.GetKeyUp(KeyCode.Mouse0))
           {
               water.SetActive(false);
               counter = 0;
           }
           else water.SetActive(false);

       /*if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Spray();
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            water.SetActive(false);
            counter = 0;
        }
        else water.SetActive(false);*/
    }
}
