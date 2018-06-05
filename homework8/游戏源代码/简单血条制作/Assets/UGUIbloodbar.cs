using UnityEngine;
using UnityEngine.UI;

public class UGUIbloodbar : MonoBehaviour
{
    public Button Add;
    public Button Minus;

    private void Start()
    {
        Add.onClick.AddListener(delegate () {
            float blood = GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value;
            blood -= 10;
            if (blood < 0)
            {
                GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value = 0;
            }
            else
            {
                GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value = blood;
            }

        });
        Minus.onClick.AddListener(delegate () {
            float blood = GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value;
            blood += 10;
            if (blood > 100)
            {
                GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value = 100;
            }
            else
            {
                GameObject.FindGameObjectWithTag("bloodbar").GetComponent<Slider>().value = blood;
            }

        });
    }

    void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
        
    }
}