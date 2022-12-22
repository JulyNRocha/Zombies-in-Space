using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleIncriseAmount = 60f;
    [SerializeField] float intensityIncriseAmount = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().IncriseLighAngle(angleIncriseAmount);
            other.GetComponentInChildren<FlashLightSystem>().IncriseLighIntensity(intensityIncriseAmount);
            Destroy(this.gameObject);
        }
    }
}
