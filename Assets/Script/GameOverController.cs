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

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
    }
}
