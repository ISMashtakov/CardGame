using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAnimator : MonoBehaviour
{
    Vector3 _to;
    float _speed = 1f;
    bool _isZooming = false;

    public void ZoomTo(Vector3 to, float speed = -1)
    {
        if (speed > 0)
        {
            _speed = speed;
        }

        _to = to;

        if (_isZooming)
        {
            return;
        }

        StartCoroutine(Zoom());
    }

    IEnumerator Zoom()
    {
        _isZooming = true;
        while (true)
        {
            float shift = _speed * Time.deltaTime;
            if (Vector3.Distance(transform.localScale, _to) <= shift)
            {
                transform.localScale = _to;
                break;
            }

            transform.localScale += (_to - transform.localScale).normalized * shift;
            yield return new WaitForFixedUpdate();
        }
        _isZooming = false;
    }
}
