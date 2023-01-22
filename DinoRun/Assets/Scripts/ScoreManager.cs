using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private const string _highScoreKey = "HS";
    private const string _scoreFormat = "D4";

    private float _score = 0;
    private int _highScore;

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private TextMeshProUGUI _currentScoreText;
    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    private bool _isPlayerAlive = true;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt(_highScoreKey, 0);
        _highScoreText.text = _highScore.ToString(_scoreFormat);

        _playerController.Died.Subscribe(StopScoring);
    }

    private void StopScoring()
    {
        _isPlayerAlive = false;

        int lastScore = Convert.ToInt32(_score);
        if (lastScore > _highScore)
        {
            PlayerPrefs.SetInt(_highScoreKey, lastScore);
            _highScoreText.text = lastScore.ToString(_scoreFormat);
        }
    }

    private void Update()
    {
        if (_isPlayerAlive)
        {
            _score += Time.deltaTime;
            _currentScoreText.text = Convert.ToInt32(_score).ToString(_scoreFormat);
        }
    }
}
