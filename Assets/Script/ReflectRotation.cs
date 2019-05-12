using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectRotation : MonoBehaviour {

    public GameObject Player;
    public float rotationSpeed = 5f;

    void Start ()
    {
	}
	
	void Update ()
    {
        if (MainMenu.isReadying)
        {
            #region Mouse Reflect Rotation
            Plane playerPlane = new Plane(Vector3.forward, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 tempPoint = new Vector3(ray.GetPoint(hitdist).x, ray.GetPoint(hitdist).y, 0);
                Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0);

                Quaternion targetRotation = Quaternion.LookRotation(tempPoint - myPos);

                transform.rotation = targetRotation;
                //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            #endregion

            #region Arrow Keys Reflect Rotation
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed);
            }
            #endregion

            if (Player != null)
            {
                transform.position = Player.transform.position;
            }
        }
	}
}
