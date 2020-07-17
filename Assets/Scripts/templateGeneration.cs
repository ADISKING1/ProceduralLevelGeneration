using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class templateGeneration : MonoBehaviour
{
    public Transform[] Positions;
    public GameObject[] templates;

    public float startTimeBtwTemplate;
    private float TimeBtwTemplate;

    int randTemplate, i = 0;

    public levelgeneration lg;

    private void Update()
    {
        if (TimeBtwTemplate <= 0 && lg.stoplvlgen == true)
        {
            InstantiateTemplate();
            TimeBtwTemplate = startTimeBtwTemplate;
        }
        else
            TimeBtwTemplate -= Time.deltaTime;
    }
    void InstantiateTemplate()
    {
        if (i < Positions.Length)
        {
            Instantiate(templates[Random.Range(0, templates.Length)], Positions[i].position, Quaternion.identity);
            i++;
        }
    }
}

