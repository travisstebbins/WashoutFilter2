using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // SERIALIZEFIELD VARIABLES
    public List<VideoClip> m_videos;
	public int videoIndex;
	public int preset;
	public bool washoutFilterEnabled;

    // PROPERTIES
    public float washoutDelay
	{
		get
		{
			switch (preset)
			{
				case 1:
					return 1.5f;
					break;
				case 2:
					return 5;
					break;
				case 3:
					return 3;
					break;
				default:
					return 1.5f;
					break;
			}
		}
	}

    public float degreesPerSecond
	{
		get
		{
			switch (preset)
			{
				case 1:
					return 5;
					break;
				case 2:
					return 40;
					break;
				case 3:
					return 20;
					break;
				default:
					return 5;
					break;
			}
		}
	}

    public float washoutThreshold
	{
		get
		{
			switch (preset)
			{
				case 1:
					return 45;
					break;
				case 2:
					return 30;
					break;
				case 3:
					return 37;
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
