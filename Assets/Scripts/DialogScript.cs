using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
  [SerializeField] GameObject dialogPanel;
  [SerializeField] TMP_Text dialogText;
  [SerializeField] float typingTime = 0.05f;
  [SerializeField] float resumeTimeDivisor = 17f;
  [SerializeField, TextArea(4, 6)] string[] dialogLines;

  bool isPlayerClose;
  bool didDialogStart;
  bool shouldNextLine;
  int lineIndex;

  void Update()
  {
    if (didDialogStart && Input.GetKeyDown(KeyCode.W))
    {
      didDialogStart = true;
      StopAllCoroutines();
      dialogPanel.SetActive(false);
      Time.timeScale = 1f;
      gameObject.SetActive(false);
    }

    if (isPlayerClose)
    {
      if (!didDialogStart)
      {
        StartDialog();
      }
      else if (dialogText.text == dialogLines[lineIndex] && shouldNextLine)
      {
        NextDialogLine();
      }
      else if (Input.GetKeyDown(KeyCode.Space))
      {
        StopAllCoroutines();
        dialogText.text = dialogLines[lineIndex];

        StartCoroutine(ResumeDialog());
      }
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      isPlayerClose = true;
    }
  }

  void StartDialog()
  {
    didDialogStart = true;
    dialogPanel.SetActive(true);
    lineIndex = 0;
    Time.timeScale = 0f;

    StartCoroutine(ShowDialog());
  }

  void NextDialogLine()
  {
    lineIndex++;

    if (lineIndex < dialogLines.Length)
    {
      StartCoroutine(ShowDialog());
    }
    else
    {
      didDialogStart = false;
      dialogPanel.SetActive(false);
      Time.timeScale = 1f;
      gameObject.SetActive(false);
    }
  }

  IEnumerator ShowDialog()
  {
    shouldNextLine = false;
    dialogText.text = string.Empty;

    foreach (char ch in dialogLines[lineIndex])
    {
      dialogText.text += ch;
      yield return new WaitForSecondsRealtime(typingTime);
    }

    yield return new WaitForSecondsRealtime(dialogLines[lineIndex].Length / resumeTimeDivisor);
    shouldNextLine = true;
  }

  IEnumerator ResumeDialog()
  {
    yield return new WaitForSecondsRealtime(dialogLines[lineIndex].Length / resumeTimeDivisor);
    shouldNextLine = true;
  }
}
