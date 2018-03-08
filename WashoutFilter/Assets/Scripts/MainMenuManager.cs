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
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem preset1Button;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem preset2Button;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem preset3Button;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem playButton;

    void OnEnable()
    {
        toggleWashoutFilterButton.OnClick += toggleWashoutFilter;
        rainOrShineButton.OnClick += rainOrShine;
        specialDeliveryButton.OnClick += specialDelivery;
        buggyNightButton.OnClick += buggyNight;
        preset1Button.OnClick += preset1;
        preset2Button.OnClick += preset2;
        preset3Button.OnClick += preset3;
        playButton.OnClick += play;
    }

    void OnDisable()
    {
        toggleWashoutFilterButton.OnClick -= toggleWashoutFilter;
        rainOrShineButton.OnClick -= rainOrShine;
        specialDeliveryButton.OnClick -= specialDelivery;
        buggyNightButton.OnClick -= buggyNight;
        preset1Button.OnClick -= preset1;
        preset2Button.OnClick -= preset2;
        preset3Button.OnClick -= preset3;
        playButton.OnClick -= play;
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
        switch(GameManager.instance.videoIndex)
        {
            case 0:
                rainOrShineButton.GetComponent<Image>().color = Color.white;
                specialDeliveryButton.GetComponent<Image>().color = Color.gray;
                buggyNightButton.GetComponent<Image>().color = Color.gray;
                break;
            case 1:
                rainOrShineButton.GetComponent<Image>().color = Color.gray;
                specialDeliveryButton.GetComponent<Image>().color = Color.white;
                buggyNightButton.GetComponent<Image>().color = Color.gray;
                break;
            case 2:
                rainOrShineButton.GetComponent<Image>().color = Color.gray;
                specialDeliveryButton.GetComponent<Image>().color = Color.gray;
                buggyNightButton.GetComponent<Image>().color = Color.white;
                break;
        }
		switch(GameManager.instance.speedPreset)
        {
            case 1:
                preset1Button.GetComponent<Image>().color = Color.white;
                preset2Button.GetComponent<Image>().color = Color.gray;
                preset3Button.GetComponent<Image>().color = Color.gray;
                break;
            case 2:
                preset1Button.GetComponent<Image>().color = Color.gray;
                preset2Button.GetComponent<Image>().color = Color.white;
                preset3Button.GetComponent<Image>().color = Color.gray;
                break;
            case 3:
                preset1Button.GetComponent<Image>().color = Color.gray;
                preset2Button.GetComponent<Image>().color = Color.gray;
                preset3Button.GetComponent<Image>().color = Color.white;
                break;
        }
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

    public void rainOrShine()
    {
        GameManager.instance.videoIndex = 0;
        rainOrShineButton.GetComponent<Image>().color = Color.white;
        specialDeliveryButton.GetComponent<Image>().color = Color.gray;
        buggyNightButton.GetComponent<Image>().color = Color.gray;
    }

    public void specialDelivery()
    {
        GameManager.instance.videoIndex = 1;
        rainOrShineButton.GetComponent<Image>().color = Color.gray;
        specialDeliveryButton.GetComponent<Image>().color = Color.white;
        buggyNightButton.GetComponent<Image>().color = Color.gray;
    }

    public void buggyNight()
    {
        GameManager.instance.videoIndex = 2;
        rainOrShineButton.GetComponent<Image>().color = Color.gray;
        specialDeliveryButton.GetComponent<Image>().color = Color.gray;
        buggyNightButton.GetComponent<Image>().color = Color.white;
    }

    public void preset1()
    {
		GameManager.instance.speedPreset = 1;
        preset1Button.GetComponent<Image>().color = Color.white;
        preset2Button.GetComponent<Image>().color = Color.gray;
        preset3Button.GetComponent<Image>().color = Color.gray;
    }

    public void preset2()
    {
		GameManager.instance.speedPreset = 2;
        preset1Button.GetComponent<Image>().color = Color.gray;
        preset2Button.GetComponent<Image>().color = Color.white;
        preset3Button.GetComponent<Image>().color = Color.gray;
    }

    public void preset3()
    {
		GameManager.instance.speedPreset = 3;
        preset1Button.GetComponent<Image>().color = Color.gray;
        preset2Button.GetComponent<Image>().color = Color.gray;
        preset3Button.GetComponent<Image>().color = Color.white;
    }

    public void play()
    {
        SceneManager.LoadScene("Main");
    }
}