using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldAttack : IEntityState
{

    private float holdDuration;
    public EntityContext context {get;}

    public PlayerHoldAttack(EntityContext context ){
        this.context = context;
        holdDuration = 0;
    }

    public void Enter(){
        holdDuration = 0;
    }

    public void Exit(){

    }


    // Update is called once per frame
    public void Update()
    {
        holdDuration+=Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Z)){
            Debug.Log("Released with " + holdDuration + " power!");            
            context.setState(new PlayerReleaseAttack(context));
        }
    }
}
