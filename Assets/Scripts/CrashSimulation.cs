using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Diagnostics;
public class CrashSimulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaiseException();
        StartCoroutine(RaiseForceCrash());
        //StartCoroutine(RaiseRecursiveCrash());
    }
    private void RaiseException()
    {
        try
        {
            throw new Exception("simulating crash");
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }
    }
    private IEnumerator RaiseForceCrash()
    {
        yield return new WaitForSeconds(1f);
        Utils.ForceCrash(ForcedCrashCategory.Abort);
    }
    private IEnumerator RaiseRecursiveCrash()
    {
        yield return new WaitForSeconds(1f);
        Demo();
    }
    private void Demo()
    {
        Demo();
    }
}