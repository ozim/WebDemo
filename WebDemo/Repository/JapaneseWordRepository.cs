using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo.DataAccessLayer;
using WebDemo.Models;
using System.Diagnostics;

namespace WebDemo.Repository
{
    /// <summary>
    /// I recall that repositories are usually static, but after researching why,
    /// I decided to make it none static so it can be tested in integration/unit test.
    /// 
    /// The feature to search by symbol or word isn't implemented yet, I am not sure how i would implement this yet on the front-end
    /// </summary>
    public class JapaneseWordRepository
    {
        private  WebDemoDataContext context;
        private EventLog appLog;

        public JapaneseWordRepository() 
        {
            //Data context is by default initialized
            context = new WebDemoDataContext();

            EventLog appLog = new EventLog();
            appLog.Source = "WebDemo";
            //appLog.WriteEntry("An entry to the Application event log.");
        }

        /// <summary>
        /// Get all entries from the table
        /// </summary>
        /// <returns></returns>
        public List<JapaneseWord> GetAllEntries() 
        {
            List<JapaneseWord> query = new List<JapaneseWord>();
            try
            {

                query = (from jwords in context.JapaneseWordEntries
                         select new JapaneseWord
                         {
                             EntryID = jwords.EntryId,
                             Hiragana = jwords.Hiragana,
                             Romaji = jwords.Romaji,
                             AdditionalText = jwords.AdditionalText,
                             Kanji = jwords.Kanji,
                             MotherTongueTranslation = jwords.MotherTongueTranslation,
                             MotherTongueTranslationLabel = jwords.MotherTongueTranslationLabel
                         }).ToList();

            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }
            return query;
        }

        /// <summary>
        /// Get one entry from the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JapaneseWord> GetEntry(int id) 
        {

            List<JapaneseWord> query = new List<JapaneseWord>();

            try
            {
                query = (from jwords in context.JapaneseWordEntries
                         where jwords.EntryId.Equals(id)
                         select new JapaneseWord
                         {
                             EntryID = jwords.EntryId,
                             Hiragana = jwords.Hiragana,
                             Romaji = jwords.Romaji,
                             AdditionalText = jwords.AdditionalText,
                             Kanji = jwords.Kanji,
                             MotherTongueTranslation = jwords.MotherTongueTranslation,
                             MotherTongueTranslationLabel = jwords.MotherTongueTranslationLabel
                         }).ToList();
            }
            catch (Exception ex)
            {
                appLog.WriteEntry(ex.Message);
            }

            return query;
        }

        /// <summary>
        /// Delete 1 entry from the table
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEntry(int id)
        {
            var jpword = (from words in context.JapaneseWordEntries
                                  where words.EntryId.Equals(id)
                                  select words).Single();
            
            context.JapaneseWordEntries.DeleteOnSubmit(jpword);
            context.SubmitChanges();
        }

        /// <summary>
        /// Add 1 entry to the table
        /// </summary>
        public void AddEntry(JapaneseWord model) 
        {
            JapaneseWordEntry jpwe = new JapaneseWordEntry
            {
                Hiragana = model.Hiragana,
                Kanji = model.Kanji,
                AdditionalText = model.AdditionalText,
                MotherTongueTranslation = model.MotherTongueTranslation,
                MotherTongueTranslationLabel = model.MotherTongueTranslationLabel
            };

            context.JapaneseWordEntries.InsertOnSubmit(jpwe);

            context.SubmitChanges();

        }

        /// <summary>
        /// edit entry
        /// </summary>
        public void EditEntry(int id) 
        {


        }
        

    }
}