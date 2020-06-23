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
    public const float setDead = 0.5f; //Deadzone for when to decide to set the enum
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

    //We need the canvas so 
    public void CompassInit(GameObject canvas)
    {
        Transform compassObj = canvas.transform.GetChild(0).GetComponent<Transform>();

        north = compassObj.GetChild(8).GetComponent<Image>();
        south = compassObj.GetChild(7).GetComponent<Image>();
        east = compassObj.GetChild(6).GetComponent<Image>();
        west = compassObj.GetChild(5).GetComponent<Image>();
        northeast = compassObj.GetChild(4).GetComponent<Image>();
        northwest = compassObj.GetChild(3).GetComponent<Image>();
        southwest = compassObj.GetChild(2).GetComponent<Image>();
        southeast = compassObj.GetChild(1).GetComponent<Image>();
        middle = compassObj.GetChild(0).GetComponent<Image>();
        Debug.Log("Init");
    }
    public void setDirEnum()
    {

        float h = Input.GetAxisRaw("ControllerX");
        float v = Input.GetAxisRaw("ControllerY");

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
        if (h > (setDead - setOffsetDead) && v < (-setDead + setOffsetDead))
        {
            direction = Dir.UpRight;
        }
        //NorthWest
        if (h < (-setDead + setOffsetDead) && v < (-setDead + setOffsetDead))
        {
            direction = Dir.UpLeft;
        }
        //SouthEast
        if (h > (setDead - setOffsetDead) && v > (setDead - setOffsetDead))
        {
            direction = Dir.DownRight;
        }
        //SouthWest
        if (h < (-setDead + setOffsetDead) && v > (setDead - setOffsetDead))
        {
            direction = Dir.DownLeft;
        }

        //Middle
        if (h == 0 && v == 0)
        {
            direction = Dir.Middle;
        }

        Debug.Log(direction);
    }

    public void setCompass()
    {
        if (direction == Dir.Up)
        {
            north.color = Color.red;
        }
        else
        {
            north.color = Color.white;
        }

        if (direction == Dir.Down)
        {
            south.color = Color.red;
        }
        else
        {
            south.color = Color.white;
        }

        if (direction == Dir.Right)
        {
            east.color = Color.red;
        }
        else
        {
            east.color = Color.white;
        }

        if (direction == Dir.Left)
        {
            west.color = Color.red;
        }
        else
        {
            west.color = Color.white;
        }

        if (direction == Dir.UpRight)
        {
            northeast.color = Color.red;
        }
        else
        {
            northeast.color = Color.white;
        }

        if (direction == Dir.UpLeft)
        {
            northwest.color = Color.red;
        }
        else
        {
            northwest.color = Color.white;
        }

        if (direction == Dir.DownRight)
        {
            southeast.color = Color.red;
        }
        else
        {
            southeast.color = Color.white;
        }

        if (direction == Dir.DownLeft)
        {
            southwest.color = Color.red;
        }
        else
        {
            southwest.color = Color.white;
        }

        if (direction == Dir.Middle)
        {
            middle.color = Color.red;
        }
        else
        {
            middle.color = Color.white;
        }
    }
    public void resetCompass()
    {
        north.color = Color.white;
        south.color = Color.white;
        east.color = Color.white;
        west.color = Color.white;
        northeast.color = Color.white;
        northwest.color = Color.white;
        southeast.color = Color.white;
        southwest.color = Color.white;
        middle.color = Color.red;
    }

}
