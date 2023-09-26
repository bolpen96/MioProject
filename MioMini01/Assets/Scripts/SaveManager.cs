using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class SaveManager : MonoBehaviour
{
    private static readonly string privateKey = "230912eirn9q8r4nqng5089nq24gn";

    public static void Save()
    {
        //�÷��̾� ���� �� �κ��丮���� �ҷ����� ����
        SaveData sd = new SaveData(
            GameManager.Instance.PlayerName,
            GameManager.Instance.Level,
            GameManager.Instance.Exp,
            GameManager.Instance.Score);

        string jsonString = DataToJson(sd);
        string encryptString = Encrypt(jsonString);
        SaveFile(encryptString);
    }

    public static SaveData Load()
    {
        //������ �����ϴ��� üũ
        if(!File.Exists(GetPath()))
        {
            Debug.Log("you don't have save file");
            return null;
        }

        GameManager.Instance.State = 1;


        string encryptData = LoadFile(GetPath());
        string decryptData = Decrypt(encryptData);

        Debug.Log(decryptData);

        SaveData sd = JsonToData(decryptData);
        return sd;
    }

    /* ��ȯ ���� */
    //���̺� �����͸� json string���� ��ȯ
    static string DataToJson(SaveData sd)
    {
        string jsonData = JsonUtility.ToJson(sd);
        return jsonData;
    }

    //json string�� SaveData�� ��ȯ
    static SaveData JsonToData(string jsonData)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonData);
        return sd;
    }

    /* ���� �� �ҷ����� */
    //json string�� ���Ϸ� ����
    static void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            //���Ϸ� ������ �� �ְ� ����Ʈȭ
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            //bytes�� ���빰�� 0 ~ max ���̱��� fs�� ����
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    //���� �ҷ�����
    static string LoadFile(string path)
    {
        using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            //������ ����Ʈȭ ���� �� ���� ������ ����
            byte[] bytes = new byte[(int)fs.Length];

            //���Ͻ�Ʈ������ ���� ����Ʈ ����
            fs.Read(bytes, 0, (int)fs.Length);

            //������ ����Ʈ�� json string���� ���ڵ�
            string jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            return jsonString;
        }
    }

    /**/
    private static string Encrypt(string data)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateEncryptor();
        byte[] resultArray = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Text.Encoding.UTF8.GetString(resultArray);
    }

    private static string Decrypt(string data)
    {
        byte[] bytes = System.Convert.FromBase64String(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateDecryptor();
        byte[] resultArray = ct.TransformFinalBlock(bytes,0,bytes.Length);
        return System.Text.Encoding.UTF8.GetString(resultArray);
    }

    private static RijndaelManaged CreateRijndaelManaged()
    {
        byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(privateKey);
        RijndaelManaged result = new RijndaelManaged();

        byte[] newKeysArray = new byte[16];
        System.Array.Copy(keyArray, 0, newKeysArray, 0, 16);

        result.Key = newKeysArray;
        result.Mode = CipherMode.ECB;
        result.Padding = PaddingMode.PKCS7;
        return result;
;    }

     /**/
     //������ �ּҸ� ��ȯ
     static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, " save.abcd");
    }
}
