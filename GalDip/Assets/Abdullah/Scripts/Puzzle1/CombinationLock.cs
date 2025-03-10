using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class CombinationLock : MonoBehaviour
{
    public string lockCombenation;
    public TextMeshPro[] lockSlots;
    // Update is called once per frame
    public UnityEvent solvePuzzleResult;

    public void IncreaseNumber(int index)
    {
        int numb;
        numb = int.Parse(lockSlots[index].text) + 1;
        if (numb > 9) numb = 0;
        lockSlots[index].text = numb.ToString();

        Debug.Log("IncreaseNumber: "+lockSlots[index].text);

        CheckIfCorrect();

    }

    public void DecreaseNumber(int index)
    {
        int numb;
        numb = int.Parse(lockSlots[index].text) - 1;
        if (numb < 0) numb = 9;
        lockSlots[index].text = numb.ToString();

        Debug.Log("DecreaseNumber: "+lockSlots[index].text);

        CheckIfCorrect();
    }
    public void CheckIfCorrect()
    {
        string storeNumber = "";
        foreach (TextMeshPro num in lockSlots)
        {
           storeNumber = storeNumber + num.text;
            
        }
        if (storeNumber == lockCombenation)
        {
            Debug.Log("Solved");
            solvePuzzleResult.Invoke();
        }
    }


/*
_________

Doors glow to signifiy change room teleportaton.

Perspective puzzle:
If the player looked from certin direction object spawns.
Trigger zone to stand on.
Check camera rotation ofcwithin range.
    */



}
