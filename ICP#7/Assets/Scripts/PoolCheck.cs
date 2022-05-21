using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolCheck : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private int inactives;
    private int actives;


    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    //yes I know this shouldn't be put in update
    void Update()
    {

        if (PoolManager.Instance.isPoolingEnabled)
        {

            inactives = PoolManager.Instance.spawnPool.CountInactive;
            actives = PoolManager.Instance.spawnPool.CountActive;

            _text.text = "Inactive slots: " + inactives + ", Unreturned objects: " + actives;
        }
        else
        {
            _text.text = "Pooling disabled :moyai:";
        }
    }
}
