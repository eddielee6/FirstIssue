package me.eddielee.thistothat;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class Personalisation extends Activity {
	
	private EditText _greetingTextEdit;
	private Button _saveButton;
	private Button _cancelButton;
	
	private SharedPreferences _prefs;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.personalisation);
		
		_greetingTextEdit = (EditText)findViewById(R.id.greetingTextEdit);
		_saveButton = (Button)findViewById(R.id.saveButton);
		_cancelButton = (Button)findViewById(R.id.cancelButton);
		
		_prefs = this.getSharedPreferences(getApplicationContext().getPackageName(), Context.MODE_PRIVATE);
		
		_saveButton.setOnClickListener(saveButton_Clicked);
		_cancelButton.setOnClickListener(cancelButton_Clicked);
	}
	
	@Override
	protected void onStart() {
		super.onStart();
		
		_greetingTextEdit.setText(_prefs.getString(getApplicationContext().getPackageName()+".greeting", ""));
		_greetingTextEdit.requestFocus();
	}
	
	View.OnClickListener saveButton_Clicked = new View.OnClickListener() {
		@Override
		public void onClick(View v) {
			String newGreeting = _greetingTextEdit.getText().toString();
			if(!newGreeting.trim().isEmpty()) {
				_prefs.edit().putString(getApplicationContext().getPackageName()+".greeting", newGreeting).commit();
			} else {
				_prefs.edit().remove(getApplicationContext().getPackageName()+".greeting").commit();
			}
			finish();
		}
	};
	
	View.OnClickListener cancelButton_Clicked = new View.OnClickListener() {
		@Override
		public void onClick(View v) {
			finish();
		}
	};

}
