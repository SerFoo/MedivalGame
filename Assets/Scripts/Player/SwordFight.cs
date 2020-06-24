using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{

    [Header("Controller KeyBind Settings")]
    public KeyCode guardButton;
    public KeyCode lookButton;
    [Header("Fighting Settings")]
    public float visibilityRange = 150;
    public bool onGuard;
    public GameObject lockonTarget;
    public bool isLocked;

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
        if(Input.GetKeyDown(lookButton))
            isLocked = !isLocked;
                
    }

    public Transform DetectNearestEnemy()
    {
        Debug.Log("Finding Enemy");

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visibilityRange);

        //Iterate through all npcs in area
        foreach (Collider tr in hitColliders)
        {
            if (Vector3.Distance(transform.position, tr.transform.position) < visibilityRange && tr.tag == "NPC")
            {
                Debug.Log("Nearest Enemy: " + tr.gameObject);
                lockonTarget = tr.gameObject;
                return tr.transform;
            }
        }
        return null;
    }
}



