using UnityEngine;

public interface IBullet
{
    void Push(int force);
}

public interface IInventoryModel
{

}
public interface IUIBuilder
{
    void CreatePlayerInventory();
}
