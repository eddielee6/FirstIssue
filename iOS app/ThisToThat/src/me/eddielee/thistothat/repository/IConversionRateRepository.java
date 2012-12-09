package me.eddielee.thistothat.repository;

import java.util.*;
import me.eddielee.thistothat.model.*;

public interface IConversionRateRepository {
	List<Category> GetCategories();
	List<ConversionType> GetConversionTypesByCategoryId(int categoryId);
	List<ConversionType> GetConversionTypesByCategoryIdExcludingBaseType(int categoryId, int baseTypeId);
	
	Category GetCategoryById(int categoryId);
	ConversionType GetConversionType(int conversionTypeId);
	ConversionRate GetConversionRate(int baseTypeId, int convertToTypeId);
}
