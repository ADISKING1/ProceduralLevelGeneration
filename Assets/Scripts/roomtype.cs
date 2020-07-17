using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomtype : MonoBehaviour
{
    public int type;

    public void roomdestruction()
    {
        Destroy(gameObject);
    }
}
