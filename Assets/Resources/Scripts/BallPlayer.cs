using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPlayer : MonoBehaviour
{
    Rigidbody rb;
    float forceScale;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceScale = 10;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * forceScale);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * forceScale);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * forceScale);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * forceScale);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndPoint")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
