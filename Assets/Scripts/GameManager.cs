using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  [SerializeField] GameObject player;
  [SerializeField] GameObject npc;
  [SerializeField] GameObject gameOver;
  [SerializeField] TMP_Text healthText;
  [SerializeField] float deadPosition = -3f;

  public bool isDialogOff = false;

  int currHealth = 0;

  void Awake()
  {
    Application.targetFrameRate = 60;
  }

  void Start()
  {
    Time.timeScale = 1;
  }

  void Update()
  {
    currHealth = player.GetComponent<PlayerController>().maxHealth - player.GetComponent<PlayerController>().damage;
    healthText.text = $"Health {currHealth}/{player.GetComponent<PlayerController>().maxHealth}";
    if (!npc.gameObject.activeSelf)
    {
      isDialogOff = true;
    }

    if (player.gameObject.transform.position.y < deadPosition ||
        player.gameObject.GetComponent<PlayerController>().isPlaying == false)
    {
      gameOver.gameObject.SetActive(true);
      Time.timeScale = 0;
    }
  }
}
