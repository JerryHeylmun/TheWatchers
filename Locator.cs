/*
        Jerry Heylmun: The Watchers 2015
        File:    Locator.cs
        Purpose: Update the game manager on the current section of the map the player is in.
*/
using UnityEngine;
using System.Collections;

public class Locator : MonoBehaviour {

    public int locId = 100;
    public string location="Not Set";
    
    [SerializeField]
    Transform locations;

    Transform[] children;
    BoxCollider[][] colliders;
    bool[][] colliderInfo;
	void Start () {
        children = new Transform[locations.childCount];
        colliders = new BoxCollider[locations.childCount][];
        colliderInfo = new bool[locations.childCount][];
        bool setLoc = false;
        for(int i = 0; i< locations.childCount; i++)
        {
            children[i] = locations.GetChild(i);
            colliders[i] = locations.GetChild(i).GetComponentsInChildren<BoxCollider>();
            colliderInfo[i] = new bool[colliders[i].Length];
            for(int z = 0; z < colliders[i].Length; z++)
            {
                if (colliders[i][z].bounds.Contains(transform.position))
                {
                    if (!setLoc)
                    {
                        locationChange(i);
                    }
                    colliderInfo[i][z] = true;
                } else
                {
                    colliderInfo[i][z] = false;
                }
            }
        }
	}

    void locationChange(int newLoc)
    {
        if(locId != newLoc)
        {
            locId = newLoc;
            location = locations.GetChild(newLoc).gameObject.name;
            Debug.Log("Player is located in " + location);
        }
    }

    void OnTriggerEnter(Collider collided)
    {
        for(int z = 0; z< colliders.Length; z++)
        {
            for(int y = 0; y< colliders[z].Length; y++)
            {
                if (colliders[z][y].gameObject.Equals(collided.gameObject))
                {
                    colliderInfo[z][y] = true;
                    if (locId > z)
                    {
                        locationChange(z);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider collided)
    {
        bool found = false;
        for (int z = 0; z < colliders.Length; z++)
        {
            for (int y = 0; y < colliders[z].Length; y++)
            {
                if (colliders[z][y].gameObject.Equals(collided.gameObject))
                {
                    colliderInfo[z][y] = false;
                } else if(!found && colliderInfo[z][y])
                {
                    found = true;
                    locationChange(z);
                }
            }
        }
    }

    void Update () {
	
	}
}
