using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle LoadedAssetbundle;

    //Prefabs template
    private string RedCube = "RedCube";
    private string GreenCube = "GreenCube";
    private string BlueCube = "BlueCube";
    private string YellowCube = "YellowCube";
    private string BlackCube = "BlackCube";
    private string WhiteCube = "WhiteCube";
    private string[] Cubesnames;
    private int normalCubesNumber = 4 ;

    public ScreenBuild screenBuild;
    public Match3 match3;

    void Start()
    {
        //Create an array that will contain the cubes prefabs
        Cubesnames = new string[] { RedCube, GreenCube, BlueCube, YellowCube, BlackCube, WhiteCube};
    }
  
    public void LoadAssetBundle(string bundleUrl)
    {
        //Clear asset bundle caches
        AssetBundle.UnloadAllAssetBundles(true);
        //Load the asset bundle
        LoadedAssetbundle = AssetBundle.LoadFromFile(bundleUrl); 
        Debug.Log(LoadedAssetbundle == null ? "Failed to load AssetBundle" : "AssetBundle succesfully loaded");

        SaveTheBundle();
    }

    // Save the prefabs in the array
    void SaveTheBundle()
    {
        for(int i = 0; i < Cubesnames.Length; i++)
        {
            GameObject prefab = LoadedAssetbundle.LoadAsset(Cubesnames[i]) as GameObject; 
            screenBuild.Cubetype.Add(prefab);
 
            if (i< normalCubesNumber)
            {
                match3.tilecolor.Add(prefab.GetComponent<Renderer>().sharedMaterial);
            }
        }
        //Set up the game play
       screenBuild.SetUp();
    }

}
