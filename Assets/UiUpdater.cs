using UnityEngine.UI;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    [SerializeField] Text _scoreField;
    [SerializeField] Text _lifeField;

    private void Awake()
    {
        GameManager.scoreChanged += ChangeScore;
        GameManager.livesChanged += ChangeLives;
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
