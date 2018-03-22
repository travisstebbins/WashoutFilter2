using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // SERIALIZEFIELD VARIABLES
    public List<VideoClip> m_videos;
	[Range(1,3), Tooltip("1 = Rain or Shine, 2 = Special Delivery, 3 = Buggy Night")]
	public int videoIndex;
	[Range(1,3), Tooltip("1 = slow, 2 = fast, 3 = control")]
	public int speedPreset;
	[Range(1,2), Tooltip("1 = short delay large angle, 2 = long delay small angle")]
	public int dATPreset;
	public int participantID;
	public int sessionID;

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
				case 3:
					return 0;
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
            return m_videos[videoIndex - 1];
        }
    }
}
