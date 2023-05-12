using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerMovementInputs : IEntityState
{
    public EntityContext context { get; }
    private EntityContext helper;
    private bool running = false;

    public HandlePlayerMovementInputs(EntityContext context, EntityContext helper) {
        this.context = context;
        this.helper = helper;
    }

    public void Enter() {
        
    }

    public void Exit() {
        
    }

    // Update is called once per frame
    public void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        AnimationUpdate(inputX, inputY);
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Z Presed!");
            context.setState(new PlayerHoldAttack(context,helper));
        }

        //   Debug.Log(inputX + " " + inputY);

        context.transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime;
    }

    private void AnimationUpdate(float inX, float inY) {
        if (inX != 0 || inY != 0) {
            running = true;
        } else running = false;

        //   context.playerAnimator.SetBool("isRunning", running);
        if (running) {
            context.playerAnimator.Play("CharaRun");
        } else {
            context.playerAnimator.Play("CharaIdle");
        }

        if (inX != 0) {
            context.playerSprite.flipX = inX > 0 ? false : true;
        }


    }

}
