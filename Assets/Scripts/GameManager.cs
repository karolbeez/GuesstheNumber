using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Lock;
    public GameObject gameplayView;
    public GameObject minNumber;
    public GameObject maxNumber;
    public TextMeshProUGUI responseText;
    public TextMeshProUGUI botGuessText;

    private int randomGuess;
    private int randomNumber;
    string minNum;
    string maxNum;


    /// 
    /// Przycisk start + generowanie liczby
    /// 
    public void StartGame()
    {
        string minNum = minNumber.GetComponent<TMP_InputField>().text;
        string maxNum = maxNumber.GetComponent<TMP_InputField>().text;
        int.TryParse(minNum, out int min);
        int.TryParse(maxNum, out int max);
        if (min == 0) { min = 1; }
        if (max == 0) { max = 10; }
        Lock.SetActive(true);
        gameplayView.SetActive(true);
        randomNumber = UnityEngine.Random.Range(min, max);
        responseText.text = "Komputer zgaduje liczbê "+randomNumber;
        Debug.Log(randomNumber);
        StartCoroutine(Bot());
    }

    public IEnumerator Bot()
    {
        string minNum = minNumber.GetComponent<TMP_InputField>().text;
        string maxNum = maxNumber.GetComponent<TMP_InputField>().text;
        int.TryParse(minNum, out int min);
        int.TryParse(maxNum, out int max);
        if (min == 0) {min = 1; }
        if (max == 0) {max = 10;}

        Lock.SetActive(true);
        randomGuess = 0;
        Debug.Log("Start! "+randomNumber);

        int minG = min; int maxG = max;
        int proba = 0;

        ///
        /// algorytm losowania:
        /// tak zmienna nosi nazwê randomGuess, ale tak naprawdê stoi za ni¹ prosty algorytm divide and conquer
        ///
        while (randomGuess != randomNumber)
        {
            randomGuess = (minG + maxG) / 2;

            proba++;
            if (randomGuess == randomNumber)
            {
                botGuessText.text = "Bot odgad³!\nLiczba prób: "+proba;
                Debug.Log("Koniec! "+randomGuess);
                yield return new WaitForSeconds(0.01f);
                Lock.SetActive(false);
            }

            else if (randomGuess < randomNumber)
            {
                minG = randomGuess;
                botGuessText.text = "Bot strzeli³ za nisko -> " + randomGuess;
                Debug.Log("ZA NISKO " + randomGuess);
                proba++;

                yield return new WaitForSeconds(.1f);
            }
            else if (randomGuess > randomNumber)
            {
                maxG = randomGuess;
                botGuessText.text = "Bot strzeli³ za wysoko -> " + randomGuess;
                Debug.Log("ZA WYSOKO " + randomGuess);
                proba++;

                yield return new WaitForSeconds(.1f);
            }





        }

    }


    /// stary algorytm - nadal wszystko sie losuje, ale ogracznicza max i min zakres w losowaniach, zamiast u¿ywania divide and conquer
    /// 


    /*  public IEnumerator Bot()
      {
          string minNum = minNumber.GetComponent<TMP_InputField>().text;
          string maxNum = maxNumber.GetComponent<TMP_InputField>().text;
          int.TryParse(minNum, out int min);
          int.TryParse(maxNum, out int max);
          if (min == 0 || max ==0)
          {
              min = 1; max = 10;
          }

          Lock.SetActive(true);
          randomGuess = 0;
          Debug.Log(randomGuess);

          int minG = min; int maxG = max;


          while (randomGuess != randomNumber)
          {
              randomGuess = UnityEngine.Random.Range(minG, maxG);

              if (randomGuess == randomNumber)
              {
                  botGuessText.text = "Bot odgad³!";
                  Debug.Log(randomGuess);
                  yield return new WaitForSeconds(0.01f);
                  Lock.SetActive(false);
              }
              else if (randomGuess < randomNumber)
              {
                  minG = randomGuess;
                  botGuessText.text = "Bot strzeli³ za nisko -> " + randomGuess;
                  Debug.Log("ZA NISKO " + randomGuess);
                  yield return new WaitForSeconds(.1f);
              }
              else if (randomGuess > randomNumber)
              {
                  maxG = randomGuess;
                  botGuessText.text = "Bot strzeli³ za wysoko -> " + randomGuess;
                  Debug.Log("ZA WYSOKO " + randomGuess);
                  yield return new WaitForSeconds(.1f);
              }





          }

      }

      */










}
