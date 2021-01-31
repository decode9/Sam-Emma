using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static GameOverController instance = null;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitForAnimation());
    }

    public void RestartScene()
    {
        FreezeScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitScene()
    {
        FreezeScene(1);
        SceneManager.LoadScene("SecondScreen");
    }

    private void FreezeScene(int playOrStop)
    {
        Time.timeScale = playOrStop;
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        FreezeScene(0);
    }
}
