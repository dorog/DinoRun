using UnityEngine;

public class KeyboardPlayerController : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField]
    private Rigidbody2D _rigidbody2d;
    [SerializeField]
    private float _maxChargingSeconds;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private string _jumpAnimationTriggerName;

    [Header("Land")]
    [SerializeField]
    private BoxCollider2D _groundBoxCollider;
    [SerializeField]
    private float _minDistanceFromGround;
    [SerializeField]
    private float _minVelocityBeforeLanding;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _landAnimationTriggerName;

    [Header("Sound")]
    [SerializeField]
    private SoundManager _soundManager;

    private bool isJumped;
    private float charger;

    private bool isInAir = false;

    private float _groundY;

    private void Awake()
    {
        _groundY = _groundBoxCollider.transform.position.y + _groundBoxCollider.offset.y + (_groundBoxCollider.size.y / 2);
    }

    private void Update()
    {
        Charge();

        Jump();

        Land();
    }

    private void Charge()
    {
        if (Input.GetKey(KeyCode.Space) && _maxChargingSeconds > charger)
        {
            charger += Time.deltaTime;
            if (charger > _maxChargingSeconds)
            {
                charger = _maxChargingSeconds;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isInAir)
        {
            isJumped = true;
        }
    }

    private void Land()
    {
        if (isInAir && Mathf.Abs(_rigidbody2d.velocity.y) < _minVelocityBeforeLanding && Mathf.Abs(transform.position.y - _groundY) <= _minDistanceFromGround)
        {
            isInAir = false;
            _animator.SetTrigger(_landAnimationTriggerName);
            _soundManager.PlayLandedClip();
        }
    }

    private void FixedUpdate()
    {
        if (isJumped)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce * charger);
            _animator.SetTrigger(_jumpAnimationTriggerName);
            _soundManager.PlayJumpedClip();

            isInAir = true;
            isJumped = false;
            charger = 0f;
        }
    }
}
