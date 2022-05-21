using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIText : MonoBehaviour
{
    public GameObject Panel;
    
    public void OpenMessagePanel(string text)
    {
        Panel.SetActive(true);
    }

    public void CloseMessagePanel(string text)
    {
        Panel.SetActive(false);
    }


}
