using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PrintTextMenu : Menu
{
    [SerializeField] private float _print_char_time = .05f;
    [SerializeField] private List<string> _texts = new();
    [SerializeField] private UnityEvent _on_texts_ended;

    private Coroutine _print_text_coroutine;

    public Coroutine Print_text_coroutine
    {
        get;
        private set;
    }
    public List<string> Texts
    {
        get { return _texts; }
        set
        {
            if (value.Count == 0)
                return;

            _texts = new(value);
        }
    }


    public void NextText(Label label)
    {
        Print_text_coroutine = CoroutineExtension.Stop(this, Print_text_coroutine);
        label.text = "";

        if (Texts.Count > 0)
        {
            Print_text_coroutine = StartCoroutine(PrintText(label, _texts[0]));
            return;
        }

        _on_texts_ended?.Invoke();
        base.Hide();
    }

    public void ShowPrintingText(Label label)
    {
        Print_text_coroutine = CoroutineExtension.Stop(this, Print_text_coroutine);
        label.text = _texts[0];
        Texts.RemoveAt(0);
    }

    public void StartMonologue(Label label, List<string> monologue)
    {
        base.Show();
        Texts = new(monologue);
        NextText(label);
        print("asd");
    }

    private IEnumerator PrintText(Label label, string text)
    {
        int char_index = 0;
        while (label.text != text)
        {
            label.text += text[char_index];
            char_index += 1;
            yield return new WaitForSeconds(_print_char_time);
        }

        _texts.RemoveAt(0);
        Print_text_coroutine = CoroutineExtension.Stop(this, Print_text_coroutine);
    }
}
