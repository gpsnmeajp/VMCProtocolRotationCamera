using System;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public class Config
{
    public float Speed = 0.0f;
    public float Height = 1.6f;
    public float FOV = 60.0f;
    public float Length = 3.0f;
    public float Angle = 0.0f;
    public float X = 0.0f;
    public float Z = 0.0f;

    /// <summary>
    /// 設定をファイルから読み込みます。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <returns>Configオブジェクト</returns>
    public static Config loadConfig(string path = "")
    {
        if(path == "")
        {
            // ファイルパス未指定の場合はデフォルトのパスを使用する。
            path = Directory.GetCurrentDirectory() + @"\config.json";
        }

        if(!File.Exists(path))
        {
            // 存在しない場合は新規に作成する。
            File.WriteAllText(path, JsonUtility.ToJson(new Config()), Encoding.UTF8);
        }

        return JsonUtility.FromJson<Config>(File.ReadAllText(path, Encoding.UTF8));
    }

    /// <summary>
    /// 設定をファイルに書き込みます
    /// </summary>
    /// <param name="path">ファイルパス</param>
    public void saveConfig(string path = "")
    {
        if (path == "")
        {
            // ファイルパス未指定の場合はデフォルトのパスを使用する。
            path = Directory.GetCurrentDirectory() + @"\config.json";
        }

        File.WriteAllText(path, JsonUtility.ToJson(this), Encoding.UTF8);
    }

}
