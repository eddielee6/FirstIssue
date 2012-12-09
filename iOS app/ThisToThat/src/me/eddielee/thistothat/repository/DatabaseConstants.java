package me.eddielee.thistothat.repository;

public class DatabaseConstants {
	
	public static abstract class CategoriesTable {
	    public static final String TABLE_NAME = "Categories";
	    public static final String COLUMN_NAME_CategoryID = "CategoryID";
	    public static final String COLUMN_NAME_NAME = "Name";
	}
	
	public static abstract class ConversionTypesTable {
	    public static final String TABLE_NAME = "ConversionTypes";
	    public static final String COLUMN_NAME_ConversionTypeID = "ConversionTypeID";
	    public static final String COLUMN_NAME_CategoryID = "CategoryID";
	    public static final String COLUMN_NAME_FullNAME = "FullName";
	    public static final String COLUMN_NAME_AbbreviatedName = "AbbreviatedName";
	    public static final String COLUMN_NAME_OutputPrefix = "OutputPrefix";
	    public static final String COLUMN_NAME_OutputSuffix = "OutputSuffix";
	}
	
	public static abstract class ConversionRatesTable {
	    public static final String TABLE_NAME = "ConversionRates";
	    public static final String COLUMN_NAME_BaseTypeID = "BaseTypeID";
	    public static final String COLUMN_NAME_ConvertToTypeID = "ConvertToTypeID";
	    public static final String COLUMN_NAME_Rate = "Rate";
	}
	
	private static final String TEXT_TYPE = " TEXT";
	private static final String INT_TYPE = " INT";
	private static final String REAL_TYPE = " REAL";
	private static final String COMMA_SEP = ",";
	
	public static final String SQL_CREATE_CATEGORIES_TABLES =
	    "CREATE TABLE " + CategoriesTable.TABLE_NAME + " (" +
	    		CategoriesTable.COLUMN_NAME_CategoryID + " INTEGER PRIMARY KEY," +
	    		CategoriesTable.COLUMN_NAME_NAME + TEXT_TYPE + " );";
	
	public static final String SQL_CREATE_CONVERSIONTYPES_TABLES =
		"CREATE TABLE " + ConversionTypesTable.TABLE_NAME + " (" +
				ConversionTypesTable.COLUMN_NAME_ConversionTypeID + " INTEGER PRIMARY KEY," +
				ConversionTypesTable.COLUMN_NAME_CategoryID + INT_TYPE + COMMA_SEP + 
				ConversionTypesTable.COLUMN_NAME_FullNAME + TEXT_TYPE + COMMA_SEP + 
				ConversionTypesTable.COLUMN_NAME_AbbreviatedName + TEXT_TYPE + COMMA_SEP + 
				ConversionTypesTable.COLUMN_NAME_OutputPrefix + TEXT_TYPE + COMMA_SEP + 
				ConversionTypesTable.COLUMN_NAME_OutputSuffix + TEXT_TYPE + " );";
	
	public static final String SQL_CREATE_CONVERSIONRATES_TABLES =
		"CREATE TABLE " + ConversionRatesTable.TABLE_NAME + " (" +
				ConversionRatesTable.COLUMN_NAME_BaseTypeID + INT_TYPE + COMMA_SEP + 
				ConversionRatesTable.COLUMN_NAME_ConvertToTypeID + INT_TYPE + COMMA_SEP + 
				ConversionRatesTable.COLUMN_NAME_Rate + REAL_TYPE + COMMA_SEP + 
				"PRIMARY KEY (" + 
					ConversionRatesTable.COLUMN_NAME_BaseTypeID + COMMA_SEP +
					ConversionRatesTable.COLUMN_NAME_ConvertToTypeID + "));";

	public static final String SQL_DROP_TABLES =
		"DROP TABLE IF EXISTS " + ConversionRatesTable.TABLE_NAME + ";" +
		"DROP TABLE IF EXISTS " + ConversionTypesTable.TABLE_NAME + ";" +
		"DROP TABLE IF EXISTS " + CategoriesTable.TABLE_NAME + ";";
	
	
	public static final String SQL_INSERT_CATEGORIES_DATA = 
		"INSERT INTO " + CategoriesTable.TABLE_NAME + " (" + 
		CategoriesTable.COLUMN_NAME_CategoryID + ", " + 
		CategoriesTable.COLUMN_NAME_NAME + ")" +
			"SELECT '1', 'Currency'" +
			"UNION SELECT '2', 'Weight'" +
			"UNION SELECT '3', 'Length'" +
			"UNION SELECT '4', 'Speed';";
	
