using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleAttack : MonoBehaviour
{
  [SerializeField] GameObject jabalinePrefab;
  [SerializeField] ParticleSystem particle;
  [SerializeField] AudioSource attackSound;
  [SerializeField] float waitingTime = 2f;
  [SerializeField] float yPosition = 8f;

  GameObject player;
  float xPosition;
  float currTime = 0f;
  bool shouldShot = true;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      xPosition = player.gameObject.transform.position.x;

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

    GameObject newJabaline = Instantiate(
        jabalinePrefab,
        new Vector2(xPosition, yPosition),
        Quaternion.identity
    );
    newJabaline.gameObject.SetActive(true);
  }
}
