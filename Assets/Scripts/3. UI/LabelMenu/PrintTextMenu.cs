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
    public List<DialogueNode> DialogueNodes
    {
        get { return _dialogue_nodes; }
        private set
        {
            if (value.Count == 0)
                return;

            _dialogue_nodes = new(value);
        }
    }

    [SerializeField] private float _print_char_time = .05f;
    [SerializeField] private List<DialogueNode> _dialogue_nodes = new();
    [SerializeField] private float _skip_text_time = 2;
    [SerializeField] private string printable_label_name = "dialogue";
    private Rotator _rotator;

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

        if (DialogueNodes.Count > 0)
        {
            _print_text_coroutine = StartCoroutine(PrintText(_dialogue_nodes[0].Text));

            if (_dialogue_nodes[0].Look_target == null)
                _rotator.ResetRotator();
            else
                _rotator.ChangeRotator(new LookAtRotator(_dialogue_nodes[0].Look_target));

            return;
        }


        _on_sayers_ended?.Invoke();
        base.StartHide();
    }

    protected void ShowPrintingText()
    {
        if (_dialogue_nodes.Count == 0)
            return;

        _text_label.text = DialogueNodes[0].Text;
        DialogueNodes.RemoveAt(0);
    }

    public void StartMonologue(List<DialogueNode> monologue, UnityEvent on_ended, Rotator rotator)
    {
        base.StartShow();

        _rotator = rotator;

        _on_sayers_ended = on_ended;
        DialogueNodes = new(monologue);
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
