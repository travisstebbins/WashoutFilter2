using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphere : MonoBehaviour
{
	void Start ()
	{
		GetComponent<VideoPlayer> ().clip = GameManager.instance.currentVideo;
	}
}
