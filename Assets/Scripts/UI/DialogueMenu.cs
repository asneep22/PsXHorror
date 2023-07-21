using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueMenu : Menu
{
    [SerializeField] private float _print_char_time = .05f;
    [SerializeField] private string dialogue_label_name = "dialogue";
    [SerializeField] private UnityEvent _on_texts_ended;

    private List<string> _texts = new();

    private Coroutine _print_text_coroutine;
    private Label _text_label;

    private void Start()
    {
        _text_label = (Label)Get<Label>(dialogue_label_name);
    }

    public void Update()
    {
        if (!IsShowed)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        if (_print_text_coroutine != null)
            ShowPrintingText();
        else
            NextText();
    }

    public void StartMonologue(List<string> monologue)
    {
        base.Show();
        _texts = monologue;
        NextText();
    }

    public void StartDialogue(List<string> dialogue_first, List<string> dialogue_second)
    {

    }

    private void ShowPrintingText()
    {
        _print_text_coroutine = CoroutineExtension.Stop(this, _print_text_coroutine);
        _text_label.text = _texts[0];
        _texts.RemoveAt(0); 
    }

    private void NextText()
    {
        _print_text_coroutine = CoroutineExtension.Stop(this, _print_text_coroutine);
        _text_label.text = "";

        if (_texts.Count > 0)
        {
            _print_text_coroutine = StartCoroutine(PrintText(_texts[0]));
            return;
        }

        _on_texts_ended?.Invoke();
        base.Hide();
    }

    private IEnumerator PrintText(string text)
    {
        int char_index = 0;
        while (_text_label.text != text)
        {
            _text_label.text += text[char_index];
            char_index += 1;
            yield return new WaitForSeconds(_print_char_time);
        }

        _texts.RemoveAt(0);
        _print_text_coroutine = CoroutineExtension.Stop(this, _print_text_coroutine);
    }

}
