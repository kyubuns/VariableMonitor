using System.Collections;
using UnityEngine;
using VariableMonitor;

public class Sample : MonoBehaviour
{
    public IEnumerator Start()
    {
        Debug.Log("Start");

        for (var i = 0; i < 10; ++i)
        {
            Debug.Log($"Update {i}");
            VariableLogger.Log("VariableA", i);
            yield return new WaitForSeconds(1f);
        }
    }
}
