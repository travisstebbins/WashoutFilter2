using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem rainOrShineButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem specialDeliveryButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem buggyNightButton;

    void OnEnable()
    {
        rainOrShineButton.OnClick += rainOrShine;
        specialDeliveryButton.OnClick += specialDelivery;
        buggyNightButton.OnClick += buggyNight;
    }

    void OnDisable()
    {
        rainOrShineButton.OnClick -= rainOrShine;
        specialDeliveryButton.OnClick -= specialDelivery;
        buggyNightButton.OnClick -= buggyNight;
    }

    public void rainOrShine()
    {
        GameManager.instance.videoIndex = 0;
        SceneManager.LoadScene("Main");
    }

    public void specialDelivery()
    {
        GameManager.instance.videoIndex = 1;
        SceneManager.LoadScene("Main");
    }

    public void buggyNight()
    {
        GameManager.instance.videoIndex = 2;
        SceneManager.LoadScene("Main");
    }
}
