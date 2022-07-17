using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class rand : MonoBehaviour
{
    public Sprite[] d;
    public GameObject cube;
    public int randInt;
    public GameObject startButton;
    public GameObject stopButton;
    // Start is called before the first frame update
    IEnumerator Fade()
    {
        while (true)
        {
            randInt = Random.Range(0, 6);
            cube.GetComponent<Image>().sprite = d[randInt];
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    public void Pusk()
    {
        StartCoroutine("Fade");
        Destroy(startButton);
    }

    public void Stop()
    {
        
        StopCoroutine("Fade");
        Destroy(stopButton);
    }
  

  
  
}