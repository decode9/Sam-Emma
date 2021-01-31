using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadNextLevel()
    {

        int lastIndex = SceneManager.sceneCountInBuildSettings;

        int actualIndex = SceneManager.GetActiveScene().buildIndex;

        int nextIndex = ++actualIndex;

        Debug.Log(lastIndex);
        Debug.Log(nextIndex);

        if (lastIndex != nextIndex) SceneManager.LoadScene(nextIndex);

    }
}
