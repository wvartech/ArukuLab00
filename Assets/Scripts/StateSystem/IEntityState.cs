using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityState
{
    EntityContext context { get; }
    void Enter();
    void Update();
    void Exit();
}
