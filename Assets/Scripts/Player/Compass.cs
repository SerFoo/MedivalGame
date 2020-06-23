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

public class Compass : Controller  
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


    public void setDirEnum()
    {

        float h = Input.GetAxis("ControllerX");
        float v = Input.GetAxis("ControllerY");

        //South
        if (v > setDead)
        {
            direction = Dir.Down;
        }
        //North
        if (v < -setDead)
        {
            direction = Dir.Up;
        }
        //East
        if (h > setDead)
        {
            direction = Dir.Right;
        }
        //West
        if (h < -setDead)
        {
            direction = Dir.Left;
        }
        //NorthEast
        if(h > (setDead - setOffsetDead) && v < (-setDead + setOffsetDead))
        {
            direction = Dir.UpRight;
        }
        //NorthWest
        if(h < (-setDead + setOffsetDead) && v < (-setDead + setOffsetDead))
        {
            direction = Dir.UpLeft;
        }
        //SouthEast
        if (h > (setDead - setOffsetDead) && v > (setDead - setOffsetDead))
        {
            direction = Dir.DownRight;
        }
        //SouthWest
        if (h < (-setDead + setOffsetDead) && v >(setDead - setOffsetDead))
        {
            direction = Dir.DownLeft;
        }
        //Middle
        if(h == 0 && v == 0)
        {
            direction = Dir.Middle;
        }
        Debug.Log(direction);
    }

}
