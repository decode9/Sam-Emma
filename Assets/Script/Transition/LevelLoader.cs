using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;

    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        instance = this;
    }

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
    }
}
