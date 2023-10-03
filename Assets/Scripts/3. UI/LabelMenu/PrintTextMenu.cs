using EntitySystem;
using EntitySystem.Components;
using EntitySystem.Components.DialogueSystem;
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
    public List<Sayer> Sayers
    {
        get { return _sayers; }
        private set
        {
            if (value.Count == 0)
                return;

            _sayers = new(value);
        }
    }

    [SerializeField] private float _print_char_time = .05f;
    [SerializeField] private List<Sayer> _sayers = new();
    [SerializeField] private float _skip_text_time = 2;
    [SerializeField] private string printable_label_name = "dialogue";

    private UnityEvent _on_sayers_ended;
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

        if (Sayers.Count > 0)
        {
            _print_text_coroutine = StartCoroutine(PrintText(_sayers[0].Text));

            foreach(LookAtRotator rotator in _sayers[0].Rotators)
                rotator.BeginLookAt(_sayers[0].Look_target, _sayers[0].Time);

            return;
        }

        _on_sayers_ended?.Invoke();
        base.StartHide();
    }

    protected void ShowPrintingText()
    {
        if (_sayers.Count == 0)
            return;

        _text_label.text = Sayers[0].Text;
        Sayers.RemoveAt(0);
    }

    public void StartMonologue(List<Sayer> monologue, UnityEvent on_ended)
    {
        base.StartShow();
        _on_sayers_ended = on_ended;
        Sayers = new(monologue);
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

        Print_text_coroutine = CoroutineExtension.Stop(this, Print_text_coroutine);

        _skip_text_corutine = CoroutineExtension.Stop(this, _skip_text_corutine);
        _skip_text_corutine = StartCoroutine(SkipText());

        ShowPrintingText();
    }

    private IEnumerator SkipText()
    {
        yield return new WaitForSeconds(_skip_text_time);

        if (Is_showed)
            NextText();
    }
}
