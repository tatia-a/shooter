using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // ��������
    public static PauseManager instance;

    private void Awake()
    {
        instance = this;
    }

    // ���� � ������ ������

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
                ResumeGame(); // �������� ����� ������������� ����
            }
            else
            {
                PauseGame(); // �������� ����� ����� ����
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
        Time.timeScale = 0f; // ������������� ����� � ����
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; // ������������ ����� � ����
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
