using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueMenu : PrintTextMenu
{
    [SerializeField] private string dialogue_label_name = "dialogue";

    private Label _text_label;

    public override void Awake()
    {
        base.Awake();
        _text_label = (Label)Get<Label>(dialogue_label_name);
    }

    public void Update()
    {
        if (!Is_showed)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        if (Print_text_coroutine != null)
            ShowPrintingText(_text_label);
        else
            NextText(_text_label);
    }

    public void StartDialogue(List<string> dialogue_first, List<string> dialogue_second)
    {

    }

}
