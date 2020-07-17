using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float offset;

    public Transform firepoint;
    public GameObject bulletprefab;

    public float bulletforce;
    public float nextTimetoFire = 0f;
    public float firerate = 15f;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / firerate;
            shoot();
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
