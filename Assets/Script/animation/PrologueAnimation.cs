using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrologueAnimation : Animation
{
    [HideInInspector]
    public bool run = true;

    public UnityEvent onInteraction;
    public Dialogue[] dialogues;
    public GameObject smoke;
    private int dialogCount = 0;

    public Transform scene;

    void Start()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }

    void Update()
    {
        StartCoroutine(WaitBeforeBegin());
    }

    private void CheckDialog()
    {

        DialogManager dialogManager = DialogManager.instance;
        if (!dialogManager.dialogRun && dialogues.Length > dialogCount)
        {
            dialogManager.StartSingleDialogueByTime(dialogues[dialogCount], 2.985f);
            dialogCount += 1;
        }
        if (dialogues.Length <= dialogCount && dialogManager.sentences.Count == 0) collision = true;
    }

    private void FixedUpdate()
    {
        checkAnimationStart();
    }

    void checkAnimationStart()
    {
        if (animatorManager.start && animatorManager.stage == "prologue") moveCharacter();
        if (!run) StopPlayer();
    }

    private void moveCharacter()
    {
        if (run)
        {
            if (collision) player.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, -0.15f) * 2.5f;

            scene.transform.Rotate(0, 10f * Time.deltaTime, 0);

            //float angle = Mathf.Atan2(x * -1, y) * Mathf.Rad2Deg;
            //player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // ---- Movimiento de Cuerpo Rigido ---- //
            //Vector2 velocityVector = new Vector2(x, y) * 2.05f;
            //player.GetComponent<Rigidbody2D>().velocity = velocityVector;
            return;
        }
    }

    void StopPlayer()
    {
        x = 0;
        y = 0;
        Vector2 newVector = new Vector2(x, y) * 5;
        player.GetComponent<Rigidbody2D>().velocity = newVector;
    }

    public void DisplaySmoke()
    {
        GameObject smokeObject = Instantiate(smoke, player.transform.position, Quaternion.identity);
        StartCoroutine(WaitEnd());
    }

    IEnumerator WaitEnd(){
        yield return new WaitForSeconds(3);
        onInteraction.Invoke();
    }

    IEnumerator WaitBeforeBegin()
    {
        yield return new WaitForSeconds(.5f);

        CheckDialog();
    }
}
