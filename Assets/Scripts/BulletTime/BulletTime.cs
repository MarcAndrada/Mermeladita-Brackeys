using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BulletTime : MonoBehaviour {
    [SerializeField] private float slowdownTime = 0.05f;
    [SerializeField] private float timeScale = 0.02f;

    private void FixedUpdate() {
        BulletTimeFunction();
    }

    public void BulletTimeFunction() {
        Time.timeScale = slowdownTime;
        Time.fixedDeltaTime = Time.timeScale * timeScale;
    }
}
