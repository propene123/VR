using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_spin : MonoBehaviour
{
    
    public int seconds_per_rot;
    private Transform[] cubes;
    
    // Start is called before the first frame update
    void Start()
    {
        cubes = new Transform[transform.childCount];
        int idx = 0;
        foreach (Transform t in transform)
        {
            cubes[idx++] = t;    
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds_per_rot > 0)
        {
            foreach (Transform t in cubes)
            {
                t.transform.Rotate(0, (360/seconds_per_rot)*Time.deltaTime,0);
            }
        }
    }
}
