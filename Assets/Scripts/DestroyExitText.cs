using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyExitText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FlickerEffect());
        Destroy(gameObject, 2f);
    }


    IEnumerator FlickerEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            _text.text = "";
            yield return new WaitForSeconds(0.4f);
            _text.text = "press ESC to exit";
        }

    }
}
