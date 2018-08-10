﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager
{

    public static List<AssetBundle> AsyncListAssetBundle = new List<AssetBundle>();
    /// <summary>
    /// 加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public static T LoadData<T>(string resPath) where T : Object
    {

        T resData = Resources.Load(resPath, typeof(T)) as T;
        return resData;
    }

    /// <summary>
    /// 加载asset资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assetPath"></param>
    /// <param name="objName"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    public static T LoadAssetBundles<T>(string assetPath, string objName) where T : Object
    {
        assetPath = assetPath.ToLower();
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundles/" + assetPath);
        T data = assetBundle.LoadAsset<T>(objName);
        assetBundle.Unload(false);
        return data;
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public static T LoadAsyncData<T>(string resPath) where T : Object
    {
        T resData = Resources.LoadAsync(resPath, typeof(T)) as T;
        return resData;
    }

    /// <summary>
    /// 加载本地文件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public static WWW LoadLocationData(string resPath)
    {
        string filePath = "file://" + resPath;
        WWW www = new WWW(filePath);
        return www;
    }

    /// <summary>
    /// 异步加载本地图片
    /// </summary>
    /// <param name="imagePath"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncLocationImage(string imagePath, Image image)
    {
        return LoadAsyncBaseImage(1, imagePath, image);
    }

    /// <summary>
    /// 异步加载网络图片
    /// </summary>
    /// <param name="imagePath"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncHttpImage(string imagePath, Image image)
    {
        return LoadAsyncBaseImage(0, imagePath, image);
    }

    /// <summary>
    /// 基础加载
    /// </summary>
    /// <param name="type">1.本地   0.网络</param>
    /// <param name="imagePath"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncBaseImage(int type, string imagePath, Image image)
    {
        string filePath = "file://" + imagePath;
        if (type == 1)
        {
            filePath = "file://" + imagePath;
        }
        else
        {
            filePath = imagePath;
        }
        WWW www = new WWW(filePath);
        yield return www;
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// 异步加载资源图片
    /// </summary>
    /// <param name="imagePath"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncDataImage(string imagePath, Image image)
    {
        ResourceRequest res = Resources.LoadAsync<Sprite>(imagePath);
        yield return res;
        Sprite imageSp = res.asset as Sprite;
        image.sprite = imageSp;
        // image.sprite = Sprite.Create(imageTX, new Rect(0, 0, imageTX.width, imageTX.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// 异步加载资源图片
    /// </summary>
    /// <param name="imagePath"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public async static Task LoadAsyncDataImageByAwait(string imagePath, Image image)
    {
        var res = await Resources.LoadAsync<Sprite>(imagePath);
        Sprite imageSp = res as Sprite;
        image.sprite = imageSp;

    }

    /// <summary>
    /// 异步加载asset资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assetPath"></param>
    /// <param name="objName"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncAssetBundles<T>(string assetPath, string objName, LoadCallBack<T> callBack) where T : Object
    {
        assetPath = assetPath.ToLower();
        AssetBundleCreateRequest assetRequest = AssetBundle.LoadFromFileAsync(Application.dataPath + "/AssetBundles/" + assetPath);
        yield return assetRequest;
        if (assetRequest == null && callBack != null)
            callBack.loadFail("加载失败：指定assetPath下没有该资源");
        AsyncListAssetBundle.Add(assetRequest.assetBundle);
        AssetBundleRequest objRequest = assetRequest.assetBundle.LoadAssetAsync<T>(objName);
        yield return objRequest;
        AsyncListAssetBundle.Remove(assetRequest.assetBundle);
        assetRequest.assetBundle.Unload(false);
        if (objRequest == null && callBack != null)
            callBack.loadFail("加载失败：指定assetPath下没有该名字的obj");
        T obj = objRequest.asset as T;
        if (obj != null && callBack != null)
            callBack.loadSuccess(obj);

    }

    /// <summary>
    /// 异步加载asset并设置图片
    /// </summary>
    /// <param name="assetPath"></param>
    /// <param name="objName"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public static IEnumerator LoadAsyncAssetBundlesImage(string assetPath, string objName, Image image)
    {
        assetPath = assetPath.ToLower();
        AssetBundleCreateRequest assetRequest = AssetBundle.LoadFromFileAsync(Application.dataPath + "/AssetBundles/" + assetPath);
        yield return assetRequest;
        AsyncListAssetBundle.Add(assetRequest.assetBundle);
        AssetBundleRequest objRequest = assetRequest.assetBundle.LoadAssetAsync<Sprite>(objName);
        yield return objRequest;
        AsyncListAssetBundle.Remove(assetRequest.assetBundle);
        assetRequest.assetBundle.Unload(false);
        Sprite sp = objRequest.asset as Sprite;
        image.sprite = sp;
     
    }

    /// <summary>
    /// 卸载所有asset
    /// </summary>
    public static void clearAssetBundles()
    {
        foreach (AssetBundle itemAsset in AsyncListAssetBundle) {
            itemAsset.Unload(false);
        }
        AsyncListAssetBundle.Clear();
    }
    /// <summary>
    /// 异步加载回调
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface LoadCallBack<T>
    {
        void loadSuccess(T data);
        void loadFail(string msg);
    }
}