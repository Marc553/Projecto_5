using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    
    public GameObject[] targetPrefabs;
    public bool isGameOver;
    public List<Vector3> targetPositions;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    public TextMeshProUGUI pointsText;
    public GameObject gameOverPanel;


    private float spawnRate = 2f;
    private Vector3 randomPos;

    private int score = 0;

    void Start()
    {
        pointsText.text = $"Score: {score}";
        gameOverPanel.SetActive(false);

        StartCoroutine(SpawnRandomTarget());
    }

    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltoX = Random.Range(0, 4);
        int SaltoY = Random.Range(0, 4);

        float spawnPosX = minX + SaltoX * distanceBetweenSquares;
        float spawnPosY = minY + SaltoY * distanceBetweenSquares;

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();
            while(targetPositions.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomPos);

        }
         
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        pointsText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

}
