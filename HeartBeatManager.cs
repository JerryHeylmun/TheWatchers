/*
        Jerry Heylmun: The Watchers 2015
        File:    HeartBeatManager.cs
        Purpose: Based on the players current danger, increase heartbeat speed and volume. 
*/
using UnityEngine;
using System.Collections;

public class HeartBeatManager : MonoBehaviour {

	[SerializeField]
	float danger = 0;

    [SerializeField]
    float totalVol = 50.0f;

	AudioSource heartSource;
	void Start () {
		heartSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Pitch... 0.66 <--> 2.0
		heartSource.pitch = (0.66f + (1.44f * (danger / 100f)));
		//Volume... 0.5 <--> 1.0
		heartSource.volume = ((0.5f + (danger / 200f))/100)*totalVol;
	
	}
}
