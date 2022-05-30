using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] public int maxHealth = 3;
  [SerializeField] Transform groundCheck;
  [SerializeField] LayerMask groundLayer;
  [SerializeField] AudioSource pain;
  [SerializeField] float characterSpeed = 1000f;
  [SerializeField] float jumpForce;

  public bool isPlaying = true;
  public int damage = 0;

  Rigidbody2D rb;
  Animator anim;
  SpriteRenderer spriteRenderer;
  Color originalColour;
  bool isGrounded;
  bool isRightMove;
  float checkRadius = 0.2f;

  void Start()
  {
    originalColour = GetComponent<Renderer>().material.color;
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    rb.velocity = new Vector2(
       Input.GetAxis("Horizontal") * characterSpeed * Time.deltaTime,
       rb.velocity.y
    );

    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff &&
    Input.GetButtonDown("Jump") && isGrounded)
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));

    spriteRenderer.flipX = rb.velocity.x > 0 ? true : false;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Damage" && damage < maxHealth)
    {
      StartCoroutine(Flashing());
      pain.Play();
      damage++;
      rb.velocity = Vector2.zero;

      if (damage >= maxHealth)
      {
        isPlaying = false;
      }
    }
  }

  public IEnumerator Flashing()
  {
    GetComponent<Renderer>().material.color = Color.black;
    yield return new WaitForSeconds(0.1f);
    GetComponent<Renderer>().material.color = originalColour;
    StopCoroutine("Flashing");
  }
}
