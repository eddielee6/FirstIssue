package me.eddielee.thistothat.repository;

import java.util.*;

//================================================================
//================================================================
//================================================================
//========= Was used by repository before SQLite was added =======
//================================================================
//================================================================
//================================================================

import me.eddielee.thistothat.model.*;

class StaticData{
	
	public static class ConversionData {
		
		private static ConversionType GetOne() {
			ConversionType one = new ConversionType();
			one.setId(1);
			one.FullName = "Great British Pounds";
			one.AbbreviatedName = "GBP";
			one.setOutputPrefix("£");
			one.setOutputSuffix("");
			one.Category = new Category(1, "Currency");
			return one;
		}
		
		private static ConversionType GetTwo() {
			ConversionType two = new ConversionType();
			two.setId(2);
			two.FullName = "United States Dollar";
			two.AbbreviatedName = "USD";
			two.setOutputPrefix("$");
			two.setOutputSuffix("");
			two.Category = new Category(1, "Currency");
			return two;
		}
		
		private static ConversionType GetThree() {
			ConversionType three = new ConversionType();
			three.setId(3);
			three.FullName = "Euro";
			three.AbbreviatedName = "EUR";
			three.setOutputPrefix("Û");
			three.setOutputSuffix("");
			three.Category = new Category(1, "Currency");
			return three;
		}
		
		public static ArrayList<ConversionType> GetConversionTypes() {
			ArrayList<ConversionType> conversionTypes = new ArrayList<ConversionType>();
		
			conversionTypes.add(GetOne());
			conversionTypes.add(GetTwo());
			conversionTypes.add(GetThree());
			
			return conversionTypes;
		}
		
		public static ConversionType GetConversionType(int conversionTypeId) {
			if(conversionTypeId == 1) {
				return GetOne();
			} else if (conversionTypeId == 2) {
				return GetTwo();
			} else if (conversionTypeId == 3) {
				return GetThree();
			} else {
				return null;
			}
		}
		
		public static ArrayList<Category> GetCategorys() {
			ArrayList<Category> toReturn = new ArrayList<Category>();
			toReturn.add(new Category(1, "Currency"));
			return toReturn;
		}
		
		public static ArrayList<ConversionType> GetConversionTypesByCategoryId(int categoryId) {
			ArrayList<ConversionType> conversionTypes = new ArrayList<ConversionType>();
			conversionTypes.add(GetOne());
			conversionTypes.add(GetTwo());
			conversionTypes.add(GetThree());
			return conversionTypes;
		}
		
		public static ArrayList<ConversionType> GetConversionTypesByCategoryIdExcludingBaseType(int categoryId, int baseTypeId) {
			ArrayList<ConversionType> conversionTypes = new ArrayList<ConversionType>();
			
			if(baseTypeId != 1)
			conversionTypes.add(GetOne());
			
			if(baseTypeId != 2)
			conversionTypes.add(GetTwo());
			
			if(baseTypeId != 3)
			conversionTypes.add(GetThree());
			
			return conversionTypes;
		}
		
		public static ConversionRate GetConversionRate(int baseTypeId, int convertToTypeId) {
			if(baseTypeId == 1 && convertToTypeId == 2) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetOne();
				toReturn.ConvertToType = GetTwo();
				toReturn.Rate = 3.34;
				return toReturn;
			} else if (baseTypeId == 1 && convertToTypeId == 3) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetOne();
				toReturn.ConvertToType = GetThree();
				toReturn.Rate = 5.34;
				return toReturn;
			} else if (baseTypeId == 2 && convertToTypeId == 1) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetTwo();
				toReturn.ConvertToType = GetOne();
				toReturn.Rate = 5.42;
				return toReturn;
			} else if (baseTypeId == 2 && convertToTypeId == 3) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetTwo();
				toReturn.ConvertToType = GetThree();
				toReturn.Rate = 6.74;
				return toReturn;
			} else if (baseTypeId == 3 && convertToTypeId == 1) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetThree();
				toReturn.ConvertToType = GetOne();
				toReturn.Rate = 2.45;
				return toReturn;
			} else if (baseTypeId == 3 && convertToTypeId == 2) {
				ConversionRate toReturn = new ConversionRate();
				toReturn.BaseType = GetThree();
				toReturn.ConvertToType = GetTwo();
				toReturn.Rate = 2.34;
				return toReturn;
			} else {
				return null;
			}
		}
		
	}
	
}