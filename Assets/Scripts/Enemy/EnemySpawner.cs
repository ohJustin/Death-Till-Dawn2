using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float _minSpawnTime;

    [SerializeField]
    private float _maxSpawnTime;

    [SerializeField]

    private int killDifficultyCount = 1;

    private float _timeUntilSpawn;

    private float lastSpawnTime;

    private int difficulty;

    private GameManager gm;

    [SerializeField]
    private GameObject[] _enemyPrefabs;

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficulty = 1;
        SetTimeUntilSpawn(); //sets time until spawn when scene first loads.
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawnTime > _timeUntilSpawn){
            Instantiate(_enemyPrefabs[GetZombieType(difficulty)], transform.position, Quaternion.identity); //Using position of spawner to create enemy, for rotation we use Quaternion to specify rotation.
            SetTimeUntilSpawn(); //Set timer again after spawning enemy.
            SetDifficulty();
            lastSpawnTime = Time.time;
        }

    }


    private void SetTimeUntilSpawn(){
        _timeUntilSpawn = Random.Range(_minSpawnTime, _maxSpawnTime); //gets random spawn times to fix too much consistency.
    }

    private int GetZombieType(int diff) {
        return Random.Range(0, diff);
    }

    private void SetDifficulty() {
        if(difficulty >= 4) {
            difficulty = 4;
            return;
        }
        else {
            difficulty = (gm.ScoreCounter / killDifficultyCount) + 1;
        }
    }
}
