using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
  [SerializeField] ParticleSystem particle;
  [SerializeField] public float castingTime = 2f;
  [SerializeField] public float beforeCastingTime = 0.5f;
  [SerializeField] float attackTime = 2f;
  [SerializeField] float biggerScale;

  public bool IsCasting { get; set; }

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff &&
    IsCasting)
    {
      StartCoroutine(Casting());
    }
  }

  IEnumerator Casting()
  {
    IsCasting = false;
    if (gameObject.transform.position.x < 0)
    {
      transform.Rotate(0f, 180f, 0f);
    }

    yield return new WaitForSeconds(beforeCastingTime);

    gameObject.GetComponent<Animator>().SetBool("isCasting", true);

    particle.gameObject.SetActive(true);
    particle.Play();

    yield return new WaitForSeconds(castingTime);

    particle.gameObject.transform.localScale = particle.gameObject.transform.localScale * biggerScale;

    yield return new WaitForSeconds(attackTime);

    gameObject.GetComponent<Animator>().SetBool("isCasting", false);
    gameObject.GetComponent<FadeScript>().SetFadeOut(true);
    particle.Stop();
    particle.gameObject.SetActive(false);
    particle.gameObject.transform.localScale = Vector3.one;

    yield return new WaitForSeconds(0.75f);

    gameObject.SetActive(false);
    transform.rotation = Quaternion.identity;

    StopCoroutine("Casting");
  }
}
