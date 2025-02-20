using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private SpriteRenderer ridingRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {
        if (GameManager.Instance.isRiding == true)
        {
            OnRide();
        }
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        if (Input.GetKeyDown("f"))
        {
            Riding();
        }
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);

    }

    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {
        if(GameManager.Instance.isRiding == true)
        {
            direction = direction * 10;
            _rigidbody.velocity = direction;
        }
        else
        {
            direction = direction * 5;
            _rigidbody.velocity = direction;
        }
        
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
        ridingRenderer.flipX = isLeft;

    }

    private void Riding()
    {
        if (GameManager.Instance.isRiding == false)
        {
            OnRide();
        }
        else
        {
            offRide();
        }
    }

    private void OnRide()
    {
        ridingRenderer.gameObject.SetActive(true);
        animationHandler.Riding(true);
        GameManager.Instance.isRiding = true;
    }
    private void offRide()
    {
        ridingRenderer.gameObject.SetActive(false);
        animationHandler.Riding(false);
        GameManager.Instance.isRiding = false;
    }
}
