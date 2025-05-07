using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]private SpriteRenderer _spriteRenderer;
    Animator _animator;

    private Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; }}

    private float speed = 3f;



    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleAction();
        Rotate(movementDirection);
    }

    private void FixedUpdate()
    {
        Movement(movementDirection);
    }
    private void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }
    private void Movement(Vector2 direction)
    {
        direction = direction * speed;
        _rigidbody.velocity = direction;
        if(direction.x != 0f)
        {
            _animator.SetBool("IsMove", true);
        }
        else if (direction.y != 0f)
        {
            _animator.SetBool("IsMove", true);
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }
    }
    private void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;

        _spriteRenderer.flipX = isLeft;

    }

}
