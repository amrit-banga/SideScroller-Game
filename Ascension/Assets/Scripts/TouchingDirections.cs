using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    //public bool IsGrounded { get; private set; }

    CapsuleCollider2D touchingCol;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    private bool _isGrounded;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            if (_isGrounded != value)
            {
                _isGrounded = value;
                // You can trigger an event here if needed
            }
        }
    }


    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
