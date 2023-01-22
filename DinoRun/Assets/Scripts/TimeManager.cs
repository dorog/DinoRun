using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float _startObjectSpeed;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private DifficultyManager _difficultyManager;
    [SerializeField]
    private float[] _difficultyLevelTimeScales;

    private DifficultyLevelsContainer<float> _difficultyLevelsContainer;

    public static float ObjectsSpeed { get; private set; }

    private void Awake()
    {
        ObjectsSpeed = _startObjectSpeed;
    }

    private void Start()
    {
        _playerController.Died.Subscribe(StopObjects);
        _difficultyManager.DifficultyIncreased.Subscribe(RaiseDifficultyLevel);

        _difficultyLevelsContainer = new(_difficultyLevelTimeScales);
        Time.timeScale = _difficultyLevelsContainer.GetCurrentLevel();
    }

    private void StopObjects()
    {
        ObjectsSpeed = 0;
        Time.timeScale = 1;
    }

    private void RaiseDifficultyLevel()
    {
        Time.timeScale = _difficultyLevelsContainer.RaiseDifficulty();
    }
}
