using UnityEngine;

public class Diamond : Pickup
{
    protected override void Pick()
    {
        base.Pick();
        GameManager.instance.AddDiamond();
    }
}
