using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    Color buttonColor;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = buttonColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine;
   
    internal void Activate()
    {
        if (isAnimating) return;

        if (coroutine != null) StopCoroutine(coroutine);
        StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material));
    }

    bool isAnimating = false;
    private IEnumerator ChangeObjColor(Material material)
    {
        isAnimating = true;
        LeanTween.cancel(gameObject);
        // Tween Color change
        LeanTween.moveLocalZ(gameObject, 0.2f, 0.5f);        
        LeanTween.color(gameObject, Color.black, 0.5f).setEase(LeanTweenType.easeInOutSine);
        yield return new WaitForSeconds(1.5f);
        //Tween Color change
        LeanTween.moveLocalZ(gameObject, 0, 0.5f);        
        LeanTween.color(gameObject, buttonColor, 0.5f).setEase(LeanTweenType.easeInOutSine);        
        isAnimating = false;
    }
}
