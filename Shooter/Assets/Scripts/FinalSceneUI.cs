using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject victoryGO;
    [SerializeField] private GameObject defeatGO;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.GetString("GameResult") == "Victory")
        {
            victoryGO.SetActive(true);
        }
        else
        {
            defeatGO.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
