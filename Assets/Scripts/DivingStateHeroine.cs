using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;

    public float diveSpeed = 12f;

    public void Enter(Heroine player)
    {//Player must be in the air
        rbPlayer = player.rb;
        rbPlayer.AddForce(Vector3.down * diveSpeed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Diving Coll fired");
    }

    public void Execute(Heroine player)
    {
        if (rbPlayer.velocity.magnitude <= 0.01f)
        {//Exiting this state

            player.heroineState = new StandingStateHeroine();
            player.heroineState.Enter(player);
        }

    }
}
