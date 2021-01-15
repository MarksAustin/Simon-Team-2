using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    Color buttonColor;

    Material material;

    public event Action<Button> buttonPressed;
    public float buttonSpeed = 0.1f;

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

        Debug.Log(gameObject.name + " has been pressed");

        if (coroutine != null) StopCoroutine(coroutine);
        StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material));

        if (buttonPressed != null) buttonPressed(this);
    }

    bool isAnimating = false;
    private IEnumerator ChangeObjColor(Material material)
    {
        isAnimating = true;
        LeanTween.cancel(gameObject);
        // Tween Color change
        LeanTween.moveLocalZ(gameObject, 0.2f, buttonSpeed);        
        //LeanTween.color(gameObject, Color.black, 0.5f).setEase(LeanTweenType.easeInOutSine);

        yield return new WaitForSeconds(buttonSpeed);

        //Tween Color change
        LeanTween.moveLocalZ(gameObject, 0, buttonSpeed);        
        //LeanTween.color(gameObject, buttonColor, 0.5f).setEase(LeanTweenType.easeInOutSine);    
        
        isAnimating = false;
    }
}
