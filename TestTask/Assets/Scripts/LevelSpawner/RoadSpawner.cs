using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    List<Level> _levelBasics;
    [SerializeField]
    private ObstacleSpawner[] _road;
    private LevelDificulty _currentDificulty;
    private float
        _nextSpawnTriggerX,
        _groundLength = 50f,
        _spawnTriggerDistance = 25f;  
    private Vector2 _nextInstantiatePosition = Vector2.zero;
                

    void Awake()
    {
        _currentDificulty = LevelDificulty.AClass;
        Spawn();       
    }

    void Update()
    {
        if (GameController.Instance.Player.transform.position.x > _nextSpawnTriggerX)
        {
            Spawn();
            GameController.Instance.ObjectCleaner.DeleteObstacles();
            GameController.Instance.ObjectCleaner.DeleteTiles();           
        }
    }

    private void Spawn()
    {
        InstantiateNewLevel();
        CalculateNextSpawnPosition();
        ChangeDifficulty();

    }

    private void InstantiateNewLevel()
    {
  
            List<ObstacleSpawner> selectedLevels = new List<ObstacleSpawner>();
            foreach (ObstacleSpawner lvl in _road)
            {
                if (lvl.Dificulty == _currentDificulty)
                    selectedLevels.Add(lvl);
            }
            int number = Random.Range(0, _road.Length);
            GameObject level = Instantiate(selectedLevels[Random.Range(0, number)].gameObject, _nextInstantiatePosition, Quaternion.identity);
            GameController.Instance.ObjectCleaner._activeTiles.Add(level);
    }

    private void CalculateNextSpawnPosition()
    {
        _nextInstantiatePosition += Vector2.right * _groundLength;
        _nextSpawnTriggerX = _nextInstantiatePosition.x - _spawnTriggerDistance;
    }

    private void ChangeDifficulty()
    {
        switch (_currentDificulty)
        {
            case LevelDificulty.AClass:
                _currentDificulty = LevelDificulty.BClass;
                break;

            case LevelDificulty.BClass:
                _currentDificulty = LevelDificulty.CClass;
                break;

            case LevelDificulty.CClass:
                _currentDificulty = LevelDificulty.BClass;
                break;
        }
    }
}
