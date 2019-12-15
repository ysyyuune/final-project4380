using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lefthand;
    public TextMesh rText;
    public GameObject righthand;
    AudioSource audioData;

    void Start()
    {
        audioData = lefthand.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lefthand.transform.childCount > 0 && righthand.transform.childCount>0)
        {
            if (lefthand.transform.Find("hydrochloric acid") && righthand.transform.Find("marble"))
            {
                rText.text = "2HCI+CaCO3 =>CaCl2+H2O+CO2";
                audioData.Play(0);
                if(Input.GetButtonDown("Fire1"))
                {
                    GameObject.Destroy(lefthand.transform.GetChild(0).gameObject);
                    GameObject.Destroy(righthand.transform.GetChild(0).gameObject);
                }
            }
            else if(righthand.transform.Find("hydrochloric acid") && lefthand.transform.Find("marble"))
            {
                rText.text = "2HCI+CaCO3 =>CaCl2+H2O+CO2";
                audioData.Play(0);
                if (Input.GetButtonDown("Fire1"))
                {
                    GameObject.Destroy(lefthand.transform.GetChild(0).gameObject);
                    GameObject.Destroy(righthand.transform.GetChild(0).gameObject);
                }
            }
        }
        else
        {
            rText.text = "you don't have enough chemicals";
        }
    }
}
