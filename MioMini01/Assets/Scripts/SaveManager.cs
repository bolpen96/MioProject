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
        //플레이어 정보 및 인벤토리에서 불러오는 정보
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
        //파일이 존재하는지 체크
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

    /* 변환 섹터 */
    //세이브 데이터를 json string으로 변환
    static string DataToJson(SaveData sd)
    {
        string jsonData = JsonUtility.ToJson(sd);
        return jsonData;
    }

    //json string을 SaveData로 변환
    static SaveData JsonToData(string jsonData)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonData);
        return sd;
    }

    /* 저장 및 불러오기 */
    //json string을 파일로 저장
    static void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            //파일로 저장할 수 있게 바이트화
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            //bytes의 내용물을 0 ~ max 길이까지 fs에 복사
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    //파일 불러오기
    static string LoadFile(string path)
    {
        using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            //파일을 바이트화 했을 때 담을 변수를 제작
            byte[] bytes = new byte[(int)fs.Length];

            //파일스트림으로 부터 바이트 추출
            fs.Read(bytes, 0, (int)fs.Length);

            //추출한 바이트를 json string으로 인코딩
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
     //저장할 주소를 반환
     static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, " save.abcd");
    }
}
