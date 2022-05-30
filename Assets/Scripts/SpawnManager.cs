using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] GameObject player;
  [SerializeField] List<GameObject> enemies;
  [SerializeField] float firstEnemyTime = 3f;
  [SerializeField] float intervalEnemyTime = 2f;
  [SerializeField] List<GameObject> platforms;
  [SerializeField] List<float> rows;
  [SerializeField] float[] spawnDistanceX;
  [SerializeField] int backupPlatforms = 3;
  [SerializeField] float enemiesRow = 2.6f;

  System.Random rng = new System.Random();

  public bool ShouldSpawn { get; set; }

  Queue<float> rowsQueue = new Queue<float>();
  List<GameObject> inactivePlatforms = new List<GameObject>();
  int lastColumn;

  void Start()
  {
    ShouldSpawn = false;
    platforms = platforms.OrderBy(a => rng.Next()).ToList();
    rowsQueue = new Queue<float>(rows);

    for (int i = 0; i < platforms.Count - backupPlatforms; i++)
    {
      int randomX = Random.Range(1, 4);
      while (randomX == lastColumn)
      {
        randomX = Random.Range(1, 4);
      }
      lastColumn = randomX;
      GameObject currPlatform = platforms[i];
      float posY = rowsQueue.Dequeue();
      float posX = randomX == 2 ? 0
                                : (randomX == 1 ? spawnDistanceX[Random.Range(0, 1)] * -1
                                                : spawnDistanceX[Random.Range(0, 1)]);
      currPlatform.transform.position = new Vector2(posX, posY);
      currPlatform.gameObject.SetActive(true);
      rowsQueue.Enqueue(posY);
    }

    InvokeRepeating("SpawnEnemy", firstEnemyTime, intervalEnemyTime);
  }

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff &&
    ShouldSpawn)
    {
      SpawnNextPlatform();
    }
  }

  void SpawnNextPlatform()
  {
    ShouldSpawn = false;
    inactivePlatforms = platforms.FindAll(p => p.gameObject.activeSelf == false);

    if (inactivePlatforms.Count > 0)
    {
      inactivePlatforms.OrderBy(a => rng.Next()).ToList();
      int randomX = Random.Range(1, 4);
      while (randomX == lastColumn)
      {
        randomX = Random.Range(1, 4);
      }
      lastColumn = randomX;

      float posY = rows[rows.Count - 1];
      float posX = randomX == 2 ? 0
                                : (randomX == 1 ? spawnDistanceX[Random.Range(0, 1)] * -1
                                                : spawnDistanceX[Random.Range(0, 1)]);
      GameObject topPlatform = inactivePlatforms[Random.Range(0, inactivePlatforms.Count - 1)];
      topPlatform.gameObject.transform.position = new Vector2(posX, posY);
      topPlatform.gameObject.SetActive(true);
    }
  }

  void SpawnEnemy()
  {
    if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDialogOff)
    {
      List<GameObject> inactiveEnemies = enemies.FindAll(e => e.gameObject.activeSelf == false);

      if (inactiveEnemies.Count > 0)
      {
        GameObject currEnemy = inactiveEnemies[Random.Range(0, inactiveEnemies.Count)];
        currEnemy.transform.position = new Vector2(
          Random.Range(0, 2) == 0 ? enemiesRow : enemiesRow * -1,
          player.gameObject.transform.position.y
        );

        Color objectColor = currEnemy.gameObject.GetComponent<Renderer>().material.color;
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 0f);
        currEnemy.gameObject.GetComponent<Renderer>().material.color = objectColor;

        currEnemy.gameObject.SetActive(true);
        currEnemy.gameObject.GetComponent<FadeScript>().SetFadeIn(true);
        currEnemy.gameObject.GetComponent<EnemyScript>().IsCasting = true;
      }
    }
  }
}
