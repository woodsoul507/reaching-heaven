using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavalineScript : MonoBehaviour
{
  [SerializeField] float speed = 2;
  [SerializeField] float javalineLifeTime = 6f;

  Vector2 velocity;

  void Start()
  {
    Destroy(gameObject, javalineLifeTime);
    DontDestroyOnLoad(gameObject);
  }

  void Update()
  {
    velocity = Vector2.down * speed;
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
