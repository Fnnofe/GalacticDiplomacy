using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractbleDialouge: MonoBehaviour
{
    public static InteractbleDialouge Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) dialogueText.text = "";
    }

    public void ShowText(string message)
    {
        dialogueText.text = message;
        StopAllCoroutines();
       
        //StartCoroutine(HideTextAfterSeconds(2f));
    }

    private IEnumerator HideTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogueText.text = "";
    }
}
