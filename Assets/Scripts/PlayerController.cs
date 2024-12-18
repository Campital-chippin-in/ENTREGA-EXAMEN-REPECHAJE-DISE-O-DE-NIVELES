using UnityEngine;

public class SimpleJumpController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public float glideGravityScale = 0.5f;  // Factor para reducir la gravedad mientras se planea

    private Rigidbody2D rb;
    private Animator animator;
    private FreezeAnimationOnJump freezeAnimationScript;
    private bool canJump = true;
    private float normalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        freezeAnimationScript = GetComponent<FreezeAnimationOnJump>();
        normalGravityScale = rb.gravityScale; // Guardar la escala de gravedad normal
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleGlide();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Actualizar la animación de caminar
        animator.SetFloat("Running", Mathf.Abs(moveInput));
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump) // Saltar al presionar la barra espaciadora
        {
            Jump();
        }
        animator.SetBool("isGrounded", canJump);
    }

    void HandleGlide()
    {
        if (!canJump && Input.GetKey(KeyCode.Space)) // Reducir la gravedad mientras se mantiene la barra espaciadora
        {
            rb.gravityScale = glideGravityScale;
        }
        else
        {
            rb.gravityScale = normalGravityScale;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        canJump = false; // Desactivar la opción de salto después de saltar
        animator.SetBool("isGrounded", canJump); // Actualizar la variable en el Animator

        // Congelar la animación en el frame 7 al saltar
        freezeAnimationScript.FreezeAnimation();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con el suelo
        if (collision.contacts.Length > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            if (normal.y > 0.5f) // Si la normal es suficientemente vertical, se considera el suelo
            {
                canJump = true;
                animator.SetBool("isGrounded", canJump); // Actualizar la variable en el Animator
                freezeAnimationScript.UnfreezeAnimation(); // Reanudar la animación al tocar el suelo
            }
        }
    }
}
