using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTrigger : MonoBehaviour
{
  [SerializeField] GameObject spawner;

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Tile")
    {
      spawner.gameObject.GetComponent<SpawnManager>().ShouldSpawn = true;
    }
  }
}
