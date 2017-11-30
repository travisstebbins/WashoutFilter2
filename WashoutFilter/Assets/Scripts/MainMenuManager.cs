using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem toggleWashoutFilterButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem rainOrShineButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem specialDeliveryButton;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem buggyNightButton;

    void OnEnable()
    {
        toggleWashoutFilterButton.OnClick += toggleWashoutFilter;
        rainOrShineButton.OnClick += rainOrShine;
        specialDeliveryButton.OnClick += specialDelivery;
        buggyNightButton.OnClick += buggyNight;
    }

    void OnDisable()
    {
        toggleWashoutFilterButton.OnClick -= toggleWashoutFilter;
        rainOrShineButton.OnClick -= rainOrShine;
        specialDeliveryButton.OnClick -= specialDelivery;
        buggyNightButton.OnClick -= buggyNight;
    }

    void Start()
    {
        if (GameManager.instance.washoutFilterEnabled)
        {
            toggleWashoutFilterButton.GetComponentInChildren<Text>().text = "Washout Filter Enabled";
            toggleWashoutFilterButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            toggleWashoutFilterButton.GetComponentInChildren<Text>().text = "Washout Filter Disabled";
            toggleWashoutFilterButton.GetComponent<Image>().color = Color.gray;
        }
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

    public void toggleWashoutFilter()
    {
        if (GameManager.instance.washoutFilterEnabled)
        {
            GameManager.instance.washoutFilterEnabled = false;
            toggleWashoutFilterButton.GetComponentInChildren<Text>().text = "Washout Filter Disabled";
            toggleWashoutFilterButton.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            GameManager.instance.washoutFilterEnabled = true;
            toggleWashoutFilterButton.GetComponentInChildren<Text>().text = "Washout Filter Enabled";
            toggleWashoutFilterButton.GetComponent<Image>().color = Color.white;
        }
    }
}
