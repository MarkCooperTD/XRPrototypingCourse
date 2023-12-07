using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class KeywordRecognizerScript : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        // Add your keywords and associated actions
        keywords.Add("next", NextAction);
        keywords.Add("back", BackAction);
        keywords.Add("skill", ActivateSkill);

        // Initialize the KeywordRecognizer with the keywords dictionary
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register the OnPhraseRecognized method to be called when a keyword is recognized
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;

        // Start keyword recognition
        keywordRecognizer.Start();
    }

    void OnDestroy()
    {
        // Stop and destroy the KeywordRecognizer when the script is destroyed
        if (keywordRecognizer != null)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            // Invoke the associated action when a keyword is recognized
            keywordAction.Invoke();
        }
    }

    void NextAction()
    {
        Debug.Log("Next keyword recognized!");
        // Add your "next" functionality here
    }

    void BackAction()
    {
        Debug.Log("Back keyword recognized!");
        // Add your "back" functionality here
    }
    void ActivateSkill()
    {
        Debug.Log("Skill Activated!");
        // Add your "skill" functionality here
    }
}

