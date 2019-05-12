using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public GameObject Player;
    public Transform entryPoint;
    public AudioSource DeathSound;
    public static bool isDead = false;

    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        if (Player != null)
        {

            transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (isDead)
        {
            if (Input.anyKeyDown && SceneManager.GetActiveScene().name == "GraphicMode")
            {
                isDead = false;
                SceneManager.LoadScene("GraphicMode");
            }
            else if (Input.anyKeyDown && SceneManager.GetActiveScene().name == "PrototypeMode")
            {
                isDead = false;
                SceneManager.LoadScene("PrototypeMode");
            }
        }
    }

    #region Kill Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerMovement>().playerHealth -= 100;
        }
    }
    #endregion
}
