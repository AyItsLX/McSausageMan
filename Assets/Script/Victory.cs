using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

    public GameObject VictoryUI;
    public AudioSource VictorySound;
    public static bool isVictory = false;

	void Start () {
        VictoryUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isVictory = true;
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponentInChildren<PeaSpawner>().enabled = false;
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().enabled = false;
            VictorySound.Play();
            VictoryUI.SetActive(true);
        }
    }
}
