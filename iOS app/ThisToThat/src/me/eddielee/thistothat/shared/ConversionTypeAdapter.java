package me.eddielee.thistothat.shared;

import java.util.*;

import android.content.Context;
import android.graphics.Color;
import android.graphics.Typeface;
import android.view.*;
import android.widget.*;

import me.eddielee.thistothat.model.*;

public class ConversionTypeAdapter extends ArrayAdapter<ConversionType> {
	
	private Context _context;
	private List<ConversionType> _conversionTypesList;
	 
	
	public ConversionTypeAdapter(Context context, List<ConversionType> conversionTypes) {
		super(context, android.R.layout.simple_spinner_item, conversionTypes);
		_context = context;
		_conversionTypesList = conversionTypes;
	}
	
	public int getCount() {
		return _conversionTypesList.size();
	}
	
	public ConversionType getItem(int position) {
		return _conversionTypesList.get(position);
	}
	
	public long getItemId(int position) {
		return _conversionTypesList.get(position).getId();
	}
	
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        return GetLayout(position);
    }
    
    @Override
    public View getDropDownView(int position, View convertView, ViewGroup parent) {
    	return GetLayout(position);
    }
    
    private LinearLayout GetLayout(int position) {
    	LinearLayout layout = new LinearLayout(_context);
    	layout.setOrientation(0);
    	layout.setVerticalGravity(16);
    	layout.setPadding(10, 10, 10, 10);
    	
        TextView fullNameLabel = new TextView(_context);
        fullNameLabel.setTextColor(Color.BLACK);
        fullNameLabel.setTextSize(16);
        fullNameLabel.setTypeface(Typeface.defaultFromStyle(1));
        fullNameLabel.setText(_conversionTypesList.get(position).FullName);
        layout.addView(fullNameLabel);
        
        TextView abbreviatedNameLabel = new TextView(_context);
        abbreviatedNameLabel.setTextColor(Color.LTGRAY);
        abbreviatedNameLabel.setTextSize(12);
        abbreviatedNameLabel.setTypeface(Typeface.defaultFromStyle(0));
        abbreviatedNameLabel.setText(" - " + _conversionTypesList.get(position).AbbreviatedName);
        layout.addView(abbreviatedNameLabel);
        
        return layout;
    }
}