package me.eddielee.thistothat.repository;

import java.util.*;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import me.eddielee.thistothat.model.*;
import me.eddielee.thistothat.repository.DatabaseConstants.*;
import me.eddielee.thistothat.repository.StaticData.ConversionData;

public class ConversionRateRepository implements IConversionRateRepository {
	
	private SQLiteDatabase _db;
	
	public ConversionRateRepository(Context context) {
		 _db = new DatabaseHandler(context).getReadableDatabase();
	}
	
	@Override
	public List<Category> GetCategories() {
		List<Category> categories = new ArrayList<Category>();
		
	    String selectQuery = "SELECT  * FROM " + CategoriesTable.TABLE_NAME;
	    Cursor cursor = _db.rawQuery(selectQuery, null);
	    if (cursor.moveToFirst()) {
	        do {
	        	categories.add(new Category(cursor.getInt(0), cursor.getString(1)));
	        } while (cursor.moveToNext());
	    }
	    
	    return categories;
	}
	
	@Override
	public List<ConversionType> GetConversionTypesByCategoryId(int categoryId) {
		List<ConversionType> conversionTypes = new ArrayList<ConversionType>();
		
	    String selectQuery = "SELECT  * FROM " + ConversionTypesTable.TABLE_NAME + " WHERE " + ConversionTypesTable.COLUMN_NAME_CategoryID + " = '" + categoryId + "'";
	    Cursor cursor = _db.rawQuery(selectQuery, null);
	    if (cursor.moveToFirst()) {
	        do {
	        	ConversionType conversionType = new ConversionType();
	        	conversionType.setId(cursor.getInt(0));
	        	conversionType.Category = GetCategoryById(cursor.getInt(1));
	        	conversionType.FullName = cursor.getString(2);
	        	conversionType.AbbreviatedName = cursor.getString(3);
	        	conversionType.setOutputPrefix(cursor.getString(4));
	        	conversionType.setOutputSuffix(cursor.getString(5));
	        	conversionTypes.add(conversionType);
	        } while (cursor.moveToNext());
	    }
	    
	    return conversionTypes;
	}
	
	@Override
	public List<ConversionType> GetConversionTypesByCategoryIdExcludingBaseType(int categoryId, int baseTypeId) {
		List<ConversionType> conversionTypes = GetConversionTypesByCategoryId(categoryId);
		for (int i = 0; i < conversionTypes.size(); i++) {
			if(conversionTypes.get(i).getId() == baseTypeId) {
				conversionTypes.remove(i);
				break;
			}
		}
		return conversionTypes;
	}
	
	@Override
	public Category GetCategoryById(int categoryId) {
		Cursor cursor = _db.query(CategoriesTable.TABLE_NAME, new String[] { 
				CategoriesTable.COLUMN_NAME_CategoryID,
				CategoriesTable.COLUMN_NAME_NAME }, 
			CategoriesTable.COLUMN_NAME_CategoryID + "=?",
	        new String[] { String.valueOf(categoryId) }, null, null, null, null);
		
	    if (cursor != null) {
	        cursor.moveToFirst();
	        return new Category(cursor.getInt(0), cursor.getString(1));
	    } else {
	    	return null;
	    }
	}
	
	@Override
	public ConversionType GetConversionType(int conversionTypeId) {
		Cursor cursor = _db.query(ConversionTypesTable.TABLE_NAME, new String[] { 
				ConversionTypesTable.COLUMN_NAME_ConversionTypeID,
				ConversionTypesTable.COLUMN_NAME_CategoryID,
				ConversionTypesTable.COLUMN_NAME_FullNAME,
				ConversionTypesTable.COLUMN_NAME_AbbreviatedName,
				ConversionTypesTable.COLUMN_NAME_OutputPrefix,
				ConversionTypesTable.COLUMN_NAME_OutputSuffix }, 
				ConversionTypesTable.COLUMN_NAME_ConversionTypeID + "=?",
	        new String[] { String.valueOf(conversionTypeId) }, null, null, null, null);
		
	    if (cursor != null) {
	        cursor.moveToFirst();
	        ConversionType conversionType = new ConversionType();
        	conversionType.setId(cursor.getInt(0));
        	conversionType.Category = GetCategoryById(cursor.getInt(1));
        	conversionType.FullName = cursor.getString(2);
        	conversionType.AbbreviatedName = cursor.getString(3);
        	conversionType.setOutputPrefix(cursor.getString(4));
        	conversionType.setOutputSuffix(cursor.getString(5));
	        return conversionType;
	    } else {
	    	return null;
	    }
	}

	@Override
	public ConversionRate GetConversionRate(int baseTypeId, int convertToTypeId) {
		Cursor cursor = _db.query(ConversionRatesTable.TABLE_NAME, new String[] { 
				ConversionRatesTable.COLUMN_NAME_Rate }, 
				ConversionRatesTable.COLUMN_NAME_BaseTypeID + "=? AND " +
				ConversionRatesTable.COLUMN_NAME_ConvertToTypeID + "=?",
	        new String[] { String.valueOf(baseTypeId), String.valueOf(convertToTypeId) }, null, null, null, null);
		
	    if (cursor != null) {
	        cursor.moveToFirst();
	        ConversionRate conversionRate = new ConversionRate();
			conversionRate.BaseType = GetConversionType(baseTypeId);
			conversionRate.ConvertToType = GetConversionType(convertToTypeId);
	        conversionRate.Rate = cursor.getDouble(0);
	        return conversionRate;
	    } else {
	    	return null;
	    }
	}
}
