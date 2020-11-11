/*
MIT License

Copyright (c) 2020 gpsnmeajp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour
{
    public Slider speed;
    public Slider height;
    public Slider fov;
    public Slider length;
    public Slider Angle;
    public Slider X;
    public Slider Z;

    public Transform cameraBase;
    public Camera cam;
    public CameraPositionSend campos;

    public float rot = 0f;
    
    private Config config;

    void Start()
    {
        config = Config.loadConfig();

        speed.value = config.Speed;
        height.value = config.Height;
        fov.value = config.FOV;
        length.value = config.Length;
        Angle.value = config.Angle;
        X.value = config.X;
        Z.value = config.Z;
    }

    void Update()
    {
        Application.targetFrameRate = 60;
        cameraBase.localRotation = Quaternion.Euler(0, rot, 0);
        cameraBase.localPosition = new Vector3(X.value, height.value, Z.value);
        cam.fieldOfView = fov.value;
        campos.fov = fov.value;
        cam.transform.localPosition = new Vector3(0, 0, -length.value);
        cam.transform.localRotation = Quaternion.Euler(Angle.value, 0, 0);


        rot += speed.value;
    }

    private void OnApplicationQuit()
    {
        // Configの保存
        config.Speed = speed.value;
        config.Height = height.value;
        config.FOV = fov.value;
        config.Length = length.value;
        config.Angle = Angle.value;
        config.X = X.value;
        config.Z = Z.value;

        config.saveConfig();
    }
}
