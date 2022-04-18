using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    [SerializeField] Text _scoreField;
    [SerializeField] Text _lifeField;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            _scoreField = GameObject.Find("ScoreValue").GetComponent<Text>();
            _lifeField = GameObject.Find("LiveValue").GetComponent<Text>();
        }
    }

    public void ChangeScore(int value)
    {
        _scoreField.text = value.ToString();
    }

    public void ChangeLives(int value)
    {
        _lifeField.text = value.ToString();
    }
}
