using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BulletTime : MonoBehaviour {
    [SerializeField] private float slowdownTime = 0.05f;

    private float startTimeScale;
    private float startFixedDeltaTime;

    [SerializeField] private PostProcessVolume postProcessing;
    [SerializeField] private TrailRenderer trailRenderer;

    private void Start() {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime= Time.fixedDeltaTime;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            StartBulletTime();
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            EndBulletTime();
        }
    }

    public void StartBulletTime() {
        Time.timeScale = slowdownTime;
        Time.fixedDeltaTime = startFixedDeltaTime * slowdownTime;

        postProcessing.enabled = true;
        trailRenderer.enabled = true;
    }

    public void EndBulletTime() {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;

        postProcessing.enabled = false;
        trailRenderer.enabled = false;

    }
}