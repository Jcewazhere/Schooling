/*Problem 1*****************************************
Write a program segment to initialize each element of the 
array C to 1.0 -- given double [][] C = new double [9][6];
*/
for (int i = 0; i < C.length; i++)
     {for (int j = 0; j < C[i].length; j++)
		 {C[i][j] = 1.0;
		 }
	  }
	  
/*Problem 2******************************************	  
Write a method to input numbers, one per line, into the array M
until the end of file or the array is full. The number of lines
read should be returned by the method. The array M and the input
file fileIn should be parameters. Scanner fileIn; int [] M;
*/
public static putIn(int [] m, Scanner fileIn)
 {int i = 0;
 for (int i = 0; i < C.length && fileIn.hasnext; i++)
     {m[i] = fileIn.nextInt();}
	  return i;
 }

/*Problem 3******************************************
Write a method findAvg to return the average of the values
A[1],....,A[N]. The arrays A and N should be parameters.
*/
public static findAvg(double [] A, int N)
   {double total = A[0];  
	for(int i = 1; i < N; i++)
	   {total += A[i];}
	return total/N;
	}
	
/*Problem 4*****************************************	
Write a method findLargest to return the largest value in the array B.
Use the array B as a parameter. 
int [] B;
*/
public static findLargest(int [] B)
  {int big = B[0];
   for(i=1; i < B.length; i++)
      {if(big < B[i])
	    big = B[i];
	   }
	return big;
	}
	
/*Problem 5*****************************************
Write a program segment containing a for loop which will print to the screen
on one line the name and value (what does she mean by "name"? Just the index of it? Or does
a "Rec []" have the name as well?) of the elements in the array list with num > 0 and will calculate the
real average of the values of num which are greater than 0. Then print on the next line, as appropriate
the value of mean or a message indicating there are no elements in list with num > 0.
public class Rec      Rec [] list; double mean;
{String name;
int num;}                                       //this is exactly as she typed it minus the ()
*/
double total, ctr;
string [] values;
for(i=0; i < list.length; i++)
   {if(list[i] > 0)
	   {total += list[i];    //I understand finding which are greater than 0, but how do you get the "name"?
		 values[ctr] = list[i];//does she mean just the index, list[i]?
		 ctr++;            
		}
	}
mean = total/ctr;

System.out.println("The values in the array called list are: \n");
   for(i=0; i < values.length; i++)
      {System.out.print("At index " +i +" with a value of " +values[i] +", ");
      }

if(ctr > 0)
  {	System.out.println("The mean was " +mean +".");
  }		 
else
  System.out.println("There were no values greater than zero in the array called list.");
  
  
/*Problem 6 **************************************************************
Write a complete program to do the following: Assume that a data line contains an integer followed
by a name.
Process lines until end of file Create a printed report that consists fo a table with the word REPORT as a heading.
The columns of the report will contain the name, the number, and a message. The message is GREAT if the number is 87 or more
Okay if the number is between 65 and 86 inclusive and poor otherwise.
At the bottom of the table, print, with appropriate messages, the number of names processed and the number of the values
between 65 and 86 inclusive. If there are values in that range, print their average.
Do not use arrays for storage -- store the name in a String. Use an if/else/if. Comments are unnecessary. Assume input is
from the file A:Test.dat and the output is to A:Report.txt.
*/

import java.io.*;
import java.util.*;

public class ProblemSix
{
 public static void main (String [] args) throws Exception
 { String fileName = "A:Test.dat";
	PrintWriter outFile = new PrintWriter("A:Report.Txt");
	int num = 0, totalNum = 0, numSixtyFive = 0;
   String name;
   double avg, total = 0;

   Scanner s = new Scanner(new File(fileName));
   outFile.println("REPORT:");
	ouFile.println(" ");
   while (s.hasNext()) 
    {
     totalNum++;
     num = s.nextInt();
     name = s.next();
     if(num >= 87)
	    {outFile.println(name +" " +num +" GREAT!");
	    }
	  else if(num >=65)
	    {outFile.println(name +" " +num +" Good.");
	    }
	  else
	    {outFile.println(name +" " +num +" Poor.");
	    }

     if(num >= 65 && num <= 86)
	    {total += num;
	     numSixtyFive++;
	    }
    }

outFile.println("This program processed " +(totalNum/2) +" names.");
outFile.println("This program processed " +numSixtyFive +" numbers between 65 and 86 inclusive.");
if(numSixtyFive > 0)
  {outFile.println("The average of the numbers between 65 and 86 inclusive is:");
   outFile.println((total/numSixtyFive));
  }
 outFile.close();
 }
}
