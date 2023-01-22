using UnityEngine;

public class MovingObjectsContainer : MonoBehaviour
{
    [SerializeField]
    private DifficultyManager _difficultyManager;
    [SerializeField]
    private MovingObjectsLevel[] _movingObjectsLevels;

    private MovingObjectsLevel _currentMovingObjectsLevel;
    private DifficultyLevelsContainer<MovingObjectsLevel> _difficultyLevelsContainer;

    private void Awake()
    {
        if (_movingObjectsLevels.Length > 1)
        {
            _difficultyLevelsContainer = new(_movingObjectsLevels);
            _currentMovingObjectsLevel = _difficultyLevelsContainer.GetCurrentLevel();

            _difficultyManager.DifficultyIncreased.Subscribe(RaiseDifficulty);
        }
        else
        {
            _currentMovingObjectsLevel = _movingObjectsLevels[0];
        }
    }

    private void RaiseDifficulty()
    {
        _currentMovingObjectsLevel = _difficultyLevelsContainer.RaiseDifficulty();
    }

    public MovingObjectInfo GetRandomMovingObject()
    {
        int movingObjectIndex = Random.Range(0, _currentMovingObjectsLevel.MovingObjects.Length);

        return new MovingObjectInfo()
        {
            MinFrequency = _currentMovingObjectsLevel.MinFrequency,
            MaxFrequency = _currentMovingObjectsLevel.MaxFrequency,
            MovingObject = _currentMovingObjectsLevel.MovingObjects[movingObjectIndex]
        };
    }
}
