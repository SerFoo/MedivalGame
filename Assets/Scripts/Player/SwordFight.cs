using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{

    [Header("Controller KeyBind Settings")]
    public KeyCode guardButton;
    public bool onGuard;
    
    Compass compass = new Compass();

    void Start()
    {
        compass.CompassInit(GameObject.Find("Canvas"));
    }

    void Update()
    {
        compass.setDirEnum();

        if(Input.GetKey(guardButton))
        {
            onGuard = true;
            print("onGuard!");
        }
        else
        {
            onGuard = false;
        }

         if (onGuard)
        {
            compass.setCompass();
        }
        else
        {
            compass.resetCompass();
        }


    }
}
