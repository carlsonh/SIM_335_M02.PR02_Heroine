using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingDuckStateHeroine : IHeroineState
{
    public Rigidbody rbPlayer;
    public Material vatMat;
    public float time = 0.01f;

    public void Enter(Heroine player)
    {
        rbPlayer = player.rb;

        player.UpdateObject("Ducky_Melt");//Sneaking suspicion this is terrible

        vatMat = player.activeGO.GetComponent<MeshRenderer>().material;
        vatMat.SetFloat("_speed", 0.25f);
        vatMat.SetFloat("_time", 0f);


        //time = 0.01f;//For some reason it can flash a single frame of a mid-melt, unknown why, this didn't fix.
        ///The above SetFloat _time fixed it
    }

    public void Execute(Heroine player)
    {


        //Update the melt material
        time += Time.deltaTime;
        vatMat.SetFloat("_time", Mathf.Min(3.5f, time));


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {//Go to ducking

            //Reset the melt material to not melt
            //player.activeGO.GetComponent<MeshRenderer>().material.SetFloat("_speed", 0.0f);

            player.heroineState = new DuckingStateHeroine();
            player.heroineState.Enter(player);
        }
    }
}
