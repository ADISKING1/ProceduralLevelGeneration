using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public levelgeneration lvlgen;

    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if(roomDetection == null && lvlgen.stoplvlgen == true)
        {
            int rand = Random.Range(0, lvlgen.rooms.Length);
            Instantiate(lvlgen.rooms[rand], transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        
    }
}
