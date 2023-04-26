using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
