using UnityEngine;

// parent class for all triggerables
public abstract class Triggerable : MonoBehaviour
{
    // action to be done after collision
    public abstract void Action();

    // collision listener
    public abstract void OnCollisionEnter(Collision collision);
    

}
