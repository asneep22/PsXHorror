using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PrintTextMenu : Menu
{
    public Coroutine Print_text_coroutine
    {
        get => _print_text_coroutine;
        private set => _print_text_coroutine = value;
    }
    public List<string> Texts
    {
        get { return _texts; }
        private set
        {
            if (value.Count == 0)
                return;

            _texts = new(value);
        }
    }

    [SerializeField] private float _print_char_time = .05f;
    [SerializeField] private List<string> _texts = new();
    [SerializeField] private float _skip_text_time = 2;
    [SerializeField] private string printable_label_name = "dialogue";

    private UnityEvent _on_texts_ended;
    private Coroutine _print_text_coroutine;
    private Coroutine _skip_text_corutine;
    private Label _text_label;

    public override void Start()
    {
        _text_label = (Label)Get<Label>(printable_label_name);
        base.Start();
    }

    protected void NextText()
    {
        _print_text_coroutine = CoroutineExtension.Stop(this, _print_text_coroutine);

        if (Texts.Count > 0)
        {
            _print_text_coroutine = StartCoroutine(PrintText(_texts[0]));
            return;
        }

        _on_texts_ended?.Invoke();
        base.StartHide();
    }

    protected void ShowPrintingText()
    {
        _print_text_coroutine = CoroutineExtension.Stop(this, _print_text_coroutine);
        _text_label.text = Texts[0];
        Texts.RemoveAt(0);

        _skip_text_corutine = CoroutineExtension.Stop(this, _skip_text_corutine);
        _skip_text_corutine = StartCoroutine(SkipText());
    }

    public void StartMonologue(List<string> monologue, UnityEvent on_ended)
    {
        base.StartShow();
        _on_texts_ended = on_ended;
        Texts = new(monologue);
        NextText();
    }

    private IEnumerator PrintText(string text)
    {
        int char_index = 0;
        _text_label.text = "";

        while (_text_label.text != text)
        {
            _text_label.text += text[char_index];
            char_index += 1;
            yield return new WaitForSeconds(_print_char_time);
        }

        _texts.RemoveAt(0);
        Print_text_coroutine = CoroutineExtension.Stop(this, Print_text_coroutine);

        _skip_text_corutine = CoroutineExtension.Stop(this, _skip_text_corutine);
        _skip_text_corutine = StartCoroutine(SkipText());
    }

    private IEnumerator SkipText()
    {
        yield return new WaitForSeconds(_skip_text_time);

        if (Is_showed)
            NextText();
    }
}
