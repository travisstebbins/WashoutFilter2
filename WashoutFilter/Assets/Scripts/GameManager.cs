using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<VideoClip> m_videos;
    public int videoIndex = 0;

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
