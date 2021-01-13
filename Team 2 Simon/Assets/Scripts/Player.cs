using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    

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
                if (hit.transform.tag.Equals("Button"))
                {
                    Button button = hit.transform.GetComponent<Button>();
                    Debug.Log("<color=green>We hit an Object</color> " + hit.transform.gameObject.name);
                    button.Activate();

                    
                }
            }
        }
    }


}
