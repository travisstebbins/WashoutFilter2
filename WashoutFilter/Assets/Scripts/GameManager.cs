using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // SERIALIZEFIELD VARIABLES
    public List<VideoClip> m_videos;
	[Range(0,2)]
	public int videoIndex;
	[Range(1,2)]
	public int speedPreset;
	[Range(1,2)]
	public int dATPreset;
	public bool washoutFilterEnabled;

    // PROPERTIES
    public float degreesPerSecond
	{
		get
		{
			switch (speedPreset)
			{
				case 1:
					return 4;
					break;
				case 2:
					return 20;
					break;
				default:
					return 4;
					break;
			}
		}
	}

	public float washoutDelay
	{
		get
		{
			switch (dATPreset)
			{
			case 1:
				return 1.5f;
				break;
			case 2:
				return 4;
				break;
			default:
				return 1.5f;
				break;
			}
		}
	}

    public float washoutThreshold
	{
		get
		{
			switch (dATPreset)
			{
				case 1:
					return 45;
					break;
				case 2:
					return 25;
					break;
				default:
					return 45;
					break;
			}
		}
	}

    // INSTANCE
    static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public VideoClip currentVideo
    {
        get
        {
            return m_videos[videoIndex];
        }
    }
}
