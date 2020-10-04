using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;
    public void Enter(Heroine player)
    {
        rbPlayer = player.rb;
        //rbPlayer.transform.localScale *= 0.5f;

        player.UpdateObject("Ducky_Melt");//Sneaking suspicion this is terrible

    }

    public void Execute(Heroine player)
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {//Exiting this state
            rbPlayer.transform.localScale = Vector3.one;


            player.heroineState = new StandingStateHeroine();
            player.heroineState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {//Melty Duck
            rbPlayer.transform.localScale = Vector3.one;

            player.heroineState = new MeltingDuckStateHeroine();
            player.heroineState.Enter(player);
        }
    }
}
