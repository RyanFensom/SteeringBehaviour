using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;

    private float spawnTimer = 0f;
    public List<GameObject> objects = new List<GameObject>();

    void OnDrawGizmos()
    {
        // Draw a cube to indicate where the box is that we're
        // spawning objects
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    // Generates a random point within the transform's scale
    Vector3 GenerateRandomPoint()
    {
        // SET halfScale to half of the transform's scale
        Vector3 halfScale = transform.localScale * 0.5f;
        // SET randomPoint vector to zero
        Vector3 randomPoint = Vector3.zero;
        // SET randomPoint x, y and z to random range between
        // -halfScale to halfScale (HINT: can do individually)
        randomPoint = new Vector3(RandPos(halfScale.x), RandPos(halfScale.y), RandPos(halfScale.z));
        // RETURN randomPoint;
        return randomPoint;
    }

    // Used to generate random floats between a double value range
    float RandPos(float range)
    {
        float pos = 0f;
        pos = Random.Range(-range, range);
        return pos;
    }


    // Spawns the prefab at a given position and with rotation
    public void Spawn(Vector3 pos, Quaternion rot)
    {
        // SET clone to new instance of prefab
        GameObject clone = Instantiate(prefab);
        // ADD a clone to objects list
        objects.Add(clone);
        // SET clone's position to spawner position + pos
        clone.transform.position = transform.position + pos;
        // SET clone's rotation to rot
        clone.transform.rotation = rot;
    }

    // Update is called once per frame
    void Update()
    {
        // SET spawnTimer to spawnTimer + deltatime
        spawnTimer += Time.deltaTime;
        // IF spawnTimer > spawnRate
        if (spawnTimer > spawnRate)
        {
            // SET randomPoint to GenerateRandomPOint()
            Vector3 randomPoint = GenerateRandomPoint();
            // CALL spawn() and pass randomPoint, Quaternion identity
            Spawn(randomPoint, Quaternion.identity);
            // SET spawnTimer to zero
            spawnTimer = 0;
        }
        
    }



}
