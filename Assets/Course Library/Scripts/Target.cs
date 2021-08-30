using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;
    private float minForce = 12;
    private float maxForce = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -4;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //Set the object position is equal to a new spawn position which is a Vector 3 
        transform.position = RandomSpawnPos();
        
        // Assign the gameManager to the script in the Unity 
        // by finding the gameObject GameManager and gameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
        // Add upward force to the object, by mutiplying to a random range from 12, 16 
        // Each object will have different force apply on
        targetRb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        
        // Add force to rotate the object
        targetRb.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque());
        
        
        
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
     
        
        
        

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private float RandomForce()
    {
        return Random.Range(minForce, maxForce);
    }
    
    
    
}
