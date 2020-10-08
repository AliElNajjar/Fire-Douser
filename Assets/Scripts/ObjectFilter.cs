using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFilter : MonoBehaviour
{
    private bool waterOn;
    //private bool doused;
    //private bool entered;
    //private bool exited;
   
    public GameObject water;
    public AudioSource soundSource;
    public AudioClip lifeLost;
    public AudioClip extinguisher;

    private void Start()
    {
        waterOn = false;
        //doused = false;
    }

    private void Update()
    {
        if (water.activeSelf == true)
        {
            waterOn = true;
        }
        else waterOn = false;

        /*if (entered && exited)
        {
            doused = true;
        }
        else doused = false;*/
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "People" && waterOn)
        {
            collider.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            ScoreController.SharedInstance.DecrementLife(1);
            soundSource.PlayOneShot(lifeLost);
            //decrement lives
        }

        else if (collider.gameObject.tag == "Fire" && waterOn /*&& doused*/)
        {
            //collider.gameObject.SetActive(false);
            //increment score
            collider.gameObject.GetComponent<Animator>().SetBool("isDoused", true);
            ScoreController.SharedInstance.IncrementScore(75);
            soundSource.PlayOneShot(extinguisher,.2f);
        }

        /*else if (collider.gameObject.tag == "Fire" && waterOn)
        {
            entered = true;
        }

        else return;*/
        
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire" && waterOn)
        {
            exited = true;
        }
    }*/

}
