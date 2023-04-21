using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    private Vector3 target;
    [SerializeField]
    private Transform playerTarget;
    private Vector3 startPosition;
    [Range(0f, 1f)]
    private float lerper = 1;
    private bool waiting = false;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LerpTo(playerTarget);
    }

    public void setTarget(Transform player) {
        playerTarget = player;
    }

    private void LerpTo(Transform targetTransform) {

        //if already too close, switch to waiting
        if (Vector3.Distance(transform.position, targetTransform.position) < 0.5f) {
            lerper = 0.5f;
            waiting = true;
            return; }

        //if not waiting and still not at destination of Lerp, keep moving
        if (lerper < 1 && !waiting) {
            lerper += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, this.target, lerper - 0.15f);
        } else { //otherwise reset to waiting state and wait for 1 second (time till lerper goes back to 0)
            waiting = true;
            lerper -= Time.deltaTime;
            if(lerper <= 0) { //stop waiting, and take snapshot of current and target position to lerp to
                waiting = false;
                startPosition = transform.position;
                this.target = targetTransform.position;
                AnimationUpdate(this.target);
            }
        }
    }

    private void AnimationUpdate(Vector3 target) {
        float direction = transform.position.x - target.x;
        if (direction != 0) {
            spriteRenderer.flipX = direction >0? true : false;
        }

    }

}
