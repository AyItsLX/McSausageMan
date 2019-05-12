using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaForce : MonoBehaviour {

    public float peaForce = 5f;

    public float maxTimer = 0.25f;
    public float Timer = 0f;

    private float deathTimer = 5f;

    public int liveLeft = 4;

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Collider>().enabled = false;

        rb.AddForce(Vector3.right * peaForce, ForceMode.Impulse);
	}

    void Update()
    {
        if (GameOverScript.isDead)
        {
            Destroy(gameObject);
        }
        else if (Victory.isVictory)
        {
            Destroy(gameObject);
        }

        if (liveLeft <= 0)
        {
            Destroy(gameObject);
        }

        deathTimer -= Time.deltaTime;

        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }

        if (rb != null)
        {
            Timer += Time.deltaTime;
        }

        if (Timer >= maxTimer)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Colliders"))
        {
            --liveLeft;

            rb.drag += 0.25f;
        }

        if (collision.collider.gameObject.name.Equals("BottomCollider") || collision.collider.gameObject.name.Equals("TopCollider"))
        {
            Destroy(gameObject);
        }
    }
}
