using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimator: MonoBehaviour
{
    Vector3 _to;
    float _speed = 1f;
    bool _isMoving = false;

    public void MoveTo(Vector3 to, float speed = -1)
    {
        if (speed > 0)
        {
            _speed = speed;
        }

        _to = to;

        if (_isMoving)
        {
            return;
        }

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        _isMoving = true;
        while (true) {
            float shift = _speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, _to) <= shift)
            {
                transform.position = _to;
                break;
            }

            transform.position += (_to - transform.position).normalized * shift;
            yield return new WaitForFixedUpdate();
        }
        _isMoving = false;
    }
}
