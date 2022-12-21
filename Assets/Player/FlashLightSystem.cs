using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimunAngle = 40f;

    Light myLight;
    
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update() 
    {
        DecraseLightAngle();
        DecreaseLightIntensity();    
    }

    public void IncriseLighAngle(float incriseAmount)
    {
        myLight.spotAngle = incriseAmount;
    }
    
    public void IncriseLighIntensity(float incriseAmount)
    {
        myLight.intensity += incriseAmount;
    }

    void DecraseLightAngle()
    {
        if (myLight.spotAngle <= minimunAngle) 
        { 
            return; 
        }
        else
        {
            myLight.spotAngle -= angleDecay *  Time.deltaTime;
        }
        
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
