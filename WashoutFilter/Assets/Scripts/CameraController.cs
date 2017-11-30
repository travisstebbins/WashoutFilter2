using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    // CLASS VARIABLES
    Gyroscope gyro;

    // UNITY FUNCTIONS
	void Start () 
	{
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
		}
		else
		{
			Debug.Log("Phone doesen't support gyro controls");
		}
	}

	void Update () 
	{
        transform.rotation = Quaternion.Euler(new Vector3((transform.eulerAngles.x - Input.gyro.rotationRateUnbiased.x) % 360, (transform.eulerAngles.y - Input.gyro.rotationRateUnbiased.y) % 360, 0));
	}
}