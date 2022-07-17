using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    public String Name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeQQQ()
    {
        Invoke("Manejer",0.5f);
    }

    public void Manejer()
    {
        SceneManager.LoadScene(Name);
    }
}
