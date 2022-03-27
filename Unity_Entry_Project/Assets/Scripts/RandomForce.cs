using UnityEngine;

public class RandomForce : MonoBehaviour
{
    [SerializeField] private float _thrust = 10f;
    [SerializeField] private float min = -10f;
    [SerializeField] private float max = 10f;

    private void OnCollisionEnter(Collision other)
    {
        var rb = GetComponent<Rigidbody>();

        rb.AddForce(Random.Range(min, max), Random.Range(min, max), _thrust, ForceMode.Impulse);
    }
}