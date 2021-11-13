using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    private static AudioMaster m_instance;
    [SerializeField]
    private int m_maxNumberAudio = 16;

    private List<AudioSource> m_audioSources = new List<AudioSource>();

    private AudioSource m_musicSource;
    void Start()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < m_maxNumberAudio; i++)
        {
            GameObject go = new GameObject($"Audio{i}");
            go.transform.parent = transform;
            AudioSource aus = go.AddComponent<AudioSource>();
            m_audioSources.Add(aus);
        }

        GameObject TameObject = new GameObject("Music",
            typeof(AudioSource));
        m_musicSource = TameObject.GetComponent<AudioSource>();
    }

    public static void PlayMusic(AudioClip m)
    {
        if (m_instance.m_musicSource.isPlaying)
        {
            if (m_instance.m_musicSource.clip == m)
            {
                return;
            }
            m_instance.m_musicSource.Stop();
        }

        m_instance.m_musicSource.clip = m;
        m_instance.m_musicSource.spatialBlend = 0;
        m_instance.m_musicSource.loop = true;

        m_instance.m_musicSource.Play();
    }

    public static void PlaySFX2D(AudioClip sfx)
    {
        AudioSource aus = GetFreeSource();
        if (aus != null)
        {
            aus.clip = sfx;
            aus.spatialBlend = 0;
            aus.loop = false;

            aus.Play();
        }
    }
    public static void PlaySFX3D(AudioClip sfx, Vector3 pos)
    {
        AudioSource aus = GetFreeSource();
        if (aus != null)
        {
            aus.clip = sfx;
            aus.spatialBlend = 1;
            aus.loop = false;
            aus.transform.position = pos;
            aus.Play();
        }
    }
    private static AudioSource GetFreeSource()
    {
        foreach (AudioSource audioSource in m_instance.m_audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }

        return null;
    }
}
