using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    public float Strength
    {
        get;
    }
    public void Jump();
}
