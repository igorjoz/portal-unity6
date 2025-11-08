using UnityEngine;

public class Key : Pickup
{
    public KeyColor keyColor;

    protected override void Pick()
    {
        base.Pick();
        GameManager.instance.AddKey(keyColor);
        Debug.Log("Podniesiono klucz: " + keyColor.ToString());
    }
}

public enum KeyColor
{
    Gold, Green, Red
}
