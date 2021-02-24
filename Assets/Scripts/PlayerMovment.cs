using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLM;
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2D;
    public GameObject thePrefab;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    public Vector2 speed = new Vector2(10, 10);
    float runSpeed = 20;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = transform.position;
            pos.x += 1f;
            var instance = Instantiate(thePrefab, pos, transform.rotation);
        }
        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space)))
        {
            float jumpVelocity = 15f;
            rb2d.velocity = Vector2.up * jumpVelocity;
        }
        HandleMouvement();
    }
    private bool IsGrounded()
    {
        RaycastHit2D rch2D = Physics2D.BoxCast(bc2D.bounds.center, bc2D.bounds.size, 0f, Vector2.down, 1 / 10f, platformsLM);
        Debug.Log(rch2D.collider);
        return rch2D.collider != null;
    }
    private void HandleMouvement()
    {

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.SetFloat("PlayerSpeed", runSpeed);
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(+runSpeed, rb2d.velocity.y);
            animator.SetFloat("PlayerSpeed", runSpeed);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetFloat("PlayerSpeed", 0);
        }
    }
}