using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour {

    public GameObject DeathUI;

    public AudioSource JumpSound;
    public AudioSource Deathsound;
    public float playerHealth = 100f;

    public float jumpForce = 1f;
    public float moveSpeed = 2f;

    public Slider playerHealthUI;
    public GameObject redTransition;

    private Rigidbody rb;
    private bool isGrounded = false;

    private float xPosition = 0f;
    public bool isMoving = true;
    public bool IsGameOver = false;

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (MainMenu.isReadying)
        {
            playerHealthUI.value = playerHealth;

            #region Always Moving
            if (isMoving)
            {
                xPosition += Time.deltaTime;
                transform.position = new Vector3(xPosition * moveSpeed, transform.position.y, transform.position.z);
            }
            //transform.position = new Vector3(Time.timeSinceLevelLoad * moveSpeed, transform.position.y, transform.position.z);
            #endregion

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                JumpSound.Play();
                isGrounded = false;
            }

            if (playerHealth <= 0)
            {
                Deathsound.Play();
                DeathUI.SetActive(true);
                Destroy(GameObject.Find("MC"));
                Destroy(GetComponent<MeshRenderer>());
                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponentInChildren<PeaSpawner>());
                Destroy(GameObject.Find("ReflectPivot"));
                Destroy(GameObject.Find("GunParent"));
                GetComponent<Rigidbody>().isKinematic = true;

                GameOverScript.isDead = true;

            }

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1f, Color.blue);
                if (hit.collider.CompareTag("Ground"))
                {
                    isGrounded = true;
                }
                else
                {
                    isGrounded = false;
                }

            }
            else
            {
                isGrounded = false;
            }
        }
	}

    #region Check Grounded
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}
    #endregion
}
