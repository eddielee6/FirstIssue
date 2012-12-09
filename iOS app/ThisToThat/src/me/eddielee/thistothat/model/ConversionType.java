package me.eddielee.thistothat.model;

public class ConversionType {
	private int _id;
	public String FullName;
	public String AbbreviatedName;
	public Category Category;
	private String _outputPrefix;
	private String _outputSuffix;
	
	public void setId(int id) {
		_id = id;
	}
	
	public int getId() {
		return _id;
	}
	
	//Prefix
	public void setOutputPrefix(String outputPrefix) {
		_outputPrefix = outputPrefix;
	}
	
	public String getOutputPrefix() {
		return (_outputPrefix != null && _outputPrefix.trim() != "") ? _outputPrefix : "";
	}
	
	//Suffix
	public void setOutputSuffix(String outputSuffix) {
		_outputSuffix = outputSuffix;
	}
	
	public String getOutputSuffix() {
		return (_outputSuffix != null && _outputSuffix.trim() != "") ? _outputSuffix : "";
	}
}
