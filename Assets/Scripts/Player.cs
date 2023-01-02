using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_movement;
    public float speed_rotation;
    Rigidbody2D rb;
    public GameObject spark;
    Animator anim;
    public GameObject particulasMuerte;
    public int dead = 0;
    Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
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

        anim.SetBool("Movement", vertical > 0);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(spark, transform.position, transform.rotation);
            Destroy(temp, 0.5f);
        }

        
    }

    public void Muerte()
    {
        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 3);
        dead++;
        if (dead >= 3) { Environment.Exit(0); }
        if (dead < 3) { StartCoroutine(Respawn_Corutine()); }
    }

    IEnumerator Respawn_Corutine()
    {
        GameManager.instance.life--;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        coll.enabled = false;
        yield return new WaitForSeconds(3);
        coll.enabled = true;
    }
}
