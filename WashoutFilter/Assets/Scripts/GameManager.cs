using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // SERIALIZEFIELD VARIABLES
    [SerializeField] List<VideoClip> m_videos;

    // CLASS VARIABLES
    int m_videoIndex = 0;
    int m_preset = 1;
    public bool washoutFilterEnabled = true;

    // PROPERTIES
    public float washoutDelay { get; private set; }
    public float degreesPerSecond { get; private set; }
    public float washoutThreshold { get; private set; }
    public int curveIndex { get; private set; }
    public int preset
    {
        get
        {
            return m_preset;
        }
        set
        {
            m_preset = value;
            switch(m_preset)
            {
                case 1:
                    washoutDelay = 1.5f;
                    degreesPerSecond = 5;
                    washoutThreshold = 45;
                    curveIndex = 0;
                    break;
                case 2:
                    washoutDelay = 5;
                    degreesPerSecond = 40;
                    washoutThreshold = 30;
                    curveIndex = 0;
                    break;
                case 3:
                    washoutDelay = 3;
                    degreesPerSecond = 20;
                    washoutThreshold = 37;
                    curveIndex = 1;
                    break;
                default:
                    washoutDelay = 1.5f;
                    degreesPerSecond = 5;
                    washoutThreshold = 45;
                    curveIndex = 0;
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

    public int videoIndex
    {
        get
        {
            return m_videoIndex;
        }
        set
        {
            m_videoIndex = Mathf.Min(m_videos.Count - 1, Mathf.Max(0, value));
        }
    }
}
