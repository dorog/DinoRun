using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private float _distanceModifier = 1;

    private void FixedUpdate()
    {
        transform.position = transform.position + _distanceModifier * TimeManager.ObjectsSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= MapManager.DeadlineForMovingObjects)
        {
            Destroy(gameObject);
        }
    }
}
