using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
  [SerializeField] float speed = 2;

  GameObject player;
  Vector2 velocity;
  Vector2 direction;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    Destroy(gameObject, 4);
    DontDestroyOnLoad(gameObject);
    direction = (player.transform.position - transform.position).normalized;
  }

  void Update()
  {
    velocity = direction * speed;
  }

  private void FixedUpdate()
  {
    Vector2 pos = transform.position;
    pos += velocity * Time.fixedDeltaTime;
    transform.position = pos;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      Destroy(gameObject, 0.05f);
    }
  }
}
