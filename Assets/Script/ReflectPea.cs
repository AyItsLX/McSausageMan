using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflectPea : MonoBehaviour {

    public Text highScore;
    public int HighScore = 0;

    void Start ()
    {
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pea"))
        {
            ++HighScore;
            highScore.text = "Score : " + HighScore;

            collision.collider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100f, Vector3.forward, 5f);
        }
    }
}
