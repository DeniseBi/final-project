using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ScreenBuild : MonoBehaviour
{
    public int numberofcubes;
    public GameObject[] Cubetype;
   
    public GameObject ground;
    public GameObject Wall;
    public int rowhight;
    public int rowwidth;
    public int WhiteChance;
    public int BlackChance;
    public GameObject player;
    public Box[,] Tilelist;
    // Use this for initialization
    void Start()
    {
        Tilelist = new Box[rowwidth, rowhight];
        int isitblack;
        int isitwhite;
        int cubetype;
        GameObject tile;
        


        //World spawn
        ground.transform.localScale = new Vector3(rowwidth + 2, 1, 1);
        GameObject floor = Instantiate(ground, new Vector3(rowwidth / 2 , -1, 0), Quaternion.identity) as GameObject;

        Wall.transform.localScale = new Vector3(1, rowhight, 1);

        GameObject rightWall = Instantiate(Wall, new Vector3(-1, rowhight / 2 , 0), Quaternion.identity) as GameObject;
        GameObject LeftWall = Instantiate(Wall, new Vector3(rowwidth, rowhight / 2 , 0), Quaternion.identity) as GameObject;

        player.transform.position = new Vector3(rowwidth / 2, 4, -9);
        // Done with spawning
        for (int y = 0; y < rowhight; y++)
        {
            for (int x = 0; x < rowwidth; x++)
            {
                isitblack = Random.Range(0, BlackChance);

                isitwhite = Random.Range(0, WhiteChance);


                if (isitblack == BlackChance - 1)
                {
                    tile = Instantiate(Cubetype[4], new Vector3(x, y, 0), Quaternion.identity);
                    cubetype = 5;
                }
                else if (isitwhite == WhiteChance - 1)
                {
                    tile = Instantiate(Cubetype[5], new Vector3(x, y, 0), Quaternion.identity);
                    cubetype = 6;

                }
                else
                {
                    cubetype = Random.Range(0, numberofcubes);
                    if (x == 0 && y == 0)
                    {

                    }
                    else if (x > 0 && y == 0)
                    {
                        while (Tilelist[x - 1, y].getcolor().Contains( Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    else if (x == 0 && y > 0)
                    {
                        while (Tilelist[x, y - 1].getcolor().Contains(Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    else if (x > 0 && y > 0)
                    {
                        Debug.Log("test1 = " + Tilelist[x - 1, y].getcolor() + "test2 =" + Cubetype[cubetype].name);
                        while (Tilelist[x - 1, y].getcolor().Contains(Cubetype[cubetype].name) || Tilelist[x, y - 1].getcolor().Contains(Cubetype[cubetype].name))
                            cubetype = Random.Range(0, numberofcubes);
                    }
                    tile = Instantiate(Cubetype[cubetype], new Vector3(x, y, 0), Quaternion.identity);
                    tile.name = tile.name.Replace("(Clone)", "");

                }
            
               
                if (tile.GetComponent<Box>() != null)
                {
                    tile.GetComponent<Box>().setxy(x, y);
                    tile.GetComponent<Box>().setcolortype(tile.name);
                }
                Tilelist[x, y] = tile.GetComponent<Box>();

              //  Debug.Log(Tilelist[x, y].getcolor());
             //   Debug.Log(Tilelist[x, y].GetComponent<Box>().getx() + " "
                //     + Tilelist[x, y].GetComponent<Box>().gety());
            }
        }

        PrintStatus();
    }
        // Update is called once per frame
        void Update()
        {

        }

    protected void PrintStatus()
    {
        StringBuilder builder = new StringBuilder();

        for (int y = 0; y < rowhight; y++)
        {
            for (int x = 0; x < rowwidth; x++)
            {
                builder.Append(Tilelist[x, y] == null ? "null" : Tilelist[x, y].getcolor());
            }
            builder.AppendLine();
        }

        Debug.Log(builder.ToString());
    }
}

