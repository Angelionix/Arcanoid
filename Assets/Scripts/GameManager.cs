using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _lives;

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
            scoreChanged(_score);
        }
    }

    public delegate void ScoreChanged(int value);
    public static ScoreChanged scoreChanged;

    public delegate void LivesChanged(int value);
    public static LivesChanged livesChanged;

    public delegate void Losing();
    public static Losing losing;

    public delegate void Winning();
    public static Winning winning;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex > 0)
        {
            FieldSpawner.blocksOver += LoadNextLevel;
            Baller.ballDeath += ChangeLives;
        }
    }

    private void Start()
    {
        if (scene.buildIndex > 0)
        {
            livesChanged(_lives);
            scoreChanged(_score);
        }
    }

    public void ChangeLives(int value)
    {
        _lives += value;
        livesChanged(_lives);
        if (_lives <= 0)
        {
            Time.timeScale = 0f;
            losing();
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
            winning();
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
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Baller.ballDeath -= ChangeLives;
        FieldSpawner.blocksOver -= LoadNextLevel;
    }
}
