using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{

    [Header("Controller KeyBind Settings")]
    public KeyCode guardButton;
    [Header("Fighting Settings")]
    public float visibilityRange = 150;
    public bool onGuard;

    Compass compass = new Compass();

    void Start()
    {
        compass.CompassInit(GameObject.Find("Canvas"));
    }

    void FixedUpdate()
    {
        compass.setDirEnum();
        #region GuardButton Stuff
        if (Input.GetKey(guardButton))
        {
            onGuard = true;
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
        #endregion
    }
}



