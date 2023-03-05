using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ShootInDetectedPlayer : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;


    /* public override void PermorfAction(Player ship, DetectPlayer detector)
     {
         if (TargetInFOV(ship, detector))
         {
             ship.HandleMoveBody(Vector2.zero);
             ship.HandleShoot();
         }
         ship.HandleTurrentMovement(detector.Target.position);
     }

     private bool TargetInFOV(Player ship, DetectPlayer detector)
     {
         var direction = detector.Target.position - ship.aimTurrent.transfor.position;
         if(Vector2.Angle(ship.aimTurrent.transfor.right, direction)< fieldOfVisionForShooting / 2)
         {
             targetInFOV = true;
             return true;
         }
         return false;
     }

 
}*/
