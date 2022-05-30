using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAttack : MonoBehaviour
{
  [SerializeField] GameObject bulletPrefab;
  [SerializeField] GameObject bulletPos;
  [SerializeField] ParticleSystem particle;
  [SerializeField] AudioSource attackSound;
  [SerializeField] float waitingTime = 2f;

  float currTime = 0f;
  bool shouldShot = true;

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      if (particle.gameObject.activeSelf == true && currTime <= waitingTime)
      {
        currTime += Time.deltaTime;
      }

      if (particle.gameObject.activeSelf == true && currTime >= waitingTime && shouldShot)
      {
        Attack();
      }

      if (particle.gameObject.activeSelf == false && currTime >= waitingTime)
      {
        shouldShot = true;
        currTime = 0f;
      }
    }
  }

  void Attack()
  {
    shouldShot = false;

    attackSound.Play();

    GameObject newBullet = Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.identity);
    newBullet.gameObject.SetActive(true);
  }
}
