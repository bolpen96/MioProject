using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class FindInactiveObjects
{
    public static IEnumerator FindInactiveObjectByName(string name, System.Action<GameObject> callback, float delay = 0.5f)
    {
        yield return new WaitForSeconds(delay);

        GameObject found = FindInAllScenes(name);
        callback(found);
    }

    private static GameObject FindInAllScenes(string name)
    {
        //���� �ε�� ��� ���� Ž��
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene.isLoaded)
            {
                GameObject[] rootObjects = scene.GetRootGameObjects();
                foreach(GameObject root in rootObjects)
                {
                    GameObject found = FindInChildren(root.transform, name);
                    if(found != null)
                    {
                        return found;
                    }
                }
            }
        }

        //DontDestroyOnLoad ���� Ž��
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>(true);    //true : ��� Ȱ��/��Ȱ��ȭ�� ������Ʈ Ž��
        foreach (GameObject obj in allObjects)
        {
            if(obj.name == name)
            {
                return obj;
            }
        }
        return null;

    }

    private static GameObject FindInChildren(Transform parent, string name)
    {
        foreach(Transform child in parent)
        {
            if(child.gameObject.name == name)
            {
                return child.gameObject;
            }

            GameObject found = FindInChildren(child, name);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }

    
}
