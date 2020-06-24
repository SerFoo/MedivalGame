using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX = 0F;
    float rotationY = 0F;

    Quaternion originalRotation;


    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
		SwordFight sf = this.gameObject.GetComponent<SwordFight>();
		bool locked = sf.isLocked;

        // Read the mouse input axis
        rotationX += Input.GetAxis("ControllerX") * sensitivityX;
        rotationY += -Input.GetAxis("ControllerY") * sensitivityY;

        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

		if(!locked)
        	transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		else
			transform.LookAt(new Vector3(sf.DetectNearestEnemy().position.x, sf.DetectNearestEnemy().position.y - transform.position.y, sf.DetectNearestEnemy().position.z));
			Debug.Log("PogChamp");
        	//transform.localRotation = originalRotation * xQuaternion * yQuaternion;

    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
