﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    [SerializeField]
    Text CollectableText;
    [SerializeField]
    Text GotEverything;

    int CollectedObjects;
    int TotalObjects;
    int Score;

    public float speed = 10f;

    // Use this for initialization
    private void Start()
    {
        CollectableText.enabled = false;
        GotEverything.enabled = false;
        TotalObjects = GameObject.FindGameObjectsWithTag("Collectable").Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collectable");
        if (other.tag == "Collectable")
        {
            CollectedObjects += 1;
            Score = CollectedObjects * 15;
            if (CollectedObjects <= TotalObjects)
            {
                CollectableText.text = CollectedObjects.ToString() + " collected out of " + TotalObjects;
                StopAllCoroutines();
                StartCoroutine(showText());
                //When the collision triggers it adds 1 to the total value of the objects collected in the CollectedObjects integer and then displays a message to the player on screen.
                //It also compares if the number of collected objects is lower than the total. This is how it can know when everything is collected.

            }

            if (CollectedObjects == TotalObjects)
            {
                GotEverything.text = "You got everything! Your score is:" + Score;
                StopAllCoroutines();
                StartCoroutine(showText());
                //Once all objects have been collected and equal the total number of collectibles in the level the door for the key is Destroyed and access granted.

            }
        }
    }

    IEnumerator showText()
    {
        CollectableText.enabled = true;
        yield return new WaitForSeconds(2);
        CollectableText.enabled = false;
        yield return new WaitForSeconds(2);
        GotEverything.enabled = true;
        yield return new WaitForSeconds(2);
        GotEverything.enabled = false;
        //This just displays the text.
    }
    


    void Update()
    {
       
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        
    }
}