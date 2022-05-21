using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    public float perishDelay = 3f;

    void Start()
    {
        if (PoolManager.Instance.isPoolingEnabled) StartCoroutine(Perish());
    }

    private void OnEnable()
    {
        if (PoolManager.Instance.isPoolingEnabled) StartCoroutine(Perish());
    }

    IEnumerator Perish()
    {
        yield return new WaitForSeconds(perishDelay);
        
        Debug.Log("Kirby gone");

        // Return to the pool
        PoolManager.Instance.spawnPool.Release(gameObject);
        
        
    }
}