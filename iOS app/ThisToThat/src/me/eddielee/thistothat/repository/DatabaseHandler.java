package me.eddielee.thistothat.repository;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHandler extends SQLiteOpenHelper {
	
	private static final int DATABASE_VERSION = 1;
	private static final String DATABASE_NAME = "ThisToThat.db";
	
	public DatabaseHandler(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

	
	@Override
	public void onCreate(SQLiteDatabase db) {
		//Called when database is created
		db.execSQL(DatabaseConstants.SQL_CREATE_CATEGORIES_TABLES);
		db.execSQL(DatabaseConstants.SQL_CREATE_CONVERSIONTYPES_TABLES);
		db.execSQL(DatabaseConstants.SQL_CREATE_CONVERSIONRATES_TABLES);
		
		db.execSQL(DatabaseConstants.SQL_INSERT_CATEGORIES_DATA);
		db.execSQL(DatabaseConstants.SQL_INSERT_CONVERSIONTYPES_DATA);
		db.execSQL(DatabaseConstants.SQL_INSERT_CONVERSIONRATES_DATA);
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		//Called to upgrade database structure
		db.execSQL(DatabaseConstants.SQL_DROP_TABLES);
        onCreate(db);
	}
}
