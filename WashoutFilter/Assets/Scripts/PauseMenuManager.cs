using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] WashoutFilter washoutFilter;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseBackground;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem resumeButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem washoutDelayMinusButton;
    [SerializeField] Text washoutDelayValue;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem washoutDelayPlusButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem degreesPerSecondMinusButton;
    [SerializeField] Text degreesPerSecondValue;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem degreesPerSecondPlusButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem washoutThresholdMinusButton;
    [SerializeField] Text washoutThresholdValue;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem washoutThresholdPlusButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem curveIndexMinusButton;
    [SerializeField] Text curveIndexValue;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem curveIndexPlusButton;
    bool paused = false;

    void OnEnable()
    {
        GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().OnClick += TogglePause;
        resumeButton.OnClick += Resume;
        washoutDelayMinusButton.OnClick += DecrementWashoutDelay;
        washoutDelayPlusButton.OnClick += IncrementWashoutDelay;
        degreesPerSecondMinusButton.OnClick += DecrementDegreesPerSecond;
        degreesPerSecondPlusButton.OnClick += IncrementDegreesPerSecond;
        washoutThresholdMinusButton.OnClick += DecrementWashoutThreshold;
        washoutThresholdPlusButton.OnClick += IncrementWashoutThreshold;
        curveIndexMinusButton.OnClick += DecrementCurveIndex;
        curveIndexPlusButton.OnClick += IncrementCurveIndex;
}

    void OnDisable()
    {
        GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().OnClick -= TogglePause;
        resumeButton.OnClick -= Resume;
        washoutDelayMinusButton.OnClick -= DecrementWashoutDelay;
        washoutDelayPlusButton.OnClick -= IncrementWashoutDelay;
        degreesPerSecondMinusButton.OnClick -= DecrementDegreesPerSecond;
        degreesPerSecondPlusButton.OnClick -= IncrementDegreesPerSecond;
        washoutThresholdMinusButton.OnClick -= DecrementWashoutThreshold;
        washoutThresholdPlusButton.OnClick -= IncrementWashoutThreshold;
        curveIndexMinusButton.OnClick -= DecrementCurveIndex;
        curveIndexPlusButton.OnClick -= IncrementCurveIndex;
    }

    void Start()
    {
        washoutDelayValue.text = washoutFilter.washoutDelay.ToString();
        degreesPerSecondValue.text = washoutFilter.degreesPerSecond.ToString();
        washoutThresholdValue.text = washoutFilter.washoutThreshold.ToString();
        curveIndexValue.text = washoutFilter.curveIndex.ToString();
    }

    public void TogglePause()
    {
        if (!paused)
        {
            video.Pause();
            pauseBackground.SetActive(true);
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            video.Play();
            pauseBackground.SetActive(false);
            pauseMenu.SetActive(false);
            paused = false;
        }
    }

    public void Resume()
    {
        Debug.Log("Resume");
        video.Play();
        pauseBackground.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void DecrementWashoutDelay()
    {
        washoutFilter.washoutDelay--;
        washoutDelayValue.text = washoutFilter.washoutDelay.ToString();
    }

    public void IncrementWashoutDelay()
    {
        washoutFilter.washoutDelay++;
        washoutDelayValue.text = washoutFilter.washoutDelay.ToString();
    }

    public void DecrementDegreesPerSecond()
    {
        washoutFilter.degreesPerSecond--;
        degreesPerSecondValue.text = washoutFilter.degreesPerSecond.ToString();
    }

    public void IncrementDegreesPerSecond()
    {
        washoutFilter.degreesPerSecond++;
        degreesPerSecondValue.text = washoutFilter.degreesPerSecond.ToString();
    }

    public void DecrementWashoutThreshold()
    {
        washoutFilter.washoutThreshold--;
        washoutThresholdValue.text = washoutFilter.washoutThreshold.ToString();
    }

    public void IncrementWashoutThreshold()
    {
        washoutFilter.washoutThreshold++;
        washoutThresholdValue.text = washoutFilter.washoutThreshold.ToString();
    }

    public void DecrementCurveIndex()
    {
        washoutFilter.curveIndex--;
        curveIndexValue.text = washoutFilter.curveIndex.ToString();
    }

    public void IncrementCurveIndex()
    {
        washoutFilter.curveIndex++;
        curveIndexValue.text = washoutFilter.curveIndex.ToString();
    }
}