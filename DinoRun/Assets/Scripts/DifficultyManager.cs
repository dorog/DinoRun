using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameEvent DifficultyIncreased { get; } = new();

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private float[] _difficultyTimes;

    private float _spentTime = 0;

    private int _nextDifficultyLevel = 0;
    private bool _isPlayerAlive = true;

    private void Start()
    {
        _playerController.Died.Subscribe(Stop);
    }

    private void Stop()
    {
        _isPlayerAlive = false;
    }

    private void Update()
    {
        if (_isPlayerAlive)
        {
            _spentTime += Time.deltaTime;

            if (_difficultyTimes.Length - 1 > _nextDifficultyLevel && _difficultyTimes[_nextDifficultyLevel] <= _spentTime)
            {
                DifficultyIncreased.Call();
                _nextDifficultyLevel++;
            }
        }
    }
}
