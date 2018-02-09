﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawBean
{
    /// <summary>
    /// 拼图对象
    /// </summary>
    private GameObject jigsawGameObj;

    /// <summary>
    /// 拼图样式
    /// </summary>
    private JigsawStyleEnum jigsawStyle;

    /// <summary>
    /// 顶点坐标
    /// </summary>
    private List<Vector3> listVertices;
    
    /// <summary>
    /// 图片UV坐标点集合
    /// </summary>
    private List<Vector2> listUVPostion;

    /// <summary>
    /// 相对于图片的XY的标记
    /// </summary>
    private Vector2 markLocation;

    /// <summary>
    /// 所有边对应的凹凸情况
    /// </summary>
    private JigsawBulgeEnum[] listBulge;

    /// <summary>
    /// 拼图图片
    /// </summary>
    private Texture2D sourcePic;

    public GameObject JigsawGameObj
    {
        get
        {
            return jigsawGameObj;
        }

        set
        {
            jigsawGameObj = value;
        }
    }

    public JigsawStyleEnum JigsawStyle
    {
        get
        {
            return jigsawStyle;
        }

        set
        {
            jigsawStyle = value;
        }
    }

    public List<Vector3> ListVertices
    {
        get
        {
            return listVertices;
        }

        set
        {
            listVertices = value;
        }
    }

    public List<Vector2> ListUVPostion
    {
        get
        {
            return listUVPostion;
        }

        set
        {
            listUVPostion = value;
        }
    }

    public Vector2 MarkLocation
    {
        get
        {
            return markLocation;
        }

        set
        {
            markLocation = value;
        }
    }

    public JigsawBulgeEnum[] ListBulge
    {
        get
        {
            return listBulge;
        }

        set
        {
            listBulge = value;
        }
    }

    public Texture2D SourcePic
    {
        get
        {
            return sourcePic;
        }

        set
        {
            sourcePic = value;
        }
    }
}