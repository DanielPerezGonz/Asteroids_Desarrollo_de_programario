using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    SpriteRenderer sr;
    public List<Sprite> sprites;
    public AsteroidManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        Debug.Log(direction);
        Debug.Log(direction.magnitude);

        rb.AddForce(direction * speed);
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Muerte()
    {
        Destroy(gameObject);

    }
}
