using System;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawner : Singleton<HurdleSpawner>
{
    [SerializeField] private LevelSpline _level;
    [SerializeField] private GameObject _hurdlePrefab;
    [SerializeField] private float _playerDashDistance= 3f, _spawnInterval=0.5f;
    [SerializeField] private int _maxDashesFromCenter = 1;
    [SerializeField] private float _spawnGracePeriod=2f;
    [SerializeField]
    [Range(0, 1)] private float _probabilityOfHurdleSpawn = 0.5f;
    private uint _hurdlesSpawned;

    private void Start() => SpawnHurdles();
    private void SpawnHurdles()
    {
        _hurdlesSpawned = 0;
        for (float u = _spawnGracePeriod; u < _level.GetMaxU(); u += _spawnInterval)
            SpawnHurdleStripAt(u);
    }

    private void SpawnHurdleStripAt(float u)
    {
        int hPositionCount = UnityEngine.Random.Range(1, _maxDashesFromCenter*2+1);
        HashSet<int> hPositions = new();
        for(int i =0;i<hPositionCount;i++)
        {
            hPositions.Add(UnityEngine.Random.Range(-_maxDashesFromCenter,_maxDashesFromCenter+1));
        }

        for (int hPositionIndex = -_maxDashesFromCenter; hPositionIndex <= _maxDashesFromCenter; hPositionIndex++)
        {
            TrySpawnHurdle(u,hPositionIndex, hPositions);
        }
    }
    private void TrySpawnHurdle(float u,int hPositionIndex, HashSet<int> hPositions)
    {
        if (!hPositions.Contains(hPositionIndex)) return;
        if (!ChanceToSpawn()) return;
        SpawnHurdle(u,hPositionIndex);
    }

    private void SpawnHurdle(float u, int hPositionIndex)
    {
        Vector3 position = _level.GetPointVector3(u) + CalculateOffset(u, hPositionIndex);
        Quaternion rotation = _level.GetRotation(u);
        Hurdle.Builder.SetWorldPosition(position).SetSelfDestructPriority(++_hurdlesSpawned)
            .AttachToGameObject(_hurdlePrefab).Build();
    }
    private Vector3 CalculateOffset(float u, int hPositionIndex)
    {
        Vector3 right = Vector3.Cross(Vector3.up, _level.GetForwardVector(u));
        return right * hPositionIndex * _playerDashDistance;
    }

    private bool ChanceToSpawn()=>UnityEngine.Random.value <= _probabilityOfHurdleSpawn;
    
        
    
}
