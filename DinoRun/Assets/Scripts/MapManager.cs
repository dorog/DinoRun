using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private float _startLineBuffer;
    [SerializeField]
    private float _deadLineBuffer;

    public static float StartLineForMovingObjects { get; private set; }
    public static float DeadlineForMovingObjects { get; private set; }

    private void Awake()
    {
        StartLineForMovingObjects = Camera.main.transform.position.x + Camera.main.orthographicSize * 2 + _startLineBuffer;
        DeadlineForMovingObjects = Camera.main.transform.position.x - Camera.main.orthographicSize * 2 - _deadLineBuffer;
    }
}