using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float _startObjectSpeed;
    [SerializeField]
    private PlayerController _playerController;

    public static float ObjectsSpeed { get; private set; }

    private void Awake()
    {
        ObjectsSpeed = _startObjectSpeed;
    }

    private void Start()
    {
        _playerController.Died.Subscribe(StopObjects);
    }

    private void StopObjects()
    {
        ObjectsSpeed = 0;
    }
}
