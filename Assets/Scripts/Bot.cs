using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{



    int randomGuess;
    // Start is called before the first frame update
    public string GuessBot()
    {
        randomGuess = UnityEngine.Random.Range(1, 100);
        Debug.Log(randomGuess);
        Console.Write(randomGuess);
        return randomGuess.ToString();

    }
}
