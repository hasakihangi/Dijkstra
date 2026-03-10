using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map map;
    
    void Start()
    {
        map = new Map(4, 4);
        map[0, 0] = false;
        map[0, 1] = false;
        map[2, 2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
