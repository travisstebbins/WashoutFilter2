using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    // SERIALIZE FIELD VARIABLES
    [SerializeField] GameObject videoSphere;
    [SerializeField] float washoutDelay;
    [SerializeField] float washoutSpeed;
    [SerializeField] float washoutThreshold;
    [SerializeField] float minDeltaRotation;

    // CLASS VARIABLES
    Gyroscope gyro;
    float prevYRotation;
    float currentHoldTime;
    bool rotating;

	void Start () 
	{
        currentHoldTime = 0;
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
		}
		else
		{
			Debug.Log("Phone doesen't support");
		}
	}

	void Update () 
	{
        transform.rotation = Quaternion.Euler(new Vector3((transform.eulerAngles.x - Input.gyro.rotationRateUnbiased.x) % 360, (transform.eulerAngles.y - Input.gyro.rotationRateUnbiased.y) % 360, 0));
        float adjustedRotation = transform.rotation.eulerAngles.y > 180 ?transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
        //Debug.Log("adjustedRotation: " + adjustedRotation);
        if (Mathf.Abs(adjustedRotation) > washoutThreshold && Mathf.Abs(adjustedRotation - prevYRotation) <= minDeltaRotation && !rotating)
        {
            currentHoldTime += Time.deltaTime;
            if (currentHoldTime >= washoutDelay)
            {
                StartCoroutine(washoutCoroutine());
                //float targetRotation = (-90 - transform.rotation.eulerAngles.y - videoSphere.transform.rotation.eulerAngles.y) % 360;
                //videoSphere.transform.rotation = Quaternion.Euler(new Vector3(0, targetRotation, 0));
                //transform.rotation = Quaternion.identity;
                //currentHoldTime = 0;
            }
        }
        else
        {
            prevYRotation = adjustedRotation;
            currentHoldTime = 0;
        }
	}

    IEnumerator washoutCoroutine()
    {
        rotating = true;
        float targetRotationAmount = transform.rotation.eulerAngles.y > 180 ? 360 - transform.rotation.eulerAngles.y : -transform.rotation.eulerAngles.y;
        //if (targetRotationAmount < 0)
        //{
        //    targetRotationAmount += 360;
        //}
        int direction = targetRotationAmount >= 0 ? 1 : -1;
        float amountRotated = 0;
        //Debug.Log("target rotation amount: " + targetRotationAmount);
        while (Mathf.Abs(amountRotated) < Mathf.Abs(targetRotationAmount))
        {
            videoSphere.transform.Rotate(new Vector3(0, direction * washoutSpeed * Time.deltaTime, 0));
            amountRotated += direction * washoutSpeed * Time.deltaTime;
            //Debug.Log("amount rotated: " + amountRotated);
            yield return null;
        }
        rotating = false;

        //rotating = true;
        //int direction = transform.rotation.eulerAngles.y > 180 ? 1 : -1;
        //while (transform.rotation.eulerAngles.y % 360 > 5)
        //{
        //    transform.Rotate(new Vector3(0, direction * Time.deltaTime * washoutSpeed, 0));
        //    yield return null;
        //}
        //rotating = false;
    }
}