using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuous_Background : MonoBehaviour
{
    [SerializeField]
    private GameObject The_Resolute;
    [SerializeField]
    private GameObject Background;
    private Vector3 Resolute_Pos;
    //private Vector3 Resolute_Pos = GameObject.Find("The_Resolute").transform.position;
    //private static readonly (int, int, int) p = (70, 0, 0);
    private float maxPos=80F;
    // Update is called once per frame
    private float numOfSpawn = 1F; //the number of times a new background spawn.
    private Vector3 counter = new Vector3(DistanceBewteenSpawn,0,0);
    private float constPos;
    private bool shouldSpawn;
    private const float  DistanceBewteenSpawn = 600;

    void Start()
    {
        constPos = maxPos+ 200;
    }
    void Update()
    {
        Resolute_Pos = The_Resolute.transform.position;
        shouldSpawn = ShouldSpawn();
        if (shouldSpawn == true)
        {
            Spawn();
            counter.x += DistanceBewteenSpawn;
        }
    }

    private void Spawn()
    {
        numOfSpawn += 1;
        Instantiate(Background, transform.position + counter, transform.rotation);
        maxPos += constPos;
    }
    private bool ShouldSpawn()
    {
        if (Resolute_Pos.x>maxPos)
        {
            return true;
        }
        else
            return false;
    }
}
