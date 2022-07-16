using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class rand : MonoBehaviour
{
    [SerializeField] public Text RandText;
    public AnimationClip y;
    public Sprite[] d;
    public GameObject[] d1;
    public GameObject cube;
    
    public int w;
    public int rd;

    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        
            d1[0].SetActive(false);
            d1[1].SetActive(false);
            d1[2].SetActive(false);
            d1[3].SetActive(false);
            d1[4].SetActive(false);
            d1[5].SetActive(false);

            StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    
    
    IEnumerator Fade()
    {
        while (true)
        {
            Debug.Log("gggggg");
            rd = Random.Range(0, 6);
            cube.GetComponent<Image>().sprite = d[rd];
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void t()
    {
        d1[0].SetActive(true);
        Destroy(boton);
    }
    
    public void pusk()
    {
        
        StartCoroutine(Fade());
        w=Random.Range(1, 7);
        if (w == 1)
        {
            d1[0].SetActive(true);
        }
        if (w == 2)
        {
            d1[1].SetActive(true);
        }
        if (w == 3)
        {
            d1[2].SetActive(true);
        }
        if (w == 4)
        {
            d1[3].SetActive(true);
        }
        if (w == 5)
        {
            d1[4].SetActive(true);
        }
        if (w == 6)
        {
            d1[5].SetActive(true);
        }

    }
  

  
  
}
