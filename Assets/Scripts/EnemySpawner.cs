using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject sheep;
    [SerializeField] List<Transform> spawnPoint;
    [SerializeField] float waitTime = 10f;
    [SerializeField] int scoreCount;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] AudioClip spawnClip;
    //[SerializeField] AudioSource enemyAudio;
    
    int spawnIndex;
    bool isSpawing = false;
    bool isSpawingSheep = false;

    void Start()
    {
        isSpawingSheep = false;
        isSpawing = false;
        int.TryParse(scoreText.text, out scoreCount);
    }

    void Update()
    {
        if(isSpawing == false && PlayerHealth.isDead == false)
        {
            isSpawing = true;
            StartCoroutine(SpawnEnemy());
        }
        
    }

     IEnumerator SpawnEnemy()
    {
        int.TryParse(scoreText.text, out scoreCount);
        Debug.Log("Spawn");
        if(scoreCount%5 != 0 || isSpawingSheep == true || scoreCount == 0)
        {
            Debug.Log(scoreCount);
            spawnIndex = UnityEngine.Random.Range(0, 5);
            Instantiate(enemy, spawnPoint[spawnIndex].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            isSpawing = false;
            if(scoreCount%5 != 0)
            {
                isSpawingSheep = false;
            }
        }
        
        else if(scoreCount%5 == 0 && isSpawingSheep == false || scoreCount != 0)
        {
            Debug.Log("Sheep Spawned");
            spawnIndex = UnityEngine.Random.Range(0, 5);
            Instantiate(sheep, spawnPoint[spawnIndex].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            isSpawing = false;
            isSpawingSheep = true;
        }
    }

}
