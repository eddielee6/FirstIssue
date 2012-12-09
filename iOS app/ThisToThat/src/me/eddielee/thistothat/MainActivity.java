package me.eddielee.thistothat;

import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.PixelFormat;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.*;
import android.widget.AdapterView.OnItemSelectedListener;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.*;

import me.eddielee.thistothat.model.*;
import me.eddielee.thistothat.repository.*;
import me.eddielee.thistothat.shared.ConversionTypeAdapter;
import me.eddielee.thistothat.shared.HelperFunctions.NumericTests;

public class MainActivity extends Activity {
	
	private EditText _valueForConversion;
	private Button _selectBaseType;
	private Spinner _convertToSpinner;
	private TextView _conversionResult;
	private TextView _applicationGreeting;
	
	private ConversionType _selectedBaseType;
	private String _convertToTypeId;
	private IConversionRateRepository _conversionRateRepository;
	
	private SharedPreferences _prefs;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		_conversionRateRepository = new ConversionRateRepository(this);
		
		_applicationGreeting = (TextView)findViewById(R.id.applicationGreeting);
		_valueForConversion = (EditText)findViewById(R.id.valueForConversion);
		_selectBaseType = (Button)findViewById(R.id.selectBaseType);
		_convertToSpinner = (Spinner)findViewById(R.id.convertToSpinner);
		_conversionResult = (TextView)findViewById(R.id.conversionResult);
		_conversionResult.setText(""); //Remove any text
		
		_prefs = this.getSharedPreferences(getApplicationContext().getPackageName(), Context.MODE_PRIVATE);

		_selectBaseType.setOnClickListener(selectBaseType_Clicked);
		_convertToSpinner.setOnItemSelectedListener(convertToSpinner_ItemSelected);
		_valueForConversion.addTextChangedListener(valueForConversion_TextChanged);	 
		
	}
	
	@Override
	public void onAttachedToWindow() {
		super.onAttachedToWindow();
		Window window = getWindow();
		window.setFormat(PixelFormat.RGBA_8888);
	}
	
	@Override
	protected void onStart() {
		super.onStart();
		
		_applicationGreeting.setText(_prefs.getString(getApplicationContext().getPackageName()+".greeting", "Welcome"));
		updateSelectedBaseType(_selectedBaseType);
	}
	
	View.OnClickListener selectBaseType_Clicked = new View.OnClickListener() {
		@Override
		public void onClick(View v) {
			Intent baseConversionTypeSelection = new Intent(v.getContext(), ConversionTypeMenu.class);
			startActivityForResult(baseConversionTypeSelection, 1);
		}
	};
	
	TextWatcher valueForConversion_TextChanged = new TextWatcher() {
		@Override
		public void afterTextChanged(Editable s) {
			performConversionAndUpdateUserInterface();
		}

		@Override
		public void beforeTextChanged(CharSequence s, int start, int count, int after) {
		}

		@Override
		public void onTextChanged(CharSequence s, int start, int before, int count) {
		}
	};
	
	OnItemSelectedListener convertToSpinner_ItemSelected = new OnItemSelectedListener() {
		@Override
		public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
			_convertToTypeId = String.valueOf(id);
			performConversionAndUpdateUserInterface();
		}

		@Override
		public void onNothingSelected(AdapterView<?> parent) {
		}
    };
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (resultCode == RESULT_OK && data.hasExtra("selectedBaseTypeId")) {
			updateSelectedBaseType(_conversionRateRepository.GetConversionType(Integer.parseInt(data.getStringExtra("selectedBaseTypeId"))));
		}
	}
	
	private void updateSelectedBaseType(ConversionType selectedBaseType) {
		if(selectedBaseType != null) {
			_selectedBaseType = selectedBaseType;
			_selectBaseType.setText(String.format("%s \u25BC", _selectedBaseType.AbbreviatedName));
			
			_convertToSpinner.setEnabled(true);
			List<ConversionType> validConversionTypes = _conversionRateRepository.GetConversionTypesByCategoryIdExcludingBaseType(selectedBaseType.Category.getCategoryId(), selectedBaseType.getId());
			ConversionTypeAdapter adapter = new ConversionTypeAdapter(this, validConversionTypes);
			_convertToSpinner.setAdapter(adapter);
		} else {
			//Disable convert to spinner
			_convertToSpinner.setEnabled(false);
			_convertToSpinner.setAdapter(null);
		}
	}
	
	private void performConversionAndUpdateUserInterface() {
		if(NumericTests.isFloat(_valueForConversion.getText().toString()) && (_convertToTypeId != null && _convertToTypeId != "")) {
			ConversionRate conversionToMake = _conversionRateRepository.GetConversionRate(_selectedBaseType.getId(), Integer.valueOf(_convertToTypeId));
			double result = Float.parseFloat(_valueForConversion.getText().toString()) * conversionToMake.Rate;
			NumberFormat nf = new DecimalFormat("##.##");
			String output = String.format("%s %s %s", conversionToMake.ConvertToType.getOutputPrefix(), nf.format(result), conversionToMake.ConvertToType.getOutputSuffix());
			_conversionResult.setText(output);
		} else {
			_conversionResult.setText("");
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) 
	{
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}
	
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
			case R.id.Personalisation:
				startActivity(new Intent(this, Personalisation.class));
				return true;
			case R.id.Share:
				Intent intent = new Intent(Intent.ACTION_SEND);
				intent.setType("text/html");
				intent.putExtra(Intent.EXTRA_EMAIL, "emailaddress@emailaddress.com");
				intent.putExtra(Intent.EXTRA_SUBJECT, "I've found a great new Android App!");
				intent.putExtra(Intent.EXTRA_TEXT, "Check out this great app called This To That. It can convert anything and is really fun to use!!!");

				startActivity(Intent.createChooser(intent, "Send Email"));
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

}
