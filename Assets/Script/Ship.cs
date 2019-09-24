using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D bullet;
    List<Rigidbody2D> bList = new List<Rigidbody2D>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        //Debug.Log("mouse x = "+mouse.x + ", mouse y = "+mouse.y);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
            mouse.x,
            mouse.y,
            0
        ));
        //Debug.Log("mouseWorld x = "+mouseWorld.x + ", mouseWorld y = "+mouseWorld.y);

        Vector3 bulletDir = mouseWorld - this.transform.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D b = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
            b.velocity = bulletDir * 1.5f;
            bList.Add(b);
        }

        float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
        //Debug.Log("angle = " + angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


        foreach (Rigidbody2D b in bList.ToArray())
        {
            if (b != null)
            {
                if (b.position.x > 10 || b.position.x < -10 || b.position.y < -5 || b.position.y > 5)
                {
                    bList.Remove(b);
                    Destroy(b.gameObject);
                }
            }
        }

        checkCollision();

    }

    void checkCollision()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (Rigidbody2D b in bList.ToArray())
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    //Debug.Log(enemies[i].tag + ", " + enemies.Length);
                    if (b.GetComponent<SpriteRenderer>().bounds.Intersects(
                        enemies[i].GetComponent<SpriteRenderer>().bounds))
                    {
                        Destroy(enemies[i]);
                        bList.Remove(b);
                        Destroy(b.gameObject);
                    }
                }
            }
        }
    }
}
