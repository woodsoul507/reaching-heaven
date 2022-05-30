using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
  [SerializeField] float fadeSpeed = 5.0f;

  bool IsFadeIn;
  bool IsFadeOut;

  void Start()
  {
  }

  void Update()
  {
    if (IsFadeIn)
    {
      FadeIn();
    }

    if (IsFadeOut)
    {
      FadeOut();
    }
  }

  public void SetFadeIn(bool status)
  {
    IsFadeIn = status;
  }

  public void SetFadeOut(bool status)
  {
    IsFadeOut = status;
  }

  void FadeOut()
  {
    Color objectColor = GetComponent<Renderer>().material.color;
    float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

    objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    GetComponent<Renderer>().material.color = objectColor;

    if (objectColor.a <= 0)
    {
      IsFadeOut = false;
    }
  }

  void FadeIn()
  {
    Color objectColor = GetComponent<Renderer>().material.color;
    float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

    objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    GetComponent<Renderer>().material.color = objectColor;

    if (objectColor.a >= 1)
    {
      IsFadeIn = false;
    }
  }
}
