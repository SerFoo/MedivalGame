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
        Middle
    }

    public Dir direction;
    public const float setDead = 0.2f; //Deadzone for when to decide to set the enum
    public float setOffsetDead = -0.05f;//Deadzone offset for diagnols
}

public class Compass : Controller
{
    public Image north;
    public Image south;
    public Image east;
    public Image west;
    public Image middle;

    
    public void CompassInit(GameObject canvas)
    {
        Transform compassObj = canvas.transform.GetChild(0).GetComponent<Transform>();

        north = compassObj.GetChild(1).GetComponent<Image>();
        south = compassObj.GetChild(2).GetComponent<Image>();
        east = compassObj.GetChild(3).GetComponent<Image>();
        west = compassObj.GetChild(4).GetComponent<Image>();
        middle = compassObj.GetChild(0).GetComponent<Image>();
        Debug.Log("Init");
    }
    public void setDirEnum()
    {

        float h = Input.GetAxisRaw("Mouse X");
        float v = Input.GetAxisRaw("Mouse Y");

        //North
        if (v > setDead)
        {
            direction = Dir.Up;
        }
        //North
        if (v < -setDead)
        {
            direction = Dir.Down;
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

        //Middle
        /**if (h == 0 && v == 0)
        {
            direction = Dir.Middle;
        }**/

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
        middle.color = Color.red;
    }

}
