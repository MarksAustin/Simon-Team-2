using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    [SerializeField]
    bool debugMode = false;

    List<int> choices = new List<int>();

    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    int numberOfChoices = 2;
    // Update is called once per frame
    void Update()
    {
        TakeTurn(numberOfChoices++);
    }

    public int[] TakeTurn(int numberOfChoices)
    {
        int[] choices = new int[numberOfChoices];

        for (int i = 0; i < numberOfChoices; i++)
           choices[i] = UnityEngine.Random.Range(0, 4);

        if (debugMode)
        LogChoices(choices, numberOfChoices);

        return choices;
    }

    private void LogChoices(int[] choices, int num)
    {
        string outputString = choices[0].ToString();
        for (int i = 1; i < num; i++)
            outputString += ", " + choices[i].ToString();

        Debug.Log(outputString);
    }
}
