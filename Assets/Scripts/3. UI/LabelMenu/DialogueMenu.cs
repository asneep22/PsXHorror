using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueMenu : PrintTextMenu
{

    public void Update()
    {
        if (!Is_showed)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        if (Print_text_coroutine != null)
            ShowPrintingText();
        else
            NextText();
    }

    public void StartDialogue(List<string> dialogue_first, List<string> dialogue_second)
    {

    }

}
