using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    List<Rigidbody2D> eList = new List<Rigidbody2D>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 ePos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-5.0f, 5.0f),0);
            Rigidbody2D e = Instantiate(enemy, ePos, transform.rotation) as Rigidbody2D;
            e.tag = "enemy";
            eList.Add(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
         foreach (Rigidbody2D e in eList.ToArray())
        {
            if (e != null)
            {
               
            }
        }
    }
}
