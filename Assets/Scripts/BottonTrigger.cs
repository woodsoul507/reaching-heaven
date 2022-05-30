using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonTrigger : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Tile")
    {
      other.gameObject.SetActive(false);
    }
  }
}
