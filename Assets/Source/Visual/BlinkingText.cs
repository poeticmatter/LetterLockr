using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{

    private TextMeshProUGUI textUI;
    public float alphaMin = 0.5f;
    public float alphaMax = 1f;

    public float speed = 0.5f;

    private float t;
    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textUI.alpha = Mathf.Lerp(alphaMin, alphaMax, t);

        t += speed * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = alphaMax;
            alphaMax = alphaMin;
            alphaMin = temp;
            t = 0.0f;
        }
    }
}
