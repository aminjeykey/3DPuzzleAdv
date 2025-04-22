using UnityEngine;

public class Key : Triggerable
{
    // notifies game manager that player is qualified for exit
    public override void Action()
    {
        GameManager.Instance.SetPlayerState(GameManager.PlayerState.Qualified);
    }

    // listens for player collision
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Action();
            Destroy(this.gameObject);
        }
    }
}