	public static final String SQL_INSERT_CONVERSIONTYPES_DATA = 
		"INSERT INTO " + ConversionTypesTable.TABLE_NAME + " (" + 
		ConversionTypesTable.COLUMN_NAME_ConversionTypeID + ", " + 
		ConversionTypesTable.COLUMN_NAME_CategoryID + ", " + 
		ConversionTypesTable.COLUMN_NAME_FullNAME + ", " + 
		ConversionTypesTable.COLUMN_NAME_AbbreviatedName + ", " + 
		ConversionTypesTable.COLUMN_NAME_OutputPrefix + ", " + 
		ConversionTypesTable.COLUMN_NAME_OutputSuffix + ")" +
			//Currency
			"SELECT '1', '1', 'Great British Pounds', 'GBP', '£', ''" +
			"UNION SELECT '2', '1', 'United States Dollars', 'USD', '$', ''" +
			"UNION SELECT '3', '1', 'Euros', 'EUR', 'Û', ''" +
			"UNION SELECT '4', '1', 'Japanese Yen', 'JPY', '´', ''" +
			
			//Weight
			"UNION SELECT '5', '2', 'Kilograms', 'KG', '', 'kg'" +
			"UNION SELECT '6', '2', 'Pounds', 'LBS', '', 'lbs'" +
			"UNION SELECT '7', '2', 'Stones', 'ST', '', 'st'" +
			
			//Length
			"UNION SELECT '8', '3', 'Centimeters', 'CM', '', 'cm'" +
			"UNION SELECT '9', '3', 'Inches', 'INCH', '', '\"'" +
			"UNION SELECT '10', '3', 'Miles', 'MILE', '', 'mile(s)'" +
			"UNION SELECT '11', '3', 'Kilometers', 'KM', '', 'km'" +
			
			//Speed
			"UNION SELECT '12', '4', 'Miles Per Hour', 'MPH', '', 'mph'" +
			"UNION SELECT '13', '4', 'Kilometers Per Hour', 'KMPH', '', 'km/h'" +
			"UNION SELECT '14', '4', 'Miles Per Second', 'MPS', '', 'mps'" +
			"UNION SELECT '15', '4', 'Kilometers Per Second', 'KMPS', '', 'km/s';";
	
	public static final String SQL_INSERT_CONVERSIONRATES_DATA = 
		"INSERT INTO " + ConversionRatesTable.TABLE_NAME + " (" + 
		ConversionRatesTable.COLUMN_NAME_BaseTypeID + ", " + 
		ConversionRatesTable.COLUMN_NAME_ConvertToTypeID + ", " + 
		ConversionRatesTable.COLUMN_NAME_Rate + ")" +
			//GBP
			"SELECT '1', '2', '1.60153'" +
			"UNION SELECT '1', '3', '1.23789'" +
			"UNION SELECT '1', '4', '131.520'" +
			
			//USD
			"UNION SELECT '2', '1', '0.62440'" +
			"UNION SELECT '2', '3', '0.77298'" +
			"UNION SELECT '2', '4', '82.1209'" +
			
			//EUR
			"UNION SELECT '3', '1', '0.80774'" +
			"UNION SELECT '3', '2', '0.77302'" +
			"UNION SELECT '3', '4', '106.239'" +
			
			//JPY
			"UNION SELECT '4', '1', '0.00760'" +
			"UNION SELECT '4', '2', '0.01218'" +
			"UNION SELECT '4', '3', '0.00941'" +
			
			
			//KG
			"UNION SELECT '5', '6', '2.205'" +
			"UNION SELECT '5', '7', '0.1575'" +
			
			//LBS
			"UNION SELECT '6', '5', '0.4536'" +
			"UNION SELECT '6', '7', '0.07143'" +
			
			//Stone
			"UNION SELECT '7', '5', '6.35'" +
			"UNION SELECT '7', '6', '14'" +
			
			
			//CM
			"UNION SELECT '8', '9', '0.3937'" +
			"UNION SELECT '8', '10', '0.000006214'" +
			"UNION SELECT '8', '11', '0.00001'" +
			
			//Inches
			"UNION SELECT '9', '8', '2.54'" +
			"UNION SELECT '9', '10', '0.00001578'" +
			"UNION SELECT '9', '11', '0.0000254'" +
			
			//Miles
			"UNION SELECT '10', '8', '160900'" +
			"UNION SELECT '10', '9', '63360'" +
			"UNION SELECT '10', '11', '1.609'" +
			
			//KM
			"UNION SELECT '11', '8', '100000'" +
			"UNION SELECT '11', '9', '39370'" +
			"UNION SELECT '11', '10', '0.6214'" +
			
			
			//MPH
			"UNION SELECT '12', '13', '1.609'" +
			"UNION SELECT '12', '14', '0.0002778'" +
			"UNION SELECT '12', '15', '0.000447'" +
			
			//KMPH
			"UNION SELECT '13', '12', '0.6214'" +
			"UNION SELECT '13', '14', '0.0001726'" +
			"UNION SELECT '13', '15', '0.0002778'" +
			
			//MPS
			"UNION SELECT '14', '12', '3600'" +
			"UNION SELECT '14', '13', '5794'" +
			"UNION SELECT '14', '15', '1.609'" +
			
			//KMPS
			"UNION SELECT '15', '12', '2237'" +
			"UNION SELECT '15', '13', '3600'" +
			"UNION SELECT '15', '14', '0.6214';";
}			
