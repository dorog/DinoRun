using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = transform.position + TimeManager.ObjectsSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= MapManager.DeadlineForMovingObjects)
        {
            Destroy(gameObject);
        }
    }
}
