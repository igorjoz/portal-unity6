using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;

    protected override void Pick()
    {
        base.Pick();
        GameManager.instance.FreezeTime(freezeTime);
    }
}
