using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyCat : MonoBehaviour
{
    //stores cat object
    //this can be changed to reference the cat via inheritance (assign the script to the cat instead of game control)
    public GameObject cat;

    //storing the size of the canvas
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //easy change of speed for testing
    //this should be changed to a private static variable when in production
    public float speed;

    //easy change of max time between spawns for testing
    //this should be changed to a private static variable when in production
    public float maxTime;

    //tracks the amount of time the cat hasn't spawned for
    float spawnTime;
    float currentTime;  

    //enables the cat to appear on screen for a random time
    float timeSinceSpawned;
    float endTime;

    //stores the position the cat is moving towards
    Vector2 targetPosition;

    //stores the reward the user gets upon clicking the cat
    float reward;
    bool isActive = false;

    //boolean to track the state of the cat
    bool isRunningAway = false;
    bool facingRight = false;

    //when the game opens the time is set to 0
    void Start() 
    {
        currentTime = 0;
        SetRandomTime(); 
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the cat is moving
        if (isActive) {
            //move cat towards a random position on the screen 
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned > endTime) {
                //if the cat isn't running away move the cat towards the random position
                //otherwise move towards the exit point
                if (!isRunningAway) 
                {
                    //this can be randomised later
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
                //moves cat towards position
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
        } else { //increments time if cat hasn't spawned yet
            currentTime += Time.deltaTime;
            if (currentTime > spawnTime) {
                Spawn();
            }
        }
    }

    //despawns the cat once it is off screen
    void DeSpawn()
    {
        isActive = false;
        cat.SetActive(false);
        currentTime = 0;
        SetRandomTime();
    }

    //spawns the cat once the time is right
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

    //returns a random position on screen
    Vector2 getRandomPosition() 
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    //sets a random time 
    void SetRandomTime()
    {
        spawnTime = (Random.Range(0.0f, maxTime));
    }

    //applies the reward to the user
    public void Reward() 
    {
        DeSpawn();
        Debug.Log(reward);
    }

    //flips the cat so it is pointing the direction it is running
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
