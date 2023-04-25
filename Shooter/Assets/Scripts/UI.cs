using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI flagsText;
    [SerializeField] private Slider playerHealthUI;
    [SerializeField] private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealthUI.maxValue = playerHealth.Health;
    }
    // Update is called once per frame
    void Update()
    {
        flagsText.text = FlagCounter.Instance.ReachedFlags.ToString();
        playerHealthUI.value = playerHealth.Health;
    }
}
