using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicCollection;
    public static MusicManager instance;
    private AudioSource audioSource;

    private int stage;

    private void Awake()
    {
        if (!instance) { instance = this; return; }
        Destroy(gameObject);
    }

    private void Start()
    {
        stage = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        PlayMusic(stage);
    }

    private void Update()
    {
        StageMusic();
    }

    void StageMusic()
    {
        if (stage != SceneManager.GetActiveScene().buildIndex)
        {
            stage = SceneManager.GetActiveScene().buildIndex;
            PlayMusic(stage);
        }
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = musicCollection[index];
        audioSource.Play();
    }


}
