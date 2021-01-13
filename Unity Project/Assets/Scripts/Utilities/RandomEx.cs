using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomEx 
{
    public static List<int> GetRandomNumbersList( int amount)
    {
        List<int> ret = new List<int>();

        while (amount != ret.Count)
            ret.Add(-1);

        for (int i = 0; i < ret.Count; ++i)
        {
            int newRandom;
            do
            {
                newRandom = Random.Range(0, 11);
            }
            while (ret.Contains(newRandom));

            ret[i] = newRandom;
        }

        return ret;
    }
}
