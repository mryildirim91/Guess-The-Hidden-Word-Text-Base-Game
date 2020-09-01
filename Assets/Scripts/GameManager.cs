using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    private GameObject _gameOverPanel;

    private void Awake()
    {
        _instance = this;
    }

    public void GameOver(bool isGameOver)
    {
        if (isGameOver)
        {
            _gameOverPanel.SetActive(true);
        }
        else
        {
            _gameOverPanel.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        GameOver(false);
        SceneManager.LoadSceneAsync(0);
    }
}
