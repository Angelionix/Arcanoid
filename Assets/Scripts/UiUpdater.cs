using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    [SerializeField] Text _scoreField;
    [SerializeField] Text _lifeField;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            GameManager.livesChanged += ChangeLives;
            GameManager.scoreChanged += ChangeScore;
            GameManager.losing += LosePanelView;
            GameManager.winning -= WinPanelView;
        }
    }

    private void ChangeScore(int value)
    {
        _scoreField.text = value.ToString();
    }

    private void ChangeLives(int value)
    {
        _lifeField.text = value.ToString();
    }

    private void LosePanelView()
    {
        _losePanel.SetActive(true);
    }

    private void WinPanelView()
    {
        _winPanel.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.scoreChanged -= ChangeScore;
        GameManager.livesChanged -= ChangeLives;
        GameManager.losing -= LosePanelView;
        GameManager.winning -= WinPanelView;
    }
}
