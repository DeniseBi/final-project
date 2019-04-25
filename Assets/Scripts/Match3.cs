using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Match3 : ScreenBuild
{
    List<Box> matchingtile = new List<Box>();
    List<Box> chackmatchingtile = new List<Box>();
    int listleangth;
    private Box tile;
    public int Points;
    public int PointsWorth;
    public List<Material> tilecolor;


    protected override void Start()
    {
        base.Start();
        Debug.Log("Tilelist " + Tilelist.Length);
    }


    public void check3()
    {
        StartCoroutine(CheckMatches());
    }
    

    //  wait until all the clocks fall before destroying them

    IEnumerator CheckMatches()
    {
        Debug.Log("check matches");
        yield return new WaitForSeconds(1);
       
        for (int y = 0; y < rowhight; y++)
        {
            for (int x = 0; x < rowwidth; x++)
            {
                //check On X

                tile = Tilelist[x, y];
                
               
                chackmatchingtile.Add(tile);
                for (int CheckingmatchesX = x + 1;
                    CheckingmatchesX < rowwidth &&
                    Tilelist[CheckingmatchesX, y] != null && tile != null &&
                    tile.getcolor() == Tilelist[CheckingmatchesX, y].getcolor();
                    CheckingmatchesX++)


                {

                    tile = Tilelist[CheckingmatchesX, y];
                    chackmatchingtile.Add(tile);



                }
                if (chackmatchingtile.Count() >= 3)
                {
                    foreach (Box item in chackmatchingtile)
                        if (!matchingtile.Contains(item))
                        {
                            matchingtile.Add(item);
                        }
                }
                chackmatchingtile.Clear();



                //check On Y

                tile = Tilelist[x, y];
                chackmatchingtile.Add(tile);
                for (int CheckingmatchesY = y + 1;
                    CheckingmatchesY < rowhight &&
                    Tilelist[x, CheckingmatchesY] != null && tile != null &&
                    tile.getcolor() == Tilelist[x, CheckingmatchesY].getcolor();
                    CheckingmatchesY++)
                {
                    tile = Tilelist[x, CheckingmatchesY];
                    chackmatchingtile.Add(tile);

                }

                if (chackmatchingtile.Count() >= 3)
                {
                    foreach (Box item in chackmatchingtile)
                        if (!matchingtile.Contains(item))
                        {
                            matchingtile.Add(item);
                        }
                }
                chackmatchingtile.Clear();


            }
        }
        if (matchingtile.Count != 0)
        {
            destoryboxesMatch();
            check3();
        }

    }

    // destroying matching tiles

    public void destoryboxesMatch()
    {
        foreach(Box item in matchingtile)
        {
            Points += 1 * PointsWorth;
            if (item != null)
            {  
                 destorybox(item);
            }
        }
        matchingtile.Clear();

    }

    // destroying any cude and fixing the arrey

    public void destorybox(Box tile)
    {
       
    
            int destroyedTileX = tile.getx();
            int destroyedTileY = tile.gety();

      
        Destroy(tile.gameObject);

        for (int y = destroyedTileY; y < rowhight; y++)
            {
                if (y < rowhight - 1)
                 {
              
                      Tilelist[destroyedTileX, y] = Tilelist[destroyedTileX, y + 1];
                if(Tilelist[destroyedTileX, y + 1] != null)
                Tilelist[destroyedTileX, y].setxy(destroyedTileX, y);
                  }
            else
            {
                Tilelist[destroyedTileX, y] = null;
            }
            
            }
 
    }



    //destorying a black box
    public void destoryBlack(Box tile)
    {
        
        
        int destroyedTileX = tile.getx();
        int destroyedTileY = tile.gety();
        

       for (int y = destroyedTileY-1; y <= destroyedTileY +1; y++)
        { 
            for (int x = destroyedTileX - 1; x <= destroyedTileX + 1; x++)
            {   
                if (y >= 0 && x >= 0 && y < rowhight && x < rowwidth && Tilelist[x, y] != null)
                {
                    if (!matchingtile.Contains(Tilelist[x, y]))
                    {  
                        matchingtile.Add(Tilelist[x, y]);

                    }

                }
                
            }
        }
        
        destoryboxesMatch();

    }


    //destorying a White box

    public void destoryWhite(Box tile)
    {
        int destroyedTileX = tile.getx();
        int destroyedTileY = tile.gety();
        int random = Random.Range(0, numberofcubes);
        for (int y = destroyedTileY - 1; y <= destroyedTileY + 1; y++)
        {
            for (int x = destroyedTileX - 1; x <= destroyedTileX + 1; x++)
                if (y >= 0 && x >= 0 && y < rowhight && x < rowwidth && Tilelist[x, y] != null)
                {

                    Tilelist[x, y].gameObject.GetComponent<Renderer>().material = tilecolor[random];
                    Tilelist[x, y].name = tilecolor[random].name;
                    Tilelist[x, y].setcolortype(Tilelist[x, y].name);
                    random = Random.Range(0, numberofcubes);
                }

        }
    }

 

}