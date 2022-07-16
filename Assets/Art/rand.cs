using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class rand : MonoBehaviour
{
    [SerializeField] public Text RandText;

    public GameObject r;
    public Sprite r1;
    public Sprite r2;
    public Sprite r3;
    public Sprite r4;
    public Sprite r5;
    // Start is called before the first frame update
    void Start()
    {
        r.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void G()
    {
        RandText.text = Random.Range(1, 7).ToString();
        if (RandText.text == 1.ToString())
        {
            r.SetActive(true);
        }


    }

    public void P()
    {
       
    }
  
}
