using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public int numberofcubes;
    public GameObject[] Cubetype;
    public GameObject BlackCube;
    public GameObject WhiteCube;
    public GameObject ground;
    public GameObject Wall;
    public int rowhight;
    public int rowwidth;
    public int WhiteChance;
    public int BlackChance;
    public GameObject player;
    public GameObject [,] Tilelist;

    // Use this for initialization
    void Awake()
    {
        Tilelist = new GameObject [rowwidth,rowhight]; 
        int isitblack;
        int isitwhite;
        int cubetype;
        GameObject tile;
        GameObject [] possibletypes = Cubetype;


        //World spawn
        ground.transform.localScale = new Vector3(rowwidth+2, 1 , 1);
        GameObject floor = Instantiate(ground, new Vector3(rowwidth / 2, -1, 0), Quaternion.identity) as GameObject;
       
        Wall.transform.localScale = new Vector3(1, rowhight, 1);

        GameObject rightWall = Instantiate(Wall, new Vector3( - 1, rowhight/2, 0), Quaternion.identity) as GameObject;
        GameObject LeftWall = Instantiate(Wall, new Vector3(rowwidth, rowhight/2 , 0), Quaternion.identity) as GameObject;

        player.transform.position = new Vector3( rowwidth / 2 , 4, -9);
        // Done with spawning

        for (int y = 0; y < rowhight; y++)
        {
            for (int x = 0; x <rowwidth; x++)
            {  
                isitblack = Random.Range(0, BlackChance);
                
                isitwhite = Random.Range(0, WhiteChance);
               

                if (isitblack == BlackChance - 1)
                {
                    tile = Instantiate(BlackCube, new Vector3(x, y, 0), Quaternion.identity);
                    
                }
                else if (isitwhite == WhiteChance - 1)
                {
                    tile = Instantiate(WhiteCube, new Vector3(x, y, 0), Quaternion.identity);
                    

                }
                else
            
                {
                     cubetype = Random.Range(0, numberofcubes);
                    if (x == 0 && y == 0)
                    {

                    }
                    else if (x > 0 && y == 0)
                    {
                        while (Tilelist[x - 1, y].name.Contains(Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    else if (x == 0 && y > 0)
                    {
                        while (Tilelist[x, y - 1].name.Contains(Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    else if (x > 0 && y > 0)
                    {
                        Debug.Log("test1 = " + Tilelist[x - 1, y].name + "test2 =" + Cubetype[cubetype].name);
                        while (Tilelist[x - 1, y].name.Contains( Cubetype[cubetype].name) || Tilelist[x, y - 1].name.Contains(Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    tile = Instantiate(Cubetype[cubetype], new Vector3(x, y, 0), Quaternion.identity);
                   
                    
                }

                
                var Tilelocation = tile.GetComponent<Box>();
                if (Tilelocation != null)
                {
                    Tilelocation.setxy(x, y );
                    Tilelocation.setcolortype(tile.name);
                }
                Tilelist[x, y ] = tile;

                Debug.Log(Tilelist[x, y ].name);
                Debug.Log(Tilelist[x, y ].GetComponent<Box>().getx() + " "
                     + Tilelist[x, y ].GetComponent<Box>().gety());

            }

        }
    }
    public void Update()
    {
        
    }

}
