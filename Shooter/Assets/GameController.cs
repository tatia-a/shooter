using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if(FlagCounter.Instance.ReachedFlags == FlagCounter.Instance.QuantityFlags)
        {
            EndTheGame("Victory");
        }
        // посчитать убитых врагов
        if(playerHealth.Health <= 0)
        {
            EndTheGame("Defeat");
        }
    }

    void EndTheGame(string gameResult)
    {
        PlayerPrefs.SetString("GameResult", gameResult);
        SceneManager.LoadScene(2);
    }

}
