using UnityEngine;

public class MovingObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private float _minFrequency;
    [SerializeField]
    private float _maxFrequency;

    [SerializeField]
    private MovingObject[] _objects;

    private bool _isGameOver = false;

    private void Start()
    {
        transform.position = new Vector3(MapManager.StartLineForMovingObjects, transform.position.y, transform.position.z);

        _playerController.Died.Subscribe(StopGenerating);

        GenerateObject();
    }

    private void StopGenerating()
    {
        _isGameOver = true;
    }

    private void GenerateObject()
    {
        if (!_isGameOver)
        {
            int objectIndex = Random.Range(0, _objects.Length);

            Instantiate(_objects[objectIndex], transform);

            float nextTime = Random.Range(_minFrequency, _maxFrequency);

            Invoke(nameof(GenerateObject), nextTime);
        }
    }
}
