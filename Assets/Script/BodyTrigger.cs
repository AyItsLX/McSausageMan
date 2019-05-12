using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrigger : MonoBehaviour {

    public GameObject Player;
    public AudioSource Ouch;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pea"))
        {
            Player.GetComponent<PlayerMovement>().redTransition.SetActive(true);
            Ouch.Play();
            Player.GetComponent<PlayerMovement>().playerHealth -= 25f;
        }
    }
}
