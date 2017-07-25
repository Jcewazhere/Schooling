//FINAL****************************


   import java.io.*;
   import java.text.*;
   import java.util.*;

   public class JEDFINAL 
   {  
      public static void main(String[] args) throws Exception 
      {  PrintWriter outFile = new PrintWriter("H:S13.out");
         Scanner inFile = new Scanner(new FileReader("H:F10.txt"));
         
         String[] names = new String[42];			
         double[][]reals = new double[42][2];
         int[][]ints = new int [42][2];
         int numInArray = 0, numInFile = 0;
         double A3 =0;
      	         
         numInArray = inputData(names, reals, ints, inFile);
      	
         numInFile = leftover(inFile);
      	
         out(outFile, reals, ints, names, numInArray, numInFile);
      	
         A3 = average(ints, numInArray);
      	
         greater(A3, names, numInArray, reals);
      	
         search(names, numInArray, reals);
      	
         smallest(ints, numInArray);
      	
         finality();
      	
         inFile.close();
         outFile.close();
      	
      }//end of main
   
   /////////////////////////////
      public static void smallest(int[][] ints, int numInArray)
      {int k, minPos, i; 
         double temp;
         for(k = 0; k<numInArray-1; k++){
            minPos = k;
            for(i = k+1; i<numInArray; i++)
            {
               if(ints[i][1] <ints[minPos][1])
                  minPos=i;
            }
          
            temp = ints[minPos][1];
            ints[minPos][1] = ints[k][1];
            ints[k][1] = (int)temp;
         }
         System.out.println("The smallest number in the array was "+ints[0][1]+".");
      
      }//end of smallest
   
   
   
   		//////////////////////
      public static char search(String[] names, int numInArray, double [][] reals)
      {
         Scanner keyboard = new Scanner(System.in);
         String input;
         int TrueFalse =42, i=0;
         System.out.println("Please enter a name to search for, or a ^ to end search");
         input=keyboard.nextLine();
         if(input == "^")
            return input.charAt(0);
         else{
            for(i=0;i<numInArray;i++)
            {
               if(input.compareTo(names[i])==0)
               {TrueFalse=0;
                  break;}}
            if(TrueFalse==0)
               System.out.println(names[i]+" " +reals[i][0] +" " +reals[i][1]);
            else
               System.out.println("That name was not found.");
            return input.charAt(0);
         }
      }//end of search
   
   		
   		/////////////////////////
      public static void greater(double A3, String[] names, int numInArray, double [][]reals)
      {int i = 0;
         for(i=0;i<numInArray; i++)
         {
            if(reals[i][0]>=A3)
            {System.out.println(names[i]+" got " +reals[i][1]);}
         }
      }//end of greater
   
   		
   		////////////////////////
      public static void out(PrintWriter outFile, double [][] reals, int [][] ints, 
      	                       String [] names, int numInArray, int numInFile){
         int i=0, temp; 
      								  
      								  
         System.out.println("Names     Double      Double     Int    Int");
         for(i=0; i < numInArray; i++)
         {  
            outFile.println();
            outFile.println(names[i] +" " +reals[i][0]+" "+reals[i][1]+" "+ints[i][0]+" "+ints[i][1]);
         }
         outFile.println();
         temp = numInFile - numInArray;
         outFile.println("There are "+numInArray +"entries in this array with " +temp +" leftover");
      }//end of out
   					
   		
   		////////////////////////////////////////////
      public static int inputData(String [] names, double [][] reals, int[][] ints, Scanner inFile ){ 
         String line;
         int m = 0, i=0;
         StringTokenizer st;
         while(i<names.length && inFile.hasNext())
         {line = inFile.nextLine();
            st = new StringTokenizer(line);
            m = st.countTokens();
            names[i] = st.nextToken();
            for(int j = 1; j <m-4; j++)
            {names[i] = names[i]+" "+st.nextToken();}
            reals[i][0]=Double.parseDouble(st.nextToken());
            reals[i][1]=Double.parseDouble(st.nextToken());
            ints[i][0]=Integer.parseInt(st.nextToken());
            ints[i][1]=Integer.parseInt(st.nextToken());
            i++;
         }
         return i;
      }
   		
   		//////////////////////
      public static int leftover(Scanner inFile)
      { int leftover = 0;
         while(inFile.hasNext()){
            leftover++;
            inFile.nextLine();}
      	
         return leftover;
      }
   		
   		
      public static double average(int[][] ints, int numInArray)
      {int i = 0;
         double total = 0, A3 = 0;
         for(i=0;i<numInArray;i++)
            total += (ints[i][1] + ints[i][0]);
         A3 = total/numInArray;
         return A3;
      }//end of average
   	
      public static void finality()
      {System.out.println("This has been written by Jamie Edwards \nSo long and thanks for all the fish.");}
   
   }//end of class