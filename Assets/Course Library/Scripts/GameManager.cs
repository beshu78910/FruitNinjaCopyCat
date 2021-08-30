using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = " Score: " + score;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = " Score: " + score;
    }
   

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            
            // targets.Count return the total number of object in the list
            int index = Random.Range(0, targets.Count);
            
            // Instantiate take an object and return the clone of it, in this situation since we have 
            // already set the spawn position of the target in the Target.cs we don't have to give Instantiate the 
            // Vector3 position and rotation
            Instantiate(targets[index]);
        }
       
        
    }
    
}
