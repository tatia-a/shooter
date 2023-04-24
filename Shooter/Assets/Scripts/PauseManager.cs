using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // синглтон
    public static PauseManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Поля и методы класса

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameUI;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Вызываем метод возобновления игры
            }
            else
            {
                PauseGame(); // Вызываем метод паузы игры
            }
        }
    }

    public bool GetPauseState()
    {
        return isPaused;
    }
    public void PauseGame()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; // Останавливаем время в игре
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; // Возобновляем время в игре
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
