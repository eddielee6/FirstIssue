package me.eddielee.thistothat.shared;

public class HelperFunctions {
	
	public static class NumericTests {
		
		public static boolean isFloat(String input)
		{
			try
			{
				Float.parseFloat(input);
				return true;
			}
			catch(Exception e)
			{
				return false;
			}
		}
	}
}
