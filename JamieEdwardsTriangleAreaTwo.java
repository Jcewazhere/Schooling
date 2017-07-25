/*
 Area of a Triangle Program, now with dialog boxes!
 This program asks the user to input the measurments sides of a 
 triangle into a dialog box, then calculates the perimeter and area
 of the triangle given those side lengths, then it prints 
 the results into a dialog box with formatting.
 By Jamie Edwards
 Program 3, CS 1050, Summer 2013, TR
*/

import java.util.*;
import java.text.*;
import javax.swing.JOptionPane;
public class JamieEdwardsTriangleAreaTwo
{

   public static void main (String [] args) throws Exception
   { 
    //side1, 2 and 3 are  the sides of a triangle, s is half of the  
	 // perimeter, peri is the perimeter and area is the area of the
	 //triangle
    double side1, side2, side3, peri, s, area;
    String inputString;
    StringTokenizer st;
	 //formatter for the sides, area and perimeter
    DecimalFormat df = new DecimalFormat("0.00");
    
	 //get the user entered data  
	 inputString= JOptionPane.showInputDialog
         ("Enter the sides of your triangle separated by spaces please.");
    st= new StringTokenizer(inputString);
    side1= Double.parseDouble(st.nextToken());
    side2= Double.parseDouble(st.nextToken());
	 side3= Double.parseDouble(st.nextToken()); 

  	 //calculate the perimeter and halve it for easier future calculations
	 peri= (side1 + side2 + side3);
	 s = peri/2;
    //calculate the area
    area= Math.sqrt((s*(s - side1)*(s - side2)*(s - side3)));

    //output the results
    JOptionPane.showMessageDialog
           (null, "The sides of your triangle are: " + df.format(side1) + " " 
			   + df.format(side2) 
            + " " + df.format(side3) + ".\n" 
            + "The perimeter of your triangle is: " + df.format(peri) + ".\n"
            + "The area of your triangle is: " + df.format(area) + ".\n"
            + "The unformatted area comes out to: " + area +".\n"
            + "This program was written by Jamie Edwards" 
			   );	
	 System.exit(0);
    }
}