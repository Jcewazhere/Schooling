// Jamie Edwards' Area of a Triangle 3 
// Now with methods! This program prompts  
// the user for three inputs, the sides of a
// triangle. Then calculates the perimeter and
// area of that triangle. Then it outputs the 
// lengths of the sides, the perimeter, and the
// area.
// CS 1050, Summer 2013
// Methods used
// explain()    -- tells the user what this program does
// getSide()     -- returns the user's input of a side
// calcPeri(double side1 + double side2 + double side3) 
             //caclulates the perimeter and returns it
// calcArea(double side1, double side2, double side3) 
              //returns the area of the triangle															
// outputResults(double side1, double side2, double side3, 
              //double perimeter, double area)outputs the  
              //sides, perimeter and area of the triangle
                                         
import java.util.*;
public class JamieEdwardsAreaTriangle3
{ static Scanner console = new Scanner(System.in);
  public static void main (String [] args) throws Exception
   {//user entered lengths of the sides 
	double side1, side2, side3;
	  //perimeter, half the perimeter and the area of the triangle
	  double perimeter = 0, area = 0;     
	 
	  // run the explain method to tell user what to do
	  explain();
	  //get input using the getSides method
     System.out.println("Please input the first side length.");
	  side1 = getSide();
	  System.out.println("Please input the second side length.");
	  side2 = getSide();
	  System.out.println("Please input the third side length.");
	  side3 = getSide();
	  //Calculate the perimeter 
	  perimeter = calcPeri(side1, side2, side3);
	  //Calculate area
	  area = calcArea(side1, side2, side3);
	  //output the results using the outputResults method
	  outputResults(side1, side2, side3, perimeter, area);
	}
//**************************************************************************
  public static void explain()
     //tell the user what to do
   { System.out.println("This program calculates the area of a triangle "
                        + "\ngiven user entered side lengths.");
	  System.out.println("Then it outputs the side lengths along \n"
	                     + "with the perimeter and area of the triangle,"
								+ " using methods.");
	  System.out.println("This amazing program is by Jamie Edwards.");
   }
//**************************************************************************
  public static double getSide() throws Exception
     //returns the side length input by the user
   { double num;  //holds user entered number
     num = console.nextDouble();
	  return num;
   }
//**************************************************************************
  public static double calcPeri(double side1, double side2, double side3)
     //returns the perimeter of a triangle with the sides side1, side2 
	                                                        //and side3
	  { return side1 + side2 + side3;
	}
//**************************************************************************
  public static double calcArea(double side1, double side2, double side3)
     //returns the area of a triangle with sides side1, side2 and side3.
     
	  //s is half of the perimeter.
	{ double s = (side1+side2+side3)/2;
	  return 
	  (Math.sqrt(s*(s - side1)*(s - side2)*(s - side3)));
	}	
//**************************************************************************
  public static void outputResults(double side1, double side2, double side3, 
                                   double perimeter, double area)
    //outputs the sides: side1, side2, side3; the perimeter and area of a triangle 
	 
	 //Attach the paramater's name to its explaination? The sides are side1, side2,
	 //and side3, the perimeter is perimeter, and the area is area. As explained in 
	 //the comment above this one. I don't know what you meant by that.
	 
	{ System.out.println("The side lengths you entered were: " +side1+ " " +side2+ " " 
	                   +side3+ ".");
     System.out.println("The perimeter of the triangle with those lengths is:");
	  System.out.println(perimeter +".");
	  System.out.println("The area of the triangle with is: "
	                     +area+ ".");
	}
}