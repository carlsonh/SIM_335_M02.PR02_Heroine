using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;

    public void Enter(Heroine player)
    {
        rbPlayer = player.rb;
        rbPlayer.isKinematic = true;
        player.UpdateObject("Fan");//Sneaking suspicion this is terrible

    }

    public void Execute(Heroine player)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {//Go to jumping SPECIAL

            rbPlayer.isKinematic = false;
            player.heroineState = new JumpingStateHeroine();
            player.heroineState.Enter(player);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {//Go to diving

            rbPlayer.isKinematic = false;
            player.heroineState = new DivingStateHeroine();
            player.heroineState.Enter(player);
        }
    }
}
