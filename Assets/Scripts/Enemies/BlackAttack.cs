using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAttack : MonoBehaviour
{
  [SerializeField] GameObject laser;
  [SerializeField] ParticleSystem particle;
  [SerializeField] AudioSource attackSound;
  [SerializeField] float speed = 10f;
  [SerializeField] float waitingTime = 2f;

  float currTime = 0f;

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      if (particle.gameObject.activeSelf == true && currTime <= waitingTime)
      {
        currTime += Time.deltaTime;
      }

      if (particle.gameObject.activeSelf == false)
      {
        laser.gameObject.SetActive(false);
        laser.gameObject.transform.localScale = new Vector2(
          0.5f,
          laser.gameObject.transform.localScale.y
        );
      }

      if (particle.gameObject.activeSelf == true && currTime >= waitingTime)
      {
        Attack();
      }

      if (particle.gameObject.activeSelf == false && currTime >= waitingTime)
      {
        currTime = 0f;
      }
    }
  }

  void Attack()
  {
    attackSound.Play();

    laser.gameObject.SetActive(true);
    laser.gameObject.transform.localScale = new Vector2(
      laser.gameObject.transform.localScale.x + (speed * Time.deltaTime),
      laser.gameObject.transform.localScale.y
    );

  }
}
