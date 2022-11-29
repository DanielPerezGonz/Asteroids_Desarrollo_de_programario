using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_movement;
    public float speed_rotation;
    Rigidbody2D rb;
    public GameObject spark;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        horizontal *= speed_rotation * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, horizontal);


        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0) { 
            rb.AddForce(transform.up * vertical * speed_movement * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(spark);
        }
    }
}
