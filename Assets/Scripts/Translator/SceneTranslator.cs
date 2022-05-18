using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTranslator : MonoBehaviour
{
    void Start()
    {
        string generalLang = PlayerPrefs.GetString("lang");

        if(generalLang != null)
        {
            SetLanguage(generalLang);
        }
    }

    public void SetLanguage(string ISOCode)
    {
        MainTranslate.SetLanguage(ISOCode);
    }
}
