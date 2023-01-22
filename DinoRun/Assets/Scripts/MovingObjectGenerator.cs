using UnityEngine;

public class MovingObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private MovingObjectsContainer _movingObjectsContainer;

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
            MovingObjectInfo movingObjectInfo = _movingObjectsContainer.GetRandomMovingObject();

            Instantiate(movingObjectInfo.MovingObject, transform);

            float nextTime = Random.Range(movingObjectInfo.MinFrequency, movingObjectInfo.MaxFrequency);

            Invoke(nameof(GenerateObject), nextTime);
        }
    }
}
