using System;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Color randomlySelectedColor = GetRandomColor();
        GetComponent<Renderer>().material.color = randomlySelectedColor;
    }

    private new Color GetRandomColor()
    {
        return new Color(
            r:UnityEngine.Random.Range(0f,1f),
            g:UnityEngine.Random.Range(0f,1f),
            b:UnityEngine.Random.Range(0f,1f));
    }
}
