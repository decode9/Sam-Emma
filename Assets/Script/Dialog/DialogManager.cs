﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum Character
{
    sam,
    ema,
    mom,
    dad
}
public class DialogManager : MonoBehaviour
{

    public static DialogManager instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Image dialogImage;
    public Queue<string> sentences = new Queue<string>();

    public Character talkingCharacter;

    public bool dialogRun;

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
        talkingCharacter = dialogue.character;
        sentences.Clear();
        checkCharacter();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        dialogRun = true;
        StartCoroutine(DisplayNext(sec));

    }

    void checkCharacter()
    {
        Animator animator = dialogImage.gameObject.GetComponent<Animator>();
        animator.SetBool("Sam", false);
        animator.SetBool("Emma", false);
        animator.SetBool("Mom", false);
        animator.SetBool("Dad", false);

        switch (talkingCharacter)
        {
            case Character.sam:
                animator.SetBool("Sam", true);
                break;
            case Character.ema:
                animator.SetBool("Emma", true);
                break;
            case Character.mom:
                animator.SetBool("Mom", true);
                break;
            case Character.dad:
                animator.SetBool("Dad", true);
                break;
        }
    }

    IEnumerator DisplayNext(float sec)
    {
        do
        {
            string sentence = sentences.Dequeue();
            yield return StartCoroutine(TypeSentence(sentence));
            yield return new WaitForSeconds(sec);
        } while (sentences.Count > 0);

        dialogRun = false;

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
        Animator animator = dialogImage.gameObject.GetComponent<Animator>();
        animator.SetBool("Talk", true);
        dialogText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        animator.SetBool("Talk", false);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
