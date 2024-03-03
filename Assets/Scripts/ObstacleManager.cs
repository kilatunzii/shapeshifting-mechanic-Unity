using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform player;
    public float spawnDistance = 30f;
    public float spawnInterval = 3f;
    public float spawnHeight = -1.3f;
    public float effectDuration = 5f;

    private float nextSpawnTime;
    private Transform playerTransform;
    private ShapeShifter shapeShifterScript;
    
    void Start()
    {
        playerTransform = player.transform;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
       if (Time.time > nextSpawnTime)
        {
            spawnObstacles();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    public void spawnObstacles()
    {
        //Pick random prefabs from obstacle 0 to obstacle 3
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

        //Assigning a random spawn location of the x axis on either left or right
        float randomX = Random.Range(0, 2) == 0 ? -3f : 3f;

        //Assigning position for preefab to spawn on x,y,z
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, playerTransform.position.z + spawnDistance);

        //create new prefab on the assigned spawn location
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
      


        //destroy created prefab after a time duration
        Destroy(obstacle, effectDuration);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shape1") && shapeShifterScript.currentShapeIndex == 0)
        {
            // Handle collision with the second obstacle as a collectible and disable obstacle
            other.gameObject.SetActive(false);

        }
        else if (other.CompareTag("shape2") && shapeShifterScript.currentShapeIndex == 1)
        {
            // Handle collision with the second obstacle as a collectible and disable obstacle
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("shape3") && shapeShifterScript.currentShapeIndex == 2)
        {
            // Handle collision with the second obstacle as a collectible and disable obstacle
            other.gameObject.SetActive(false);
        }
        else
        {
            // Restart game
            SceneManager.LoadScene("level");

        }
    }

}