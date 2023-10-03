using UnityEngine;

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

}
