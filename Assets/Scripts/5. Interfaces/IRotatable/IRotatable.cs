using UnityEngine;

public interface IRotatable : IInitializable
{
    public void Rotate(Transform rotatable_obj);
}
