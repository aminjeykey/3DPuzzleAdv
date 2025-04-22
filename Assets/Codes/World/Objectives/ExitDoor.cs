using UnityEngine;

public class ExitDoor : Triggerable
{
    // notifies game manager that player has triggered the exit level
    public override void Action()
    {
        GameManager.Instance.FinishedLevel();
    }

    // listens for player collision
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Action();
        }
    }
}
