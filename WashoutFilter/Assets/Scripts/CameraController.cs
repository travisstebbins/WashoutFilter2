using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    // SERIALIZE FIELD VARIABLES
    [SerializeField] GameObject videoSphere;
    [SerializeField] float washoutDelay;
    [SerializeField] float degreesPerSecond;
    [SerializeField] float washoutThreshold;
    [SerializeField] float minDeltaRotation;
    [SerializeField] AnimationCurve curve;

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
        if (Mathf.Abs(adjustedRotation) > washoutThreshold && Mathf.Abs(adjustedRotation - prevYRotation) <= minDeltaRotation && !rotating)
        {
            currentHoldTime += Time.deltaTime;
            if (currentHoldTime >= washoutDelay)
            {
                StartCoroutine(washoutCoroutine());
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
        Debug.Log("starting washout coroutine");
        rotating = true;
        float startingRotation = videoSphere.transform.eulerAngles.y;
        float targetRotationAmount = transform.rotation.eulerAngles.y > 180 ? 360 - transform.rotation.eulerAngles.y : -transform.rotation.eulerAngles.y;
        int direction = targetRotationAmount >= 0 ? 1 : -1;
        float amountRotated = 0;
        float totalTime = (1.0f / degreesPerSecond) * Mathf.Abs(targetRotationAmount);
        float startTime = Time.time;
        while (Time.time < startTime + totalTime)
        {
            float rotationProportion = curve.Evaluate((Time.time - startTime) / totalTime);
            videoSphere.transform.rotation = Quaternion.Euler(new Vector3(videoSphere.transform.eulerAngles.x, startingRotation + rotationProportion * targetRotationAmount, videoSphere.transform.eulerAngles.z));
            //float step = direction * speedMultiplier * Time.deltaTime;
            //videoSphere.transform.Rotate(new Vector3(0, step, 0));
            //amountRotated += step;
            yield return null;
        }
        rotating = false;
        Debug.Log("finishing washout coroutine");
    }
}