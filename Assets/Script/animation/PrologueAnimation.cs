using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueAnimation : Animation
{
    [HideInInspector]
    public bool run = true;
    public Dialogue[] dialogues;
    public GameObject smoke;


    // Start is called before the first frame update
    void Start()
    {
        animatorManager = GetComponent<AnimatorManager>();
        DialogManager.instance.StartSingleDialogueByTime(dialogues[0], 3f);
    }

    // Update is called once per frame
    void Update()
    {

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
            if (!collision)
            {
                x = 0;
                y = 0.5f;
            }
            if (collision) x = 0.25f;

            float angle = Mathf.Atan2(x * -1, y) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // ---- Movimiento de Cuerpo Rigido ---- //
            Vector2 velocityVector = new Vector2(x, y) * 5;
            player.GetComponent<Rigidbody2D>().velocity = velocityVector;
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
    }

}
