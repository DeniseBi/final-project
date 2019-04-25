using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int x;
    public int y;
    private string color;

    public void setxy(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void setcolortype(string type)
    {
        color = type;
       
    }

    public int getx()
    {
        return x;
    }


    public int gety()
    {
        return y;
    }

    public string getcolor()
    {
        return color;
    }
}
