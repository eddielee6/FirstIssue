// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to FIArticle.m instead.

#import "_FIArticle.h"

const struct FIArticleAttributes FIArticleAttributes = {
	.articleID = @"articleID",
	.author = @"author",
	.order = @"order",
	.subtitle = @"subtitle",
	.title = @"title",
};

const struct FIArticleRelationships FIArticleRelationships = {
	.issues = @"issues",
};

const struct FIArticleFetchedProperties FIArticleFetchedProperties = {
};

@implementation FIArticleID
@end

@implementation _FIArticle

+ (id)insertInManagedObjectContext:(NSManagedObjectContext*)moc_ {
	NSParameterAssert(moc_);
	return [NSEntityDescription insertNewObjectForEntityForName:@"Articles" inManagedObjectContext:moc_];
}

+ (NSString*)entityName {
	return @"Articles";
}

+ (NSEntityDescription*)entityInManagedObjectContext:(NSManagedObjectContext*)moc_ {
	NSParameterAssert(moc_);
	return [NSEntityDescription entityForName:@"Articles" inManagedObjectContext:moc_];
}

- (FIArticleID*)objectID {
	return (FIArticleID*)[super objectID];
}

+ (NSSet*)keyPathsForValuesAffectingValueForKey:(NSString*)key {
	NSSet *keyPaths = [super keyPathsForValuesAffectingValueForKey:key];
	
	if ([key isEqualToString:@"articleIDValue"]) {
		NSSet *affectingKey = [NSSet setWithObject:@"articleID"];
		keyPaths = [keyPaths setByAddingObjectsFromSet:affectingKey];
		return keyPaths;
	}
	if ([key isEqualToString:@"orderValue"]) {
		NSSet *affectingKey = [NSSet setWithObject:@"order"];
		keyPaths = [keyPaths setByAddingObjectsFromSet:affectingKey];
		return keyPaths;
	}

	return keyPaths;
}




@dynamic articleID;



- (int64_t)articleIDValue {
	NSNumber *result = [self articleID];
	return [result longLongValue];
}

- (void)setArticleIDValue:(int64_t)value_ {
	[self setArticleID:[NSNumber numberWithLongLong:value_]];
}

- (int64_t)primitiveArticleIDValue {
	NSNumber *result = [self primitiveArticleID];
	return [result longLongValue];
}

- (void)setPrimitiveArticleIDValue:(int64_t)value_ {
	[self setPrimitiveArticleID:[NSNumber numberWithLongLong:value_]];
}





@dynamic author;






@dynamic order;



- (int16_t)orderValue {
	NSNumber *result = [self order];
	return [result shortValue];
}

- (void)setOrderValue:(int16_t)value_ {
	[self setOrder:[NSNumber numberWithShort:value_]];
}

- (int16_t)primitiveOrderValue {
	NSNumber *result = [self primitiveOrder];
	return [result shortValue];
}

- (void)setPrimitiveOrderValue:(int16_t)value_ {
	[self setPrimitiveOrder:[NSNumber numberWithShort:value_]];
}





@dynamic subtitle;






@dynamic title;






@dynamic issues;

	






@end
