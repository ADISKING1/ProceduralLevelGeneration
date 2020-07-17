using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{
    public float lifeTime = 0.5f;
    public float distance;
    public GameObject destroyeffect;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    // Update is called once per frame
    /*void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
            DestroyBullet();
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
