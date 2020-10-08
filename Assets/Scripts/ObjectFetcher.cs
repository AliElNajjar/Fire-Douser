using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFetcher : MonoBehaviour
{

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag != "Road")
        {
            collider.gameObject.SetActive(false);
            collider.gameObject.GetComponent<Animator>().SetBool("isDoused",false);
        }
    }
}
