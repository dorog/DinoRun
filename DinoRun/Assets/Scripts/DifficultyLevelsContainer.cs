public class DifficultyLevelsContainer<Level>
{
    private readonly Level[] _levels;
    private int _currentLevel = 0;

    public DifficultyLevelsContainer(Level[] levels)
    {
        _levels = levels;
    }

    public Level RaiseDifficulty()
    {
        if (_levels.Length - 1 > _currentLevel)
        {
            _currentLevel++;
        }

        return GetCurrentLevel();
    }

    public Level GetCurrentLevel()
    {
        return _levels[_currentLevel];
    }
}