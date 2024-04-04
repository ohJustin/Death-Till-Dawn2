using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float _minSpawnTime;

    [SerializeField]
    private float _maxSpawnTime;

    private float _timeUntilSpawn;

    [SerializeField]
    public GameObject[] enemyPreFabs; // Array of enemy prefabs to spawn.
    // public float spawnInterval = 3f; //Time between spawns.
    // public float timer = 0f;


    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn(); //sets time until spawn when scene first loads.
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        _timeUntilSpawn -= Time.deltaTime; // Once this value reaches zero - we spawn an enemy

        if(_timeUntilSpawn <= 0){
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity); //Using position of spawner to create enemy, for rotation we use Quaternion to specify rotation.
            SetTimeUntilSpawn(); //Set timer again after spawning enemy.
        }

    }

    void Spawn(GameObject prefabToSpawn){
        //Spawn chosen zombie prefab.
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }


    private void SetTimeUntilSpawn(){
        _timeUntilSpawn = Random.Range(_minSpawnTime, _maxSpawnTime); //gets random spawn times to fix too much consistency.

    }
}
