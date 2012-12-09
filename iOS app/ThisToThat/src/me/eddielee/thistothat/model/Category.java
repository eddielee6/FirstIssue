package me.eddielee.thistothat.model;

public class Category {
	
	private int _id;
	private String _name;
	
	public Category(int id, String name) {
		_id = id;
		_name = name;
	}
	
	public String getName() {
		return _name;
	}
	
	public int getCategoryId() {
		return _id;
	}
	
	public String toString() {
		return _name;
	}
}