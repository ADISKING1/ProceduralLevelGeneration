using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class levelgeneration : MonoBehaviour
{
    public CinemachineVirtualCamera myCinemachine;

    public Transform[] startingPositions;
    public GameObject[] rooms;//1-lr 2-lrb 3-lrt 4-lrbt

    public GameObject player, key;
    //public Transform playerpos, keypos;

    public float moveamount;
    private int direction;

    public float minX, minY, maxX;

    public bool stoplvlgen = false;

    public float startTimeBtwRoom;
    private float TimeBtwRoom;

    public int downCounter = 0;

    public LayerMask room;
    private GameObject newplayer;
    void Start()
    {
        int RandStartPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[RandStartPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        player.transform.position = new Vector2(startingPositions[RandStartPos].position.x - 3.5f , startingPositions[RandStartPos].position.y - 1.5f);
        
        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (TimeBtwRoom <= 0 && stoplvlgen == false)
        {
            move();
            TimeBtwRoom = startTimeBtwRoom;
        }
        else
            TimeBtwRoom -= Time.deltaTime;
    }
    void move()
    {
        if(direction == 1 || direction == 2)//Right
        {
            if (transform.position.x < maxX)
            {
                Vector2 newpos = new Vector2(transform.position.x + moveamount, transform.position.y);
                transform.position = newpos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                    direction = 2;
                else if (direction == 4)
                    direction = 5;
                downCounter = 0;
            }
            else
                direction = 5;
        }
        else if (direction == 3 || direction == 4)//Left
        {
            if (transform.position.x > minX)
            {
                Vector2 newpos = new Vector2(transform.position.x - moveamount, transform.position.y);
                transform.position = newpos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
                downCounter = 0;
            }
            else
                direction = 5;
        }
        else if (direction == 5)//Down
        {
            downCounter += 1;
            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<roomtype>().type != 1 || roomDetection.GetComponent<roomtype>().type != 3)
                {
                    roomDetection.GetComponent<roomtype>().roomdestruction();
                    if (downCounter >= 2)
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    else
                    {
                        int toss = Random.Range(0, 2);
                        if (toss == 0)
                            Instantiate(rooms[1], transform.position, Quaternion.identity);
                        else
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                }
                Vector2 newpos = new Vector2(transform.position.x, transform.position.y - moveamount);
                transform.position = newpos;

                int rand = Random.Range(2, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stoplvlgen = true;
                var newplayer = Instantiate(player, player.transform.position, Quaternion.identity);
                myCinemachine.m_Follow = newplayer.transform;
                key.transform.position = new Vector2(transform.position.x - 3.5f, transform.position.y - 1.5f);
                newplayer = Instantiate(key, key.transform.position, Quaternion.identity);
            }
        }
    }
}
