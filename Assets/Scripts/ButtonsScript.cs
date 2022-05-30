using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
  public void ExitButton()
  {
    SceneManager.LoadScene("StartScreen");
  }

  public void RetryButton()
  {
    SceneManager.LoadScene("Level1");
  }
}
