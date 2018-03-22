using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WashoutFilter : MonoBehaviour
{
    // SERIALIZE FIELD VARIABLES
    [SerializeField] GameObject videoSphere;
    [SerializeField] float m_washoutDelay;
    [SerializeField] float m_degreesPerSecond;
    [SerializeField] float m_washoutThreshold;
    [SerializeField] float minDeltaRotation;
    [SerializeField] AnimationCurve curve;

    // CLASS VARIABLES
    float prevYRotation;
    float currentHoldTime;
    bool rotating;
    Coroutine rotationCoroutine;

    // PROPERTIES
    public float washoutDelay
    {
        get
        {
            return m_washoutDelay;
        }
        set
        {
            m_washoutDelay = Mathf.Max(0, value);
        }
    }

    public float degreesPerSecond
    {
        get
        {
            return m_degreesPerSecond;
        }
        set
        {
            m_degreesPerSecond = Mathf.Max(1, value);
        }
    }

    public float washoutThreshold
    {
        get
        {
            return m_washoutThreshold;
        }
        set
        {
            m_washoutThreshold = Mathf.Max(0, value);
        }
    }

    // UNITY FUNCTIONS
    void Start()
    {
        currentHoldTime = 0;
		if (GameManager.instance.speedPreset == 3)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }
        washoutDelay = GameManager.instance.washoutDelay;
        degreesPerSecond = GameManager.instance.degreesPerSecond;
        washoutThreshold = GameManager.instance.washoutThreshold;
    }

    void Update()
    {
        float adjustedRotation = transform.rotation.eulerAngles.y > 180 ? transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
        //Debug.Log(Mathf.Abs(adjustedRotation - prevYRotation));
        if (Mathf.Abs(adjustedRotation) > m_washoutThreshold && Mathf.Abs(adjustedRotation - prevYRotation) <= minDeltaRotation && !rotating)
        {
            currentHoldTime += Time.deltaTime;
            if (currentHoldTime >= m_washoutDelay)
            {
                rotationCoroutine = StartCoroutine(washoutCoroutine());
            }
        }
        else if (Mathf.Abs(adjustedRotation - prevYRotation) > minDeltaRotation && rotating)
        {
            StopCoroutine(rotationCoroutine);
            rotating = false;
            currentHoldTime = 0;
            Debug.Log("override");
        }
        else
        {
            currentHoldTime = 0;
        }
        prevYRotation = adjustedRotation;
    }

    IEnumerator washoutCoroutine()
    {
        rotating = true;
        float startingRotation = videoSphere.transform.eulerAngles.y;
        float targetRotationAmount = transform.rotation.eulerAngles.y > 180 ? 360 - transform.rotation.eulerAngles.y : -transform.rotation.eulerAngles.y;
        float totalTime = (1.0f / m_degreesPerSecond) * Mathf.Abs(targetRotationAmount);
        float startTime = Time.time;
        while (Time.time < startTime + totalTime)
        {
            float rotationProportion = curve.Evaluate((Time.time - startTime) / totalTime);
            videoSphere.transform.rotation = Quaternion.Euler(new Vector3(videoSphere.transform.eulerAngles.x, startingRotation + rotationProportion * targetRotationAmount, videoSphere.transform.eulerAngles.z));
            yield return null;
        }
        rotating = false;
    }
}