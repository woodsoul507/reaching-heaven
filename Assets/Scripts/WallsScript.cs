using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour
{
  void Start()
  {
    Physics2D.IgnoreLayerCollision(7, 8, true);
  }
}
