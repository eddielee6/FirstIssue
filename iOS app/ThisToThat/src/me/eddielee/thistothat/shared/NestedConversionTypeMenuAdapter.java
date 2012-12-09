package me.eddielee.thistothat.shared;

import java.util.LinkedHashMap;
import java.util.Map;
import me.eddielee.thistothat.model.Category;
import me.eddielee.thistothat.model.ConversionType;
import me.eddielee.thistothat.R;
import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;

public class NestedConversionTypeMenuAdapter extends BaseAdapter {
	
	public final Map<Integer, ConversionTypeAdapter> _menu = new LinkedHashMap<Integer, ConversionTypeAdapter>();
	public final ArrayAdapter<Category> _categories;
	public final static int MENU_HEADER_TYPE = 0;
	
	public NestedConversionTypeMenuAdapter(Context context) {
		_categories = new ArrayAdapter<Category>(context, R.layout.list_header);
	}
	
	public void addSection(Category category, ConversionTypeAdapter conversionTypes) {
		_categories.add(category);
		_menu.put(category.getCategoryId(), conversionTypes);
	}
	
	public ConversionType getItem(int position) {
		for(int categoryId : _menu.keySet()) {
			ConversionTypeAdapter categoryConversionTypes = _menu.get(categoryId);
			int size = categoryConversionTypes.getCount() + 1;
			
			if(position < size){
				return categoryConversionTypes.getItem(position - 1);
			} else {
				position -= size;
			}
		}
		return null;
	}
	
	public int getCount() {
		// total together all sections, plus one for each section header
		int total = 0;
		for(ConversionTypeAdapter conversionTypes : _menu.values())
			total += conversionTypes.getCount() + 1;
		return total;
	}
	
	public int getViewTypeCount() {
		// assume that headers count as one, then total all sections
		int total = 1;
		for(ConversionTypeAdapter conversionTypes : _menu.values())
			total += conversionTypes.getViewTypeCount();
		return total;
	}
	
	//Determine if index is a header or item
	public int getItemViewType(int position) {
		int type = 1;
		for(int categoryId : _menu.keySet()) {
			ConversionTypeAdapter categoryConversionTypes = _menu.get(categoryId);
			int size = categoryConversionTypes.getCount() + 1;
			
			// check if position inside this section 
			if(position == 0) return MENU_HEADER_TYPE;
			if(position < size) return type + categoryConversionTypes.getItemViewType(position - 1);

			// otherwise jump into next section
			position -= size;
			type += categoryConversionTypes.getViewTypeCount();
		}
		return -1;
	}
	
	public boolean areAllItemsSelectable() {
		return false;
	}
	
	public boolean isEnabled(int position) {
		return (getItemViewType(position) != MENU_HEADER_TYPE);
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		int sectionnum = 0;

		for(int categoryId : _menu.keySet()) {
			ConversionTypeAdapter categoryConversionTypes = _menu.get(categoryId);
			
			int size = categoryConversionTypes.getCount() + 1;
			
			// check if position inside this section 
			if(position == 0) return _categories.getView(sectionnum, convertView, parent);
			if(position < size) return categoryConversionTypes.getView(position - 1, convertView, parent);

			// otherwise jump into next section
			position -= size;
			sectionnum++;
		}
		return null;
	}

	@Override
	public long getItemId(int position) {
		return getItem(position).getId();
	}
}
