using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlatformScript : MonoBehaviour
{
  [SerializeField] float speed = -0.01f;
  [SerializeField] float desirePosition = -10f;

  bool shouldMove = false;

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      if (shouldMove)
      {
        gameObject.transform.position = new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y + speed
        );
      }

      if (gameObject.transform.position.y < desirePosition)
      {
        gameObject.SetActive(false);
      }
    }
  }

  void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      shouldMove = true;
    }
  }
}
