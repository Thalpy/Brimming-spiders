using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : IStateful
{
    protected Spider spider;

    public State(Spider spider)
    {
        this.spider = spider;
    }


    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Search()
    {
        yield break;
    }

    public virtual IEnumerator Store()
    {
        yield break;
    }

    public virtual IEnumerator Gather()
    {
        yield break;
    }

    public virtual IEnumerator Die()
    {
        yield break;
    }

    public virtual IEnumerator Idle()
    {
        yield break;
    }

    public virtual IEnumerator Seek()
    {
        yield break;
    }

    public virtual IEnumerator Move()
    {
        yield break;
    }

    public virtual IEnumerator Wander()
    {
        yield break;
    }

}