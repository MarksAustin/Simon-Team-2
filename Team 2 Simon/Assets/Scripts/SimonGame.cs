using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGame : MonoBehaviour
{
    [SerializeField]
    Simon simonPlayer;
    [SerializeField]
    Player player;
    [SerializeField]
    List<Button> buttons = new List<Button>();


    //If 0 Simons turn, if 1 its players turn
    int turn = 0; 

    int numberOfPresses = 2;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b in buttons)
        {
            b.buttonPressed += HandleButtonPressed;
        }

        simonPlayer.TakeTurn(numberOfPresses);

    }

    private void HandleButtonPressed(Button obj)
    {
        Debug.Log("<color=green>SimonGame here, a button was pressed: " + obj.name + "</color>");

        if (turn == 0)
        {
            simonsTurn.Add(obj.name);
        }

    }

    List<string> simonsTurn = new List<string>();
    bool turnTaken = false;

    // Update is called once per frame
    void Update()
    {

        //Simons Turn
        if (turn == 0)
        {
            if (simonsTurn.Count == numberOfPresses)
            {
                Debug.Log("<color=green>SimonGame here, I've finished my turn: " + simonsSelection() + "</color>");
                turn = 1;
            }
        }

        //Players Turn
        if (turn == 1)
        {


        }
    }

    private string simonsSelection()
    {
        string simonsSelectionString = "";
        {
            simonsSelectionString += simonsSelectionString + ", ";
        }

        return simonsSelectionString;
    }
}
