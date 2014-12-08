using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    /// <summary>
    /// Model for a japanese word,
    /// contains an ID for searching puroses
    /// Kanji Entry
    /// Hiragana entry
    /// Romaji entry
    /// Addtional text entry (ex of use)
    /// photo entry? ( implemented at later intervals)
    /// Mother tongue translation entry
    /// Mother tongue lable (english/dutch/french etc)
    /// </summary>
    public class JapaneseWord
    {
        public int EntryID { get; set; }
        public string Kanji { get; set; }
        public string Hiragana { get; set; }
        public string Romaji { get; set; }
        public string AdditionalText { get; set; }
        public string MotherTongueTranslation { get; set; }
        public string MotherTongueTranslationLabel { get; set; }

        public JapaneseWord() 
        {
            Kanji = "";
            Hiragana = "";
            Romaji = "";
            AdditionalText = "";
            MotherTongueTranslation = "";
            MotherTongueTranslationLabel = "";
        }
        //public image photo {get; set;}
    }
}