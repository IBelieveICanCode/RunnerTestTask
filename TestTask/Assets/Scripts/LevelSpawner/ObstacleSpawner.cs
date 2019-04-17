using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner: Level
{
    [SerializeField]
    private GameObject _floor;
    [SerializeField]
    private GameObject _obstacle;
    public float 
        MinDistanceBetweenObstacles = 6f,
        MaxDistanceBetweenObstacles = 10f;
    public int
        MinObstacles = 4,
        MaxObstacles = 8;
    private Vector3 _positionToSpawn = Vector3.zero;
    private int _amountObstacle;
    private float _floorLength;

    public void SpawnObstacle()
    {       
        _amountObstacle = Random.Range(MinObstacles, MaxObstacles);        
        for (int i = 0; i <= _amountObstacle; i++)
        {
            _positionToSpawn.x += Random.Range(MinDistanceBetweenObstacles, MaxDistanceBetweenObstacles);
            if (_positionToSpawn.x < _floorLength && _obstacle != null)
            {
                GameObject obstacle = Instantiate(_obstacle, transform.position + _positionToSpawn,
                    Quaternion.identity);
                GameController.Instance.ObjectCleaner._activeObstacle.Add(obstacle);
            }
        }
        _positionToSpawn = Vector3.zero;
    }
    
    void Start()
    {
        _floorLength = _floor.transform.localScale.x;
        SpawnObstacle();        
    }
}
