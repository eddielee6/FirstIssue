package me.eddielee.thistothat;


import java.util.List;
import me.eddielee.thistothat.model.Category;
import me.eddielee.thistothat.model.ConversionType;
import me.eddielee.thistothat.repository.ConversionRateRepository;
import me.eddielee.thistothat.repository.IConversionRateRepository;
import me.eddielee.thistothat.shared.NestedConversionTypeMenuAdapter;
import me.eddielee.thistothat.shared.ConversionTypeAdapter;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;

public class ConversionTypeMenu extends Activity {
	
	private IConversionRateRepository _conversionRateRepository;
	private ListView menu;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		_conversionRateRepository = new ConversionRateRepository(this);
		
        NestedConversionTypeMenuAdapter menuAdapter = new NestedConversionTypeMenuAdapter(this);
        
        for(Category category : _conversionRateRepository.GetCategories()) {
        	List<ConversionType> conversionTypes = _conversionRateRepository.GetConversionTypesByCategoryId(category.getCategoryId());
        	ConversionTypeAdapter conversionTypesAdapter = new ConversionTypeAdapter(this, conversionTypes);
			menuAdapter.addSection(category, conversionTypesAdapter);
        }
          
        menu = new ListView(this);
        menu.setOnItemClickListener(menu_ItemClicked);
        menu.setAdapter(menuAdapter);
        this.setContentView(menu);
	}
	
	OnItemClickListener menu_ItemClicked = new OnItemClickListener() {
		@Override
		public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
			ConversionBaseTypeSelected(id);
		}
	};
	
    
    private void ConversionBaseTypeSelected(long conversionBaseTypeId) {
    	Intent data = new Intent();
	  	data.putExtra("selectedBaseTypeId", String.valueOf(conversionBaseTypeId));
  		setResult(RESULT_OK, data);
  		finish();
    }
}