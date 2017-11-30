using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem rainOrShineButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem specialDeliveryButton;

    void OnEnable()
    {
        rainOrShineButton.OnClick += rainOrShine;
        specialDeliveryButton.OnClick += specialDelivery;
    }

    void OnDisable()
    {
        rainOrShineButton.OnClick -= rainOrShine;
        specialDeliveryButton.OnClick -= specialDelivery;
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
}
