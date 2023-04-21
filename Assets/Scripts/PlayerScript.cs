using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private SpriteRenderer playerSprite;
    private bool running;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        AnimationUpdate(inputX, inputY);

     //   Debug.Log(inputX + " " + inputY);

        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime;
        
    }

    private void AnimationUpdate(float inX, float inY) {
        if (inX != 0 ||  inY != 0) {
            running = true;
        } else running = false;

        playerAnimator.SetBool("isRunning", running);

        if (inX != 0) {
            playerSprite.flipX = inX >0? false: true;
        }


    }


}
