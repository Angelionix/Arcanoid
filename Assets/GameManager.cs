using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private int _lives = 3;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    private Scene scene;

    public int ScneNumber
    {
        get 
        {
            return scene.buildIndex;   
        }
    }

    public delegate void ScoreChanged(int value);
    public static ScoreChanged scoreChanged;

    public delegate void LivesChanged(int value);
    public static LivesChanged livesChanged;

    public delegate void LevelRestarted();
    public static LevelRestarted levelRestarted;
    public int Score
    {
        set
        {
            _score += value;
            scoreChanged(_score);
        }
    }

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
        if (scene.buildIndex > 0)
        {
            _score = 0;
            _lives = 3;
            scoreChanged(_score);
            livesChanged(_lives);
            Baller.deathBall += ChangeLives;
            FieldSpawner.blocksOver += LoadNextLevel;
        }
    }

    private void ChangeLives()
    {
        _lives -= 1;
        livesChanged(_lives);
        if (_lives <= 0)
        {
            Time.timeScale = 0f;
            _losePanel.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings -1 > scene.buildIndex)
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        else 
        {
            Time.timeScale = 0f;
            _winPanel.SetActive(true);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void RestartLevel()
    {
        _lives = 3;
        _score = 0;
        livesChanged(_lives);
        scoreChanged(_score);
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
        levelRestarted();
        Time.timeScale = 1;
    }
}
