/*
        Jerry Heylmun: The Watchers 2015
        File:    GameManager.cs
        Purpose: Game Manager. Control global variables for access from other scripts.
*/

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[SerializeField]
	Transform player;
	[SerializeField]
	Transform childSpawnFolder;
	[SerializeField]
	Transform child;
	[SerializeField]
	Transform GraveyardDoor;
	[SerializeField]
	bool graveYardOpensOut = false;

	int doorDirection = 1;
	SphereCollider childArea;
	SphereCollider playerArea;

	int GameStage = 0; // 0: Start. 3: Found Child. 6: Opened Gates 9: In Graveyard 12: Found Dead Kid: 15: finished.

	void gameStageChange(int newStage){
		GameStage = newStage;
		Debug.Log ("Stage: " + newStage);
	}

	public void foundChild(){
		gameStageChange (3);
	}

	public void foundBody(){
		if (GameStage >= 6) {
			gameStageChange(12);
		}
	}
	public void finished(){
		if (GameStage >= 12) {
			gameStageChange(15);
		}
	}

	public void openDoors(){
		if (GameStage >= 3) {
			GraveyardDoor.GetChild (0).RotateAround ((GraveyardDoor.GetChild (0).GetChild (0).position), Vector3.up, -70f * doorDirection);
			GraveyardDoor.GetChild (1).RotateAround ((GraveyardDoor.GetChild (1).GetChild (0).position), Vector3.up, 70f * doorDirection);
			gameStageChange(6);
		}
	}

	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		playerArea = player.GetChild (0).GetChild (0).GetComponent<SphereCollider> ();
		if (graveYardOpensOut) { 
			doorDirection = -1; 
		}
		childArea = child.GetComponent<SphereCollider> ();
		int spawnSpot = (Random.Range(0,childSpawnFolder.childCount));
		int pos = 0;
		foreach (Transform spawner in childSpawnFolder) {
			if(pos == spawnSpot){
				child.position = spawner.position;
			}
			pos++;
		}
	}

	void Update () {

	}
}
