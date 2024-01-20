using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappedObjectManager
{
    public static Dictionary<string, int> snappedCounts = new Dictionary<string, int>();

    public static void RegisterAssetType(string assetType)
    {
        if (!snappedCounts.ContainsKey(assetType))
        {
            snappedCounts[assetType] = 0;
            Debug.Log("Registering Asset Type: " + assetType);
        }
    }

    public static void IncrementCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType))
        {
            snappedCounts[assetType]++;
            Debug.Log("Incrementing Count for Asset Type: " + assetType);
        }
    }

    public static void DecrementCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType) && snappedCounts[assetType] > 0)
        {
            snappedCounts[assetType]--;
            Debug.Log("DecrementCount for Asset Type: " + assetType);
        }
    }

    public static int GetCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType))
        {
            return snappedCounts[assetType];
            
        }
        return 0;
    }
    
}
