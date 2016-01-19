/*
        Jerry Heylmun: The Watchers 2015
        File:    EnvironmentSounds.cs
        Purpose: Manage the sounds from the game in 3D space. 

        FIXME: Currently just used to cause random sounds around the player, will update.
*/

using UnityEngine;
using System.Collections;

public class EnvironmentSounds : MonoBehaviour {

    [SerializeField]
    float minTimeBetween = 10.0f;

    [SerializeField]
    float maxTimeBetween = 50.0f;

    [SerializeField]
    AudioSource leftOffset;
    [SerializeField]
    AudioSource rightOffset;
    [SerializeField]
    AudioSource backOffset;
    [SerializeField]
    AudioSource frontOffset;
    [SerializeField]
    AudioSource topOffset;

    float nextSound = 0.0f;
    float currentTimer = 0.0f;

	void Start () {
        nextSound = Random.Range(minTimeBetween, maxTimeBetween);
        currentTimer = 0.0f;
    }

    void playSound()
    {
        float rand = Random.Range(0.0f, 5.0f);
        if(rand < 1.0f)
        {
            //Left
            Debug.Log("Laugh left");
            leftOffset.Play();
        } else if (rand < 2.0f)
        {
            //Right
            rightOffset.Play();
            Debug.Log("Laugh right");
        } else if (rand < 3.0f)
        {
            //Back
            backOffset.Play();
            Debug.Log("Laugh back");
        }
        else if (rand < 4.0f)
        {
            //front
            frontOffset.Play();
            Debug.Log("Laugh front");
        }
        else
        {
            //top
            topOffset.Play();
            Debug.Log("Laugh top");
        }

    }

    void FixedUpdate()
    {
      if (currentTimer >= nextSound)
        {
            //PLAY SOUND
            playSound();
            nextSound = Random.Range(minTimeBetween, maxTimeBetween);
            currentTimer = 0.0f;
        }
        else
        {
            currentTimer = currentTimer + 1.0f;
        }
    }

}
