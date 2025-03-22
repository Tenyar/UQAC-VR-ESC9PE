using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public bool anomaly;

    public string GetName()
    {
        return name;
    }

    public bool IsAnomalie()
    {
        return anomaly;
    }
}