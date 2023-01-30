using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthBar : MonoBehaviour
{
    [SerializeField] GameObject objWithHealthScript;

    Health healthScript;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = objWithHealthScript.GetComponent<Health>();
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = healthScript.healthPoints;
        slider.value = healthScript.healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthScript.healthPoints;
    }
}
