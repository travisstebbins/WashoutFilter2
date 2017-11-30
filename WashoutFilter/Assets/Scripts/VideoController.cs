using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    void OnEnable()
    {
        if (GetComponent<VRStandardAssets.Utils.VRInteractiveItem>() == null)
        {
        }
        GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().OnClick += TogglePlay;
    }

    void OnDisable()
    {
        GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().OnClick -= TogglePlay;
    }

    public void TogglePlay()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            GetComponent<VideoPlayer>().Pause();
        }
        else
        {
            GetComponent<VideoPlayer>().Play();
        }
    }
}
