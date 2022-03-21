using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected ZombieStateMachine stateMachine;

    public float updateInterval { get; protected set; }

    protected State(ZombieStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        updateInterval -= 1f;
    }

    public virtual void Start()
    {

    }

    public virtual void IntervalUpdate()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
