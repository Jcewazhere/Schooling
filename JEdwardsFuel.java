
/**
 * Calculates and outputs fuel reimbursments.
 * 
 * @author Jamie Edwards 
 * @version 7/25/2013
 */
public class JEdwardsFuel
{
    // instance variables - replace the example below with your own
    double sum = 0, next, miles, amount, total=0;
	int ctr = 0, n, width, i;
	String line, s;
	String filename = "F:/Java/eg2.dat";//needed file path
	StringTokenizer st;
	PrintWriter outFile = new PrintWriter("eg2.out");
	
    { Scanner inFile = new Scanner(new FileReader (filename));
	  while (inFile.hasNext())
   { line = inFile.nextLine();
     st = new StringTokenizer(line);
	  while (st.hasMoreTokens())
	  { outFile.println("Report");
	    n = Integer.parseInt(st.nextToken());
	    for(i=1; i <= n; i++)
	      {miles = Double.parseDouble(st.nextToken());
//check for positive amount of miles
//and calculate amount of reimbursment
       if(miles >= 0 && miles < 500)
	      amount = miles*.15;
	    else if(miles < 1000)
	      amount = 75 + .12*(miles - 500);
	    else if(miles < 1500)
	      amount = 135 + .10*(miles - 1000);
	    else if(miles < 2000)
	      amount = 185 + .08*(miles - 1500);	   
	    else if (miles < 3000)
	      amount = 225 + .06*(miles - 2000);
	    else
	      amount = 285 + .05*(miles - 3000);
		 
		 
//format the miles
       width = 3;
       s = leftPadOne(miles, width);
//output number of miles and amount of reimbursment
//only if miles >= 0
	    if(miles >= 0)
	      outFile.println(s +" "+ amount);
//otherwise output number of miles entered and 5*'s
       else
	      outFile.println(s +" *****");
		 
//accumulate reimbursment into total, if miles > 0
       if(miles >= 0)
	      total += amount;
		 
//add to the control counter if miles > 0
       if(miles >= 0)
	      ctr++;
}
	      //end of while(st.hasMoreTokens())
	     //end of while(inFile.hasNext())
	//output at end of file
	outFile.println("This program read "+ ctr +" non-negative inputs of miles.");//change to output formatted for loop stuff
	outFile.close();//don't forget to close the outfile
}}}
	



//   Returns miles formatted to one decimal place and padded by spaces
//   on the left so that the String returned has length width       
public static String leftpadOne (double miles, int width)
{
         String s;         // String to be returned
         int m;             //  length of s

         DecimalFormat fmt = new DecimalFormat("0.0");

         //  convert miles to a String with one decimal place
         s = fmt.format(miles);

         //  determine the length of s
         m = s.length();

         //  pad s by spaces on the left so that the resulting length of s is width
         for (int i = 0;  i < width - m;  i++)
               s = " " + s;                                          // one space between the  “ “

         return s;
}
}
}}
