using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField]
    private Rigidbody2D _rigidbody2d;
    [SerializeField]
    private float _maxChargingSeconds;
    [SerializeField]
    private float _chargingJumpForce;
    [SerializeField]
    private float _baseJumpForce;

    [Header("Land")]
    [SerializeField]
    private BoxCollider2D _groundBoxCollider;
    [SerializeField]
    private float _minDistanceFromGround;
    [SerializeField]
    private float _minVelocityBeforeLanding;

    private bool isJumped;
    private float charger;

    private bool isInAir = false;
    private bool _isAlive = true;

    private float _groundY;

    public GameEvent Jumped { get; } = new();
    public GameEvent Landed { get; } = new();
    public GameEvent Died { get; } = new();

    private void Awake()
    {
        _groundY = _groundBoxCollider.transform.position.y + _groundBoxCollider.offset.y + (_groundBoxCollider.size.y / 2);
    }

    private void Update()
    {
        if (_isAlive)
        {
            Charge();

            Jump();
        }

        Land();
    }

    private void Charge()
    {
        if (IsCharging() && _maxChargingSeconds > charger)
        {
            charger += Time.deltaTime;
            if (charger > _maxChargingSeconds)
            {
                charger = _maxChargingSeconds;
            }
        }
    }

    protected abstract bool IsCharging();

    private void Jump()
    {
        if (IsJumped() && !isInAir)
        {
            isJumped = true;
        }
    }

    protected abstract bool IsJumped();

    private void Land()
    {
        if (isInAir && Mathf.Abs(_rigidbody2d.velocity.y) < _minVelocityBeforeLanding && Mathf.Abs(transform.position.y - _groundY) <= _minDistanceFromGround)
        {
            isInAir = false;

            Landed.Call();
        }
    }

    private void FixedUpdate()
    {
        if (isJumped)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _baseJumpForce + _chargingJumpForce * charger);

            Jumped.Call();

            isInAir = true;
            isJumped = false;
            charger = 0f;
        }
    }

    public void GotHit()
    {
        Died.Call();
        _isAlive = false;
    }
}
