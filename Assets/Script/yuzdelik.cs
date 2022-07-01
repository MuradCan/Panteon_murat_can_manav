using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yuzdelik : MonoBehaviour
{
    public Text text;
    public static float yuzde=0;
    public bool colored;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        text.text = 0 + "%";
        colored = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = yuzde.ToString() + "%";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spray" && !colored)
        {
            colored = true;
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, 1);
            if (yuzdelik.yuzde < 100)
            {
                yuzdelik.yuzde += 100/6144f;
                slider.GetComponent<Slider>().value += 100 / 6144f;
                if (yuzdelik.yuzde >= 99.9f)
                {
                    yuzdelik.yuzde = 100;
                }
            }

            

        }
    }
}
