using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{
    Compass compass = new Compass();

    void Start()
    {
        
    }

    void Update()
    {
        compass.setDirEnum();
    }
}
