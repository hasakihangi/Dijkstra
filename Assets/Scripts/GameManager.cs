using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map map;
    
    void Start()
    {
        map = new Map(4, 4);
        map[0, 0] = -1;
        map[0, 1] = -1;
        map[2, 2] = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
