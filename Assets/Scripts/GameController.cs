using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    LogHealthSystem system;

    private void Start()
    {
        var contexsts = Contexts.sharedInstance;
        var e = contexsts.game.CreateEntity();
        e.AddHealth(100);

        system = new LogHealthSystem(contexsts);
    }
    private void Update()
    {
        system.Execute();
    }
}
