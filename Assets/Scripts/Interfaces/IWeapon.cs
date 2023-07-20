using UnityEngine;

public interface IWeapon
{
    Transform Transform { get; }
    void Attack();
}
public interface IHotWeapon : IWeapon
{
    void Reload();
}
