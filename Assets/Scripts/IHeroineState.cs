using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeroineState
{
    void Enter(Heroine player);
    void Execute(Heroine player);
}
