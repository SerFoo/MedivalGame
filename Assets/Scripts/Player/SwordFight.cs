using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{

    [Header("Controller KeyBind Settings")]
    public KeyCode guardButton;
    public KeyCode lookButton;
    public float visibilityRange = 150;
    public bool onGuard;
    
    Compass compass = new Compass();

    void Start()
    {
        compass.CompassInit(GameObject.Find("Canvas"));
    }

    void Update()
    {
        compass.setDirEnum();
        #region GuardButton Stuff
        if(Input.GetKey(guardButton))
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
        if(Input.GetKeyDown(lookButton))
            LockOnTarget(DetectNearestEnemy());
    }

    public GameObject DetectNearestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("NPC");
        GameObject closest = null;
        float distance = visibilityRange;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void LockOnTarget(GameObject target)
    {
            Debug.Log(target);
    }

}
