using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<VideoClip> m_videos;
    int m_videoIndex = 0;
    public bool washoutFilterEnabled = true;

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
