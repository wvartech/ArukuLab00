using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 center;
    private float spawnRadius = 5f;
    public GameObject shooterPrefab;
    public GameObject possessorPrefab;
    public GameObject chaserPrefab;

    private float interval = 2f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = interval;
            spawnEnemy(center, possessorPrefab);
        }        
    }

    public void spawnEnemy(Vector3 location, GameObject prefab) {
        Vector3 rng = Random.insideUnitCircle.normalized * spawnRadius;
        GameObject.Instantiate(prefab, location + rng, Quaternion.identity);
    }

}
