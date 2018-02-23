﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameCameraControlCpt : MonoBehaviour
{
    //鼠标滚轮操作关键词
    private static string MouseScrollWheel = "Mouse ScrollWheel";

    //镜头放大最大值
    public float zoomOutMax = 50f;
    //镜头放大增加量
    public float zoomOutMaxAdd = 5f;


    //镜头缩小最小值
    public float zoomInMax = 5f;
    //镜头缩小增加量
    public float zoomInMaxAdd = 5f;

    //镜头移动横向最大距离
    public float cameraMoveWithMax = 0;
    //镜头移动纵向最大距离
    public float cameraMoveHighMax = 0;
    //镜头移动缩放比例
    private float cameraMoveScale = 5f;

    //镜头移动增量
    private float cameraMoveAdd = 5f;

    //游戏镜头
    private Camera gameCamera;

    void Start()
    {
        gameCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (gameCamera == null)
        {
            LogUtil.log("没有游戏镜头");
            return;
        }
        //Zoom out
        if (Input.GetAxis(MouseScrollWheel) < 0)
        {
            if (Camera.main.orthographicSize <= zoomOutMax)
                Camera.main.orthographicSize += zoomOutMaxAdd;
        }
        //Zoom in
        if (Input.GetAxis(MouseScrollWheel) > 0)
        {
            if (Camera.main.orthographicSize >= zoomInMax)
                Camera.main.orthographicSize -= zoomInMaxAdd;
        }
        //CameraMove
        if (Input.GetKey(KeyCode.A))
        {
            moveCamera(new Vector2(-cameraMoveAdd * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveCamera(new Vector2(cameraMoveAdd * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveCamera(new Vector2(0, cameraMoveAdd * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveCamera(new Vector2(0, -cameraMoveAdd * Time.deltaTime));
        }
    }

    //设置镜头的缩放大小
    public void setCameraOrthographicSize(float orthographicSize)
    {
        Camera.main.orthographicSize = orthographicSize;
    }

    public void moveCamera(Vector3 move)
    {
        if (gameCamera == null)
            return;

        float moveAfterX = transform.position.x + move.x;
        float moveAfterY = transform.position.y + move.y;

        if (Mathf.Abs(moveAfterX) >= ((cameraMoveWithMax / 2f) * cameraMoveScale))
        {
            move.x = 0f;
        }
        if (Mathf.Abs(moveAfterY) >= ((cameraMoveHighMax / 2f) * cameraMoveScale))
        {
            move.y = 0f;
        }
        gameCamera.transform.Translate(move);

    }

}
