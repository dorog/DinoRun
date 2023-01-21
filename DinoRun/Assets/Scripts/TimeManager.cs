using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float _startObjectSpeed;

    public static float ObjectsSpeed { get; private set; }

    private void Awake()
    {
        ObjectsSpeed = _startObjectSpeed;
    }
}
