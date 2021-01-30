using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        int scenes = SceneManager.sceneCount;
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        level = level > 1 ? 0 : level;

        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
