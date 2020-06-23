using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller
{
    public enum Dir
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,//NorthWest
        UpRight,//NorthEast
        DownLeft,//SouthWest
        DownRight,//SouthEast
        Middle//Doing nothing/ joystick idle
    }

    public Dir direction;
    public float setDead = 0.5f; //Deadzone for when to decide to set the enum
    public float setOffsetDead;//Deadzone offset for diagnols
}

public class Compass : MonoBehaviour
{    
    public Image north;
    public Image south;
    public Image east;
    public Image west;
    public Image northeast;
    public Image northwest;
    public Image southeast;
    public Image southwest;
    public Image middle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
