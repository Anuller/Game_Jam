using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightSystem : MonoBehaviour
{
    [Header("Referencias")]

    [Tooltip("Referencia da luz")]
    public Light2D lightObj;

    //public float lightRange;

    void Start()
    {
        lightObj.pointLightOuterRadius = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
