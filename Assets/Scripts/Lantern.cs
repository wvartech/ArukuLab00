using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : EntityContext, IPossesable, IDamageable
{

    private int _chargeLevel = 0;

    private int CHARGELEVEL {
      get{return _chargeLevel;}
      set{
        _chargeLevel = value;
        Debug.Log("Charge Level Changed");
        switch(_chargeLevel){
          case 0: 
          playerAnimator.Play("Lantern0");
          break;
          case 1:
          playerAnimator.Play("Lantern1");
          break;
          default:
          playerAnimator.Play("Lantern2");
          break;
        }
      }
    }

    public Team team {get; set;}

    void Start()
    {
      team = Team.Enemy;
      target = GameManager.instance.getPlayer();
    }

    // Update is called once per frame
    new void Update()
    {
      if (CHARGELEVEL > 0){
        //Do attack stuff
      }
        
    }

    public void Possess(){
        CHARGELEVEL++;
        Debug.Log("Reached lantern!");
    }

    public void isHit(float non){
      if (CHARGELEVEL == 0) return;

    }
    


}
