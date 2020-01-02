﻿namespace ShawContract.Models.InlineEditors
{
    public class TextEditorViewModel : InlineEditorViewModel
    {
        public string Text { get; set; }

        public bool EnableFormatting { get; set; } = true;
    }
}