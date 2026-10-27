using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public TextMeshProUGUI coinText;
    public GameObject winPanel; 
    
    private int coins = 0;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE! Coins: " + coins);
        
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        
        Time.timeScale = 0f; // freeze the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
