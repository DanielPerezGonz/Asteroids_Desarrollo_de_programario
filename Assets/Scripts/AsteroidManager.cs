using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroide;
    public float limitx = 9.5f;
    public float limity = 5.5f;
    public int max = 2;

    public int asteroides_actuales = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < max; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(-limity, limity));
            while(Vector3.Distance(pos, Vector3.zero) < 4f)
            {
                pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(-limity, limity));
            }
            GameObject temp = Instantiate(asteroide, pos, Quaternion.identity);
            temp.GetComponent<AsteroidControl>().manager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroides_actuales <= 0)
        {
            for (int i = 0; i < max; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(-limity, limity));
                GameObject temp = Instantiate(asteroide, pos, Quaternion.identity);
                temp.GetComponent<AsteroidControl>().manager = this;
            }
            max++;
        }
    }
}
