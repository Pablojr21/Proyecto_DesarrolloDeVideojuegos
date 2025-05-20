using UnityEngine;

public class caballero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public float fuarzaSalto;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float velocidadMovimiento = 5f;
    private bool enSuelo = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movimiento horizontal
        float movimiento = Input.GetAxisRaw("Horizontal");
        rigidbody2D.linearVelocity = new Vector2(movimiento * velocidadMovimiento, rigidbody2D.linearVelocity.y);


        // Actualiza el parámetro "velocidad" en el Animator
        animator.SetFloat("velocidad", Mathf.Abs(movimiento));  


        // Girar sprite segun direccion
        if (movimiento < 0)
        {
            spriteRenderer.flipX = true; // mirando a la izquierda
        }
        else if (movimiento > 0)
        {
            spriteRenderer.flipX = false; // mirando a la derecha
        }



        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            enSuelo = false; // Evita saltos dobles
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuarzaSalto), ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.J) && enSuelo)
        {
            animator.SetTrigger("atacar");
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            enSuelo = true;
            animator.SetBool("estaSaltando", false);
        }
    }
}
