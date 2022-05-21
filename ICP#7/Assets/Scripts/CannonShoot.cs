using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public Transform spawnPoint;
    public Transform basePoint;

    private AudioSource cannonSound;

    // Start is called before the first frame update
    void Start()
    {
        cannonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (PoolManager.Instance.isPoolingEnabled)
            {
                if (!PoolManager.Instance.CanGet()) return;
                var newBall = PoolManager.Instance.GetFromPool();
                newBall.transform.position = spawnPoint.position;
                Rigidbody ballBody = newBall.GetComponent<Rigidbody>();
                if (ballBody != null)
                {
                    ballBody.velocity = Vector3.zero;
                    ballBody.angularVelocity = Vector3.zero;
                    ballBody.AddForce((spawnPoint.position - basePoint.position) * 300f);
                    _particleSystem.Emit(4);
                }
                cannonSound.PlayOneShot(cannonSound.clip);
            }
            else
            {
                var newBall = Instantiate(PoolManager.Instance.Prefab, spawnPoint.position, Quaternion.identity);
                Rigidbody ballBody = newBall.GetComponent<Rigidbody>();
                if (ballBody != null)
                {
                    ballBody.velocity = Vector3.zero;
                    ballBody.angularVelocity = Vector3.zero;
                    ballBody.AddForce((spawnPoint.position - basePoint.position) * 300f);
                    _particleSystem.Emit(4);
                }
                cannonSound.PlayOneShot(cannonSound.clip);
            }
        }
    }
}
