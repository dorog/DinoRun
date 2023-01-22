using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private float _score = 0;

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    private bool _isPlayerAlive = true;

    private void Start()
    {
        _playerController.Died.Subscribe(StopScoring);
    }

    private void StopScoring()
    {
        _isPlayerAlive = false;
    }

    private void Update()
    {
        if (_isPlayerAlive)
        {
            _score += Time.deltaTime;
            _textMeshPro.text = Convert.ToInt32(_score).ToString("D4");
        }
    }
}
