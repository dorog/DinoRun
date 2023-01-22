using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private DependencyContainer _dependencyContainer;

    private GameObject _currentGameInstance;

    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        if (_currentGameInstance != null)
        {
            Destroy(_currentGameInstance);
        }

        CreateGameInstance();
    }

    private void CreateGameInstance()
    {
        DependencyContainer dependencyContainer = Instantiate(_dependencyContainer);

        dependencyContainer.StateManager = this;
        dependencyContainer.Initialized();

        _currentGameInstance = dependencyContainer.gameObject;
    }
}
