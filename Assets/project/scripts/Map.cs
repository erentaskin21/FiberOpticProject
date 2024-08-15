using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Map : MonoBehaviour
{
    public string accessToken = "pk.eyJ1IjoiZXJlbnRhc2tpbiIsImEiOiJjbHp0c21zdjYyaWcxMmxxdXNncGxpbWduIn0.le1KEX1rDhU2roizGFlLbg";
    public enum style { Light, Dark, Streets, Outdoors, Satellite, SatelliteStreets };
    public style mapStyle = style.Streets;
    public enum resolution { low = 1, high = 2 };
    public resolution mapResolution = resolution.low;
    public double[] boundingBox = new double[] { 25.0, 35.0, 45.0, 42.0 }; //[lon(min), lat(min), lon(max), lat(max)]

    private string[] styleStr = new string[] { "light-v10", "dark-v10", "streets-v11", "outdoors-v11", "satellite-v9", "satellite-streets-v11" };
    private string url = "";
    private Material mapMaterial;
    private int mapWidthPx = 1280;
    private int mapHeightPx = 1280;
    private double planeWidth;
    private double planeHeight;

    // Start is called before the first frame update
    void Start()
    {
        MatchPlaneToScreenSize();
        if (gameObject.GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<MeshRenderer>();
        }
        mapMaterial = new Material(Shader.Find("Unlit/Texture"));
        gameObject.GetComponent<MeshRenderer>().material = mapMaterial;
        StartCoroutine(GetMapbox());
    }

    // Update is called once per frame void Update(){ }

    public void GenerateMapOnClick()
    {
        StartCoroutine(GetMapbox());
    }

    IEnumerator GetMapbox()
    {
        url = "https://api.mapbox://styles/erentaskin/clzv7e28u00k501qtgqi26h9e" + styleStr[(int)mapStyle] + "/static/[" + boundingBox[0] + "," + boundingBox[1] + "," + boundingBox[2] + "," + boundingBox[3] + "]/" + mapWidthPx + "x" + mapHeightPx + "?" + "access_token=" + accessToken;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", ((DownloadHandlerTexture)www.downloadHandler).texture);
        }
    }

    //Set the scale of plane to match the screen size
    private void MatchPlaneToScreenSize()
    {
        double planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        double planeHeightScale = (2.0 * Math.Tan(0.5f * Camera.main.fieldOfView * (Math.PI / 180)) * planeToCameraDistance) / 10.0;
        double planeWidthScale = planeHeightScale * Camera.main.aspect;
        gameObject.transform.localScale = new Vector3((float)planeWidthScale, 1, (float)planeHeightScale);
        if (Camera.main.aspect > 1)
        {
            mapWidthPx = 1280;
            mapHeightPx = (int)Math.Round(1280 / Camera.main.aspect);
        }
        else
        {
            mapHeightPx = 1280;
            mapWidthPx = (int)Math.Round(1280 / Camera.main.aspect);
        }
    }
}
