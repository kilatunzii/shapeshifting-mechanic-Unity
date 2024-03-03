using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnLocation = -35f;
    public float spawnDistance = 30f;

    public Transform player;
    private Transform playerTransform;
    public int spawnedPlatforms = 5;
    public int spawnedPlatformsAtStart = 2;

    //create a Queue of platforms in order to run a FIFO
    private Queue<GameObject> platforms = new Queue<GameObject>();

    
    void Start()
    {
        for (int i = 0; i < spawnedPlatformsAtStart; i++)
        {
            spawnPlatform();
        }
        
        playerTransform = player.transform;

    }

   
    void Update()
    {
        if (playerTransform.position.z - spawnLocation >= spawnDistance)
        {
            spawnPlatform();
            DeletePlatform();
        }
            
       
    }
    //Code to spawn new platform
    private void spawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab, new Vector3(0, 0, spawnLocation + spawnDistance), Quaternion.identity);
        platforms.Enqueue(platform);
        spawnLocation += spawnDistance;
    }

    //Code to destroy old platform
    private void DeletePlatform()
    {
        if (platforms.Count >= spawnedPlatforms)
        {
            GameObject platform = platforms.Dequeue();
            Destroy(platform);
        }
       
    }
}
