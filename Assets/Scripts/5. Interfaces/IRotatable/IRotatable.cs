using UnityEngine;

public interface IRotatable
{
    public void RotateTo(float rotation_x, float rotation_y, float rotation_z);
    public void RotateTo(float rotation_x, float rotation_y, float rotation_z, float rotate_speed);
}
