using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // SERIALIZEFIELD VARIABLES
    public List<VideoClip> m_videos;
	[Range(0,2), Tooltip("0 = Rain or Shine, 1 = Special Delivery, 2 = Buggy Night")]
	public int videoIndex;
	[Range(1,2), Tooltip("1 = slow, 2 = fast")]
	public int speedPreset;
	[Range(1,2), Tooltip("1 = short delay large angle, 2 = long delay small angle")]
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
					return 3;
					break;
				case 2:
					return 13;
					break;
				default:
					return 3;
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
				return 2;
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
