using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;
    public float jumpSpeed = 8f;


    public void Enter(Heroine player)
    {
        rbPlayer = player.rb;
        player.UpdateObject("Melt");//Sneaking suspicion this is terrible

    }

    public void Execute(Heroine player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {//Exiting this state to JUMPING
            rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);//Having it here fixes an issue going to Jump from Hover retriggering jump

            player.heroineState = new JumpingStateHeroine();
            player.heroineState.Enter(player);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {//Exiting this state to DUCKING

            player.heroineState = new DuckingStateHeroine();
            player.heroineState.Enter(player);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            player.heroineState = new MeltingStateHeroine();
            player.heroineState.Enter(player);
        }
    }
}
