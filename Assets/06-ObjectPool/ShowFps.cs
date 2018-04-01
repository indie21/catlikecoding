using UnityEngine;

public class ShowFps : MonoBehaviour
{

    public int _fpsTarget;
    public float _updateInterval = 0.5f;
    private float lastInterval;
    private int _frames;
    private float fps;


    void Start()
    {
        //设置帧率
        //Application.targetFrameRate = 60;
        lastInterval = Time.realtimeSinceStartup;
        _frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ++_frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow >= lastInterval + _updateInterval)
        {
            fps = _frames / (timeNow - lastInterval);
            _frames = 0;
            lastInterval = timeNow;
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(200, 40, 100, 30), fps.ToString());
    }
}
