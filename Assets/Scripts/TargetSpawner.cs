using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] float timeBetweenSpawn = 5f;
    [SerializeField] float timer;
    [SerializeField] float spawntimeDecreaseAmount = 0.05f;
    [SerializeField] float minimumTimeBetweenSpawn = 0.5f;
    [SerializeField] float lifetime = 2f;

    [Header ("MinMax values")]
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    void Update()
    {
        HandleSpawning();
        IncreaseSpawnRate();
    }


    void HandleSpawning()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnTarget();
            timer = timeBetweenSpawn;
        }
    }

    void SpawnTarget()
    {
        GameObject spawnedTarget = Instantiate(targetObject, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 7.22f), Quaternion.identity);
        Destroy(spawnedTarget, lifetime);
    }

    void IncreaseSpawnRate()
    {
        timeBetweenSpawn -= spawntimeDecreaseAmount * Time.deltaTime;
        timeBetweenSpawn = Mathf.Clamp(timeBetweenSpawn, minimumTimeBetweenSpawn, 10f);
    }
}