using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
  public void ExitButton()
  {
    Application.Quit();
  }

  public void StartButton()
  {
    SceneManager.LoadScene("Level1");
  }
}
