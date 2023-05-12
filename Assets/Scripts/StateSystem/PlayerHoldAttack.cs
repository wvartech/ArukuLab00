using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldAttack : IEntityState
{

    private float holdDuration;
    public EntityContext context {get;}
    private EntityContext helper;

    public PlayerHoldAttack(EntityContext context, EntityContext helper){
        this.context = context;
        holdDuration = 0;
        this.helper = helper;
        if (Vector3.Distance(context.transform.position,helper.transform.position) < 1){
            helper.setState(new AimingMode(context,helper));
        }
    }

    public void Enter(){
        holdDuration = 0;
        context.playerAnimator.Play("CharaCharge");
        
    }

    public void Exit(){

    }


    // Update is called once per frame
    public void Update()
    {
        holdDuration+=Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("Released with " + holdDuration + " power!");            
            context.setState(new PlayerReleaseAttack(context,holdDuration));
        }
    }
}
