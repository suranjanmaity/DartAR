// using System.Runtime.CompilerServices;
// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlaneManager))]

public class ARPlaneController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();   
    }

    void OnEnable()
    {
        PlaceObjectOnPlane.onPlaceObject += DisablePlaneDetection;
    }

    void OnDisable()
    {
        PlaceObjectOnPlane.onPlaceObject -= DisablePlaneDetection;
    }

    void DisablePlaneDetection()
    {
        SetAllPlanesActive(false);
        m_ARPlaneManager.enabled = !(m_ARPlaneManager.enabled);
    }

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }

}
