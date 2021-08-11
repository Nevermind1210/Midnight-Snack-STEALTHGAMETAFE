using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool paused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        // if escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if paused resume game
            if (paused) ResumeGame();
            // else pause game
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        paused = false;
        // resume time
        Time.timeScale = 1f;
        // close pause menu
        pauseMenu.SetActive(false);
    }

    private void PauseGame()
    {
        paused = true;
        // freeze time
        Time.timeScale = 0f;
        // open pause menu
        pauseMenu.SetActive(true);
    }
}
