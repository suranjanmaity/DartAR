// using System.Reflection.Metadata;
// using System.Timers;
// using System.Numerics;
// using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// namespace UnityEngine
//     {
//        public static class Handheld
//        {
//            public static void Vibrate()
//            {}
//        }
//     }

public class Dart : MonoBehaviour
{
    private Rigidbody rg;
    private GameObject dirObj;
    public bool isForceOK = false;
    bool isDartRotating = false;
    bool isDartReadyToShoot = true;
    bool isDartHitOnBoard = false;

    ARSessionOrigin aRSession;
    GameObject ARCam;

    public Collider dartFrontCollider;
    // Start is called before the first frame update
    void Start()
    {
        aRSession = GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;

        if(TryGetComponent(out Rigidbody rigid))
        rg = rigid;

        dirObj = GameObject.FindGameObjectWithTag("DartThrowPoint");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isForceOK)
        {
            dartFrontCollider.enabled = true;
            StartCoroutine(InitDartDestroyVFX());
            GetComponent<Rigidbody>().isKinematic = false;
            isForceOK = false;
            isDartRotating = true;
        }

        rg.AddForce(dirObj.transform.forward * (12f + 6f) * Time.deltaTime, ForceMode.VelocityChange);

        if(isDartReadyToShoot)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
        }

        if(isDartRotating)
        {
            isDartReadyToShoot = false;
            transform.Rotate(Vector3.forward * Time.deltaTime * 400f);
        }
    }

    IEnumerator InitDartDestroyVFX()
    {
        yield return new WaitForSeconds(30f);
        // if (!isDartHitOnBoard)
        // {
            Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("dart_board"))
        {
        SoundManager.Instance.play_dartHitSound();
            if( Application.platform == RuntimePlatform.Android )
                {
                    Handheld.Vibrate();
                }
        GetComponent<Rigidbody>().isKinematic = true;
        isDartHitOnBoard = true; 
        isDartRotating = false;
        }
    }
}
