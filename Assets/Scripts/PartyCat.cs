using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyCat : MonoBehaviour
{
    public GameObject cat;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float speed;

    public float maxTime;

    float spawnTime;
    float currentTime;  

    float timeSinceSpawned;
    float endTime;

    Vector2 targetPosition;

    float reward;
    bool isActive = false;

    bool isRunningAway = false;
    bool facingRight = false;

    void Start() 
    {
        currentTime = 0;
        SetRandomTime(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned > endTime) {
                if (!isRunningAway) 
                {
                    targetPosition = new Vector2(1165, 1700);
                    isRunningAway = true;
                } else {
                    if ((Vector2)cat.transform.position != targetPosition) {
                        cat.transform.position = Vector2.MoveTowards(cat.transform.position, targetPosition, 800.0f * Time.deltaTime);
                        Flip(true);
                    } else {
                        DeSpawn();
                        isRunningAway = false;
                    }
                }
            } else {
                if ((Vector2)cat.transform.position != targetPosition) {
                    if (targetPosition.x - cat.transform.position.x > 0) {
                        Flip(true);
                    } else {
                        Flip(false);
                    }
                    Vector3 prevPosition = cat.transform.position;
                    cat.transform.position = Vector2.MoveTowards(cat.transform.position, targetPosition, speed * Time.deltaTime);
                    if (prevPosition == cat.transform.position) {
                        targetPosition = getRandomPosition();
                    }
                } else {
                    targetPosition = getRandomPosition();
                }
            }           
        } else {
            currentTime += Time.deltaTime;
            if (currentTime > spawnTime) {
                Spawn();
            }
        }
    }

    void DeSpawn()
    {
        isActive = false;
        cat.SetActive(false);
        currentTime = 0;
        SetRandomTime();
    }

    void Spawn() 
    {
        timeSinceSpawned = 0;
        currentTime = 0;
        SetRandomTime();
        endTime = Random.Range(0.0f, 10.0f) + 10.0f;
        reward = 25;
        cat.transform.position = getRandomPosition();
        cat.SetActive(true);
        isActive = true;
        targetPosition = getRandomPosition();
    }

    Vector2 getRandomPosition() 
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    void SetRandomTime()
    {
        spawnTime = (Random.Range(0.0f, maxTime));
    }

    public void Reward() 
    {
    DeSpawn();
    Debug.Log(reward);
    }

    void Flip(bool isFacingLeft)
    {
        if (facingRight && isFacingLeft) {
            cat.transform.RotateAround(cat.transform.position, cat.transform.up, 180f);
            facingRight = false;
        } else if (!facingRight && !isFacingLeft) {
            cat.transform.RotateAround(cat.transform.position, cat.transform.up, 180f);
            facingRight = true;
        }
    }
}
