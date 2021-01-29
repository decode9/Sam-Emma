using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Image dialogImage;
    public Queue<string> sentences = new Queue<string>();

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
    }

    public void StartSingleDialogueByTime(Dialogue dialogue, float sec)
    {
        nameText.text = dialogue.name;
        dialogImage.sprite = dialogue.image;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        StartCoroutine(DisplayNext(sec));

    }

    IEnumerator DisplayNext(float sec)
    {
        do
        {
            string sentence = sentences.Dequeue();
            yield return StartCoroutine(TypeSentence(sentence));
            yield return new WaitForSeconds(sec);
        } while (sentences.Count > 0);
    }

    void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
