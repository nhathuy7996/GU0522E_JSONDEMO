using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class JSONDemo : MonoBehaviour
{
    string jsonData;

    // Start is called before the first frame update
    void Start()
    {
        jsonData = PlayerPrefs.GetString("DATA");
        var dataParsed = JSON.Parse(jsonData).AsArray;


        foreach (JSONNode data in dataParsed)
        {
            Debug.LogError(data["name"]);
        }

        //DataUser dataParsed = JsonUtility.FromJson<DataUser>(jsonData);
        //Debug.LogError(dataParsed.HP);

        //DataUser data = new DataUser();

        //data.name = "Hoang";
        //data.level = 1;
        //data.HP = 80;

        //Debug.LogError(JsonUtility.ToJson(data));

        StartCoroutine(GetRequest("https://gu0522e-json-default-rtdb.asia-southeast1.firebasedatabase.app/.json"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                   
                    break;
                case UnityWebRequest.Result.ProtocolError:
                   
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}


