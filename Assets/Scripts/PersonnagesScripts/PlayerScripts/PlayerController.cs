using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLM;
    [SerializeField] private LayerMask thongsLM;
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

    private void LateUpdate()
    {
        if (IsOnTheThongs() != null)
        {
            GridScript gs = IsOnTheThongs().gameObject.GetComponent<GridScript>();
            HealthScript hs = gameObject.GetComponent<HealthScript>();
            hs.getDamage(gs.damage);
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D rch2D = Physics2D.BoxCast(bc2D.bounds.center, bc2D.bounds.size, 0f, Vector2.down, 1 / 10f, platformsLM);
        return rch2D.collider != null;
    }
    public Collider2D IsOnTheThongs()
    {
        RaycastHit2D rch2D = Physics2D.BoxCast(bc2D.bounds.center, bc2D.bounds.size, 0f, Vector2.down, 1 / 10f, thongsLM);
        return rch2D.collider;
    }

    private void HandleMouvement()
    {

        if (Input.GetKey(KeyCode.A))
        {
<<<<<<< HEAD:Assets/Scripts/PersonnagesScripts/PlayerScripts/PlayerController.cs
            rb2d.velocity = new Vector2(-speed.x, rb2d.velocity.y);
          //  animator.SetFloat("PlayerSpeed", runSpeed);
=======
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.SetFloat("PlayerSpeed", runSpeed);
>>>>>>> parent of 46117d8 (Enemy_Scripts):Assets/Scripts/PlayerController.cs
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
<<<<<<< HEAD:Assets/Scripts/PersonnagesScripts/PlayerScripts/PlayerController.cs
            rb2d.velocity = new Vector2(+speed.x, rb2d.velocity.y);
           // animator.SetFloat("PlayerSpeed", runSpeed);
=======
            rb2d.velocity = new Vector2(+runSpeed, rb2d.velocity.y);
            animator.SetFloat("PlayerSpeed", runSpeed);
>>>>>>> parent of 46117d8 (Enemy_Scripts):Assets/Scripts/PlayerController.cs
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
<<<<<<< HEAD:Assets/Scripts/PersonnagesScripts/PlayerScripts/PlayerController.cs
          //  animator.SetFloat("PlayerSpeed", 0);
=======
            animator.SetFloat("PlayerSpeed", 0);
>>>>>>> parent of 46117d8 (Enemy_Scripts):Assets/Scripts/PlayerController.cs
        }
    }
}