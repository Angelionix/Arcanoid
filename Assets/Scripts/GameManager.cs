using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private int _lives = 3;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    [SerializeField] private UiUpdater _uiUpdater;
    [SerializeField] private FieldSpawner _fs;
    [SerializeField] private Baller _ball;
    private Scene scene;

    public int ScneNumber
    {
        get 
        {
            return scene.buildIndex;   
        }
    }

    public int Score
    {
        set
        {
            _score += value;
            _uiUpdater.ChangeScore(_score);
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
            _uiUpdater.ChangeScore(_score);
            _uiUpdater.ChangeLives(_lives);
            FieldSpawner.blocksOver += LoadNextLevel;
        }
    }

    public void ChangeLives()
    {
        _lives -= 1;
        _uiUpdater.ChangeLives(_lives);
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
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void RestartLevel()
    {
        _lives = 3;
        _score = 0;
        _uiUpdater.ChangeScore(_score);
        _uiUpdater.ChangeLives(_lives);
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
        _fs.FieldReActivate();
        _ball.BallInitialisator();
        Time.timeScale = 1;
    }
}
