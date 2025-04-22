using UnityEngine;

public class PressurePlate : Triggerable
{
    private bool triggered = false;
    public override void Action()
    {
        GameManager.Instance.SetPlayerState(GameManager.PlayerState.Qualified);
        GetComponent<Animator>().Play("Anim_Plate");
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !triggered)
        {
            triggered = true;
            Action();
        }
    }
}
