using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    //string[] ObjectTags = { "People", "Fire"};
    private float minDistance = 1.25f;
    private float timeToSpawn = 0f;
    private float speed = 2f;
    private float maxSpeed = 50f;
    private float timeToIncreaseSpeed = 7f;
    private float countdownTimer;
    private float speedIncreased = 0.07f;
    private string objectTag;

    private void Start()
    {
        countdownTimer = timeToIncreaseSpeed;
    }


    private void Update()
    {
        /*if (GameController.GameIsOver)
        {
            this.enabled = false;
        }*/

        if (Time.time >= timeToSpawn)
        {
            SpawnObject();
            timeToSpawn = Time.time + (minDistance / speed);
        }

        if (countdownTimer <= 0f)
        {
            if (speed < maxSpeed)
            {
                speed += speedIncreased;
                countdownTimer = timeToIncreaseSpeed;
            }
            else
                speed = maxSpeed;


        }

        countdownTimer -= Time.deltaTime;
    }

    void SpawnObject()
    {

        // Getting Tag of 
        {
            int tagIndex = Random.Range(0,1000);
            if (tagIndex < 750)
            {
                objectTag = "Fire";
            }
            else if (tagIndex >= 750)
            {
                objectTag = "People";
            }
        }
        //string objectTag = GetTag();

        {
           
                GameObject _object = ObjectPooler.SharedInstance.GetPooledObject(objectTag);
                if (_object != null)
                {
                    _object.transform.position = spawnPoint.transform.position;
                    //_object.transform.rotation = spawnPoint.transform.rotation;
                    _object.GetComponent<Rigidbody>().velocity = transform.right * speed;
                    _object.GetComponent<Animator>().WriteDefaultValues();

                    _object.SetActive(true);
                }
            }
        }
    }
