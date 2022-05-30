using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
  [SerializeField] float delayMoveTime = 2f;
  [SerializeField] float speed = 0.01f;
  [SerializeField] float desirePosition = -5.5f;

  float currTime = 0;

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      if (currTime < delayMoveTime)
      {
        currTime += Time.deltaTime;
      }

      if (currTime >= delayMoveTime && gameObject.transform.position.y < desirePosition)
      {
        gameObject.transform.position = new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y + speed
        );
      }
    }
  }
}
