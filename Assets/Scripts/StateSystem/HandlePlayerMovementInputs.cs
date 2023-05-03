using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerMovementInputs : IEntityState
{
    public EntityContext context { get; }
    private bool running = false;
    public HandlePlayerMovementInputs(EntityContext context) {
        this.context = context;
    }

    public void Enter() {
        
    }

    public void Exit() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        AnimationUpdate(inputX, inputY);

        //   Debug.Log(inputX + " " + inputY);

        context.transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime;
    }

    private void AnimationUpdate(float inX, float inY) {
        if (inX != 0 || inY != 0) {
            running = true;
        } else running = false;

        context.playerAnimator.SetBool("isRunning", running);

        if (inX != 0) {
            context.playerSprite.flipX = inX > 0 ? false : true;
        }


    }

}
