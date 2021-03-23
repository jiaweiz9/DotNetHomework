using System;
using  Question1;
public class Factoy
{
    public Shape CreateShape(String type="Triangle" ,double x=10, double y=10,double z=10)
    { 
    switch( type)
        {
            case "Triangle":
                
                    Triangle myTriangle = new Triangle(x, y, z);
                    return myTriangle;
                
            case "Rectangle":
                
                    Rectangle myRectangle = new Rectangle(x, y);
                    return myRectangle;
                   
            case "Square":
                
                    Square mySquare = new Square(x, x);
                    return mySquare;
                
            default : throw new Exception("不是该工厂可生产形状！");
        }
    }
}
