using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockManager : MonoBehaviour
{
    public Image[] lockImages;
    private bool[] locks;

    private int lockCount = 1;
    public int LockCount { get; set; }


    private void UpdateLockUI()
    {
        for (int i = 0; i < locks.Length; i++)
        {
            lockImages[i].enabled = locks[i];
        }

    }

    public void RandomizeLock()
    {
        bool[] newLocks = new bool[] { false, false, false, false, false };
        int randomIndex;
        while (IsSameArray(newLocks, locks) || CountLocks(newLocks) != lockCount)
        {
            randomIndex = Random.Range(0, newLocks.Length);
            newLocks[randomIndex] = !newLocks[randomIndex];
        }
        locks = newLocks;
        UpdateLockUI();
    }

    private int CountLocks(bool[] test)
    {
        int count = 0;
        for (int i = 0; i < test.Length; i++)
        {
            count += test[i] ? 1 : 0;
        }
        return count;
    }

    private bool IsSameArray(bool[] a, bool[] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool IsIndexLocked(int i)
    {
        return locks[i];
    }


    void Start()
    {
        locks = new bool[] { false, false, false, false, false };

    }

}
