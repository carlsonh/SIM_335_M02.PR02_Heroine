using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;

    public float timeJumped;
    public float timeDelta = 1f;
    public void Enter(Heroine player)
    {
        rbPlayer = player.rb;
        player.UpdateObject("Melt");//Sneaking suspicion this is terrible
        timeJumped = Time.fixedTime;

    }
    public void Execute(Heroine player)
    {
        if (Time.fixedTime > timeJumped + timeDelta && rbPlayer.position.y <= 0.6f)
        {//Exiting this state

            player.heroineState = new StandingStateHeroine();
            player.heroineState.Enter(player);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {//Go to diving

            player.heroineState = new DivingStateHeroine();
            player.heroineState.Enter(player);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {//Go to Hover

            player.heroineState = new HoveringStateHeroine();
            player.heroineState.Enter(player);
        }
    }
}
