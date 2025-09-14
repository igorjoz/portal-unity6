using UnityEngine;

public class Key : Pickup
{
    public KeyColor keyColor;

    protected override void Pick()
    {
        base.Pick();
        GameManager.instance.AddKey(keyColor);
    }
}

public enum KeyColor
{
    Gold, Green, Red
}
