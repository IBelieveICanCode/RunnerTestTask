using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    private List<GameObject> _spawnedObstacles;
    private float _maxRoadCount = 3,
                  _maxObstacleCount = 25;
    [System.NonSerialized]
    public List<GameObject>
        _activeTiles = new List<GameObject>(),
        _activeObstacle = new List<GameObject>();

    public void DeleteTiles()
    {
        if (_activeTiles.Count > _maxRoadCount)
        {
            Destroy(_activeTiles[0]);
            _activeTiles.RemoveAt(0);
        }
    }

    public void DeleteObstacles()
    {
        if (_activeObstacle.Count > _maxObstacleCount)
        {
            Destroy(_activeObstacle[0]);
            _activeObstacle.RemoveAt(0);
        }
    }
}
