using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damager{ //bullets, warning zone, and any other attack element that needs to be coordinated via timeline
    void Activate(); //from spawning, the object begins it's action
    void Trigger(); //from it's action, the object reacts
    void Clean(); //whatever the object needs before killing itself
}
