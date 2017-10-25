using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : AgentBehavior {


    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linerar = target.transform.position - transform.position;
        steering.linerar.Normalize();
        steering.linerar = steering.linerar * agent.maxAccel;
        return steering;
    }

}
