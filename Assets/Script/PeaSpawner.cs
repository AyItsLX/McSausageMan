using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaSpawner : MonoBehaviour {

    public AudioSource ShootSound;
    public GameObject Pea;

    private float maxTimer = 0.25f;
    private float Timer = 0f;

	void Start ()
    {
        Timer = maxTimer;
	}
	
	void Update ()
    {
        if (MainMenu.isReadying)
        {
            Timer += Time.deltaTime;

            if (Timer >= maxTimer)
            {
                Instantiate(Pea, transform.position, transform.rotation);
                ShootSound.Play();
                Timer = 0f;
            }
        }
    }
}
