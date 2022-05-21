using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public GameObject Prefab;
    public int StartCapacity;
    public int MaxSize;

    public ObjectPool<GameObject> spawnPool;

    public static PoolManager Instance;

    public bool isPoolingEnabled;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Start()
    {
        spawnPool = new ObjectPool<GameObject>(
                () => Instantiate(Prefab), 
                OnGetFromPool,
                OnReleaseFromPool,
                OnDestroyInPool,
                true,
                StartCapacity,
                MaxSize
                );
    }

    private void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }
    
    private void OnReleaseFromPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyInPool(GameObject obj)
    {
        Destroy(obj);
    }


    public bool CanGet()
    {
        return spawnPool.CountActive < MaxSize;
    }

    public GameObject GetFromPool()
    {
        return spawnPool.Get();
    }
    
    public void ReturnToPool(GameObject g)
    { 
        spawnPool.Release(g);
    }
    
    
}
