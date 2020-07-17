using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("bullet"))
            health -= damage;
    }
}
