using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFight : MonoBehaviour
{

    [Header("Controller KeyBind Settings")]
    public KeyCode guardButton;
    public KeyCode lookButton;
    [Header("Fighting Settings")]
    public float radius;
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
        if (Input.GetKeyDown(lookButton))
            LockOnTarget(DetectNearestEnemy());
    }

    public GameObject DetectNearestEnemy()
    {
        Debug.Log("Finding Enemy");

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visibilityRange);

        //Iterate through all npcs in area
        foreach (Collider tr in hitColliders)
        {
            if (Vector3.Distance(transform.position, tr.transform.position) < visibilityRange && tr.tag == "NPC")
            {
                Debug.Log(tr.gameObject);
                return tr.gameObject;
            }
        }

        return null;
    }
    
    public void LockOnTarget(GameObject target)
    {
        Debug.Log(target);
    }

}



