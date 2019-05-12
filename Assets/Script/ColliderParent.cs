using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderParent : MonoBehaviour {

    public GameObject Player;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position;
        }
	}
}
