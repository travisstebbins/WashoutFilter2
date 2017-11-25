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
		transform.rotation = Quaternion.Euler (new Vector3 (transform.eulerAngles.x - Input.gyro.rotationRateUnbiased.x, transform.eulerAngles.y -Input.gyro.rotationRateUnbiased.y, 0));
        if (Mathf.Abs(transform.rotation.eulerAngles.y) > washoutThreshold && Mathf.Abs(transform.rotation.eulerAngles.y - prevYRotation) <= minDeltaRotation && !rotating)
        {
            currentHoldTime += Time.deltaTime;
            if (currentHoldTime >= washoutDelay)
            {
                StartCoroutine(washoutCoroutine());
            }
        }
        else
        {
            prevYRotation = transform.rotation.eulerAngles.y;
            currentHoldTime = 0;
        }
	}

    IEnumerator washoutCoroutine()
    {
        rotating = true;
        float targetRotation = (-transform.rotation.eulerAngles.y - videoSphere.transform.rotation.eulerAngles.y) % 360;
        int direction = targetRotation >= 0 ? 1 : -1;
        Debug.Log("pre-target rotation: " + targetRotation);
        if (targetRotation < 0)
        {
            targetRotation = 360 + targetRotation;
        }
        targetRotation += 90;
        Debug.Log("post-target rotation: " + targetRotation);
        float step = targetRotation * washoutSpeed;
        while (Mathf.Abs(videoSphere.transform.rotation.eulerAngles.y - targetRotation) > 10f)
        {
            Debug.Log("rotation: " + videoSphere.transform.eulerAngles.y);
            videoSphere.transform.Rotate(new Vector3(0, step * direction * Time.deltaTime, 0));
            yield return null;
        }
        rotating = false;
    }
}