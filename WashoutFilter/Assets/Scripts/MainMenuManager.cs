using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem rainOrShineButton;

    void OnEnable()
    {
        rainOrShineButton.OnClick += rainOrShine;
    }

    void OnDisable()
    {
        rainOrShineButton.OnClick -= rainOrShine;
    }

    public void rainOrShine()
    {
        GameManager.instance.videoIndex = 0;
        SceneManager.LoadScene("Main");
    }
}
