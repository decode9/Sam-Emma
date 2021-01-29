using System.Collections;
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
    private int samHash;
    private int emmaHash;
    private int momHash;
    private int dadHash;
    private int talkHash;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
        samHash = Animator.StringToHash("Sam");
        emmaHash = Animator.StringToHash("Emma");
        momHash = Animator.StringToHash("Mom");
        dadHash = Animator.StringToHash("Dad");
        talkHash = Animator.StringToHash("Talk");
    }

    public void StartSingleDialogueByTime(Dialogue dialogue, float sec)
    {
        nameText.text = dialogue.name;
        dialogImage.sprite = dialogue.image;
        talkingCharacter = dialogue.character;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        checkCharacter();
        StartCoroutine(DisplayNext(sec));

    }

    void checkCharacter()
    {
        Animator animator = dialogImage.gameObject.GetComponent<Animator>();
        animator.SetBool(samHash, false);
        animator.SetBool(emmaHash, false);
        animator.SetBool(momHash, false);
        animator.SetBool(dadHash, false);

        switch (talkingCharacter)
        {
            case Character.sam:
                animator.SetBool(samHash, true);
                break;
            case Character.ema:
                animator.SetBool(emmaHash, true);
                break;
            case Character.mom:
                animator.SetBool(momHash, true);
                break;
            case Character.dad:
                animator.SetBool(dadHash, true);
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
