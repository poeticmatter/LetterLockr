using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockManager : MonoBehaviour
{
    public Image[] lockImages;
    private int lockIndex = 0;
    public int LockIndex
    {
        get { return lockIndex; }
        set
        {
            ValueChanged(lockIndex, value);
            lockIndex = value;
        }
    }
    private void ValueChanged(int oldV, int newV)
    {
        lockImages[oldV].enabled = false;
        lockImages[newV].enabled = true;
    }

    public void RandomizeLock()
    {
        LockIndex = (lockIndex + Random.Range(1, lockImages.Length - 1)) % lockImages.Length;
    }

    void Start()
    {
        LockIndex = Random.Range(0, lockImages.Length);
    }

    /*     void Update () {
            if (Time.frameCount % 100 == 0) {
                Debug.Log(lockIndex);
                RandomizeLock();
            }

        } */
}
