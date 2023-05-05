using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class EnemyPossesor : EntityContext
{    
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.closestPossesable(transform);
        Debug.Log(target.name);
        defaultState = new MoveToTarget(this);
        currentState = defaultState;
        speed = 0.35f;
        
    }

    // Update is called once per frame
    new void Update()
    {
        currentState.Update();
        if (Vector3.Distance(transform.position, target.position) < 0.45f) {
         //   Debug.Log("Within range!");
         target.GetComponent<IPossesable>().Possess();
         Destroy(gameObject);
        }


    }
}
