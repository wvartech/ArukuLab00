using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : IEntityState
{
    public EntityContext context {get;private set;}

    public void Enter(){}

    public void Exit(){}

    // Update is called once per frame
    public void Update()
    {
        
    }
}
