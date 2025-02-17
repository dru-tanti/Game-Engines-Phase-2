﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(PlayerControl))]
public class CanvasController : MonoBehaviour
{
    public static bool GameIsPaused = false;
	public GameState GameState;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    [SerializeField]
    private PlayerControl player;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        if(player.isDead == true)
        {
            StartCoroutine(Death());
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(Tutorial());
        }

        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            StartCoroutine(Credits());
        }
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Resume()
    {
        Debug.Log("Resuming Game");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public IEnumerator Death()
    {
        AudioManager.current.Play("Death");
        yield return new WaitForSeconds(1f);
        GameOver();
    }

    public IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator Credits()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}