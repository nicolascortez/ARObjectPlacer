using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class AppManager : MonoBehaviour
{
    public Transform HitCubeParent;
    public GameObject PointCloud;
    public List<GameObject> Prefabs = new List<GameObject>();
    public Text AssetName;
   
    int listIndex = 0;

    bool isPointCloudActive = true;

    private float ScaleFactor = 7f;


    GameObject currentInstantiatedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        object[] resourcesObjects = Resources.LoadAll("Prefabs", typeof(Object));


        foreach (Object resourceObject in resourcesObjects)
        {            
            GameObject go = (GameObject)resourceObject;            

            Prefabs.Add(go);
        }

        if (Prefabs.Count > 0)
        {
            CreatePrefab();
            listIndex++;
        }
        else
        {
            Debug.Log("There are no PREFABS in the Resource/Prefabs folder");
        }
    }

    public void ShowNextPrefab()
    {
        Debug.Log("INDEX: " + listIndex);
        Destroy(currentInstantiatedGameObject);
        currentInstantiatedGameObject = null;
        if(listIndex >= Prefabs.Count)
        {
            listIndex = 0;

            CreatePrefab();   
        }
        else
        {
            CreatePrefab();
            listIndex++;
        }
    }

     void CreatePrefab()
    {
        currentInstantiatedGameObject = Instantiate(Prefabs[listIndex], HitCubeParent);
        currentInstantiatedGameObject.transform.position = HitCubeParent.position;
        //currentInstantiatedGameObject.transform.localScale = new Vector3(ScaleFactor, ScaleFactor, ScaleFactor);
        AssetName.text = currentInstantiatedGameObject.name;
    }

    public void HideGuides()
    {
       
        if(isPointCloudActive)
        {
            PointCloud.SetActive(false);
            isPointCloudActive = false;
        }
        else
        {
            PointCloud.SetActive(true);
            isPointCloudActive = true;
        }
        
    }

}
