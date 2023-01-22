using UnityEngine;

public class DependencyContainer : MonoBehaviour
{
    public StateManager StateManager { get; set; }

    [SerializeField]
    private GameObject _map;

    public void Initialized()
    {
        _map.SetActive(true);
    }
}
