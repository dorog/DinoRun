using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private DependencyContainer _dependencyContainer;
    [SerializeField]
    private GameObject _gameOverUI;

    private StateManager _stateManager;

    void Start()
    {
        _stateManager = _dependencyContainer.StateManager;
        _playerController.Died.Subscribe(ShowGameOverUI);
    }

    private void ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        _stateManager.StartGame();
    }
}
