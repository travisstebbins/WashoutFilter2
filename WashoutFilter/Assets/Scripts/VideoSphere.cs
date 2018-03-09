using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphere : MonoBehaviour
{
	public VideoClip videoToPlay;

	private VideoPlayer videoPlayer;
	private VideoSource videoSource;

	//Audio
	private AudioSource audioSource;

	// Use this for initialization
	void Start()
	{
		Application.runInBackground = true;
		StartCoroutine(playVideo());
	}

	IEnumerator playVideo()
	{
		videoToPlay = GameManager.instance.currentVideo;

		videoPlayer = gameObject.GetComponent<VideoPlayer>();

		audioSource = gameObject.GetComponent<AudioSource>();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;

		//We want to play from video clip not from url
		videoPlayer.source = VideoSource.VideoClip;

		//Set Audio Output to AudioSource
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);

		//Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//Wait until video is prepared
		while (!videoPlayer.isPrepared)
		{
			yield return null;
		}

		//Play Video
		videoPlayer.Play();

		//Play Sound
		audioSource.Play();
	}
}
