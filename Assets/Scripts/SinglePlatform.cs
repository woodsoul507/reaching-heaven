using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlatform : MonoBehaviour
{
  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      GetComponent<Rigidbody2D>().gravityScale = 0.2f;
    }
  }
}
