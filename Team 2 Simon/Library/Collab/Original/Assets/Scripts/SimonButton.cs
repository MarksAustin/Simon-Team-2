using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SimonButton : MonoBehaviour
{
    //this is a git update test

    Camera cam; //ref to main camera
    Ray ray; // ref to our mouse press position

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Someone pressed Fire!");
            ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("<color=green>We hit an Object</color> " + hit.transform.gameObject.name);
                StartCoroutine(ChangeObjColor(hit.transform.GetComponent<Renderer>().material));
            }
        }
    }

    private IEnumerator ChangeObjColor(Material material)
    {
        Color originalColor = material.color;

        material.color = Color.black;
        yield return new WaitForSeconds(1f) ;

        material.color = originalColor;
    }
}
