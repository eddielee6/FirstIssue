// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to FIIssue.m instead.

#import "_FIIssue.h"

const struct FIIssueAttributes FIIssueAttributes = {
	.issueID = @"issueID",
	.issueNumber = @"issueNumber",
	.publishdate = @"publishdate",
	.title = @"title",
};

const struct FIIssueRelationships FIIssueRelationships = {
	.article = @"article",
};

const struct FIIssueFetchedProperties FIIssueFetchedProperties = {
};

@implementation FIIssueID
@end

@implementation _FIIssue

+ (id)insertInManagedObjectContext:(NSManagedObjectContext*)moc_ {
	NSParameterAssert(moc_);
	return [NSEntityDescription insertNewObjectForEntityForName:@"Issues" inManagedObjectContext:moc_];
}

+ (NSString*)entityName {
	return @"Issues";
}

+ (NSEntityDescription*)entityInManagedObjectContext:(NSManagedObjectContext*)moc_ {
	NSParameterAssert(moc_);
	return [NSEntityDescription entityForName:@"Issues" inManagedObjectContext:moc_];
}

- (FIIssueID*)objectID {
	return (FIIssueID*)[super objectID];
}

+ (NSSet*)keyPathsForValuesAffectingValueForKey:(NSString*)key {
	NSSet *keyPaths = [super keyPathsForValuesAffectingValueForKey:key];
	
	if ([key isEqualToString:@"issueIDValue"]) {
		NSSet *affectingKey = [NSSet setWithObject:@"issueID"];
		keyPaths = [keyPaths setByAddingObjectsFromSet:affectingKey];
		return keyPaths;
	}
	if ([key isEqualToString:@"issueNumberValue"]) {
		NSSet *affectingKey = [NSSet setWithObject:@"issueNumber"];
		keyPaths = [keyPaths setByAddingObjectsFromSet:affectingKey];
		return keyPaths;
	}

	return keyPaths;
}




@dynamic issueID;



- (int64_t)issueIDValue {
	NSNumber *result = [self issueID];
	return [result longLongValue];
}

- (void)setIssueIDValue:(int64_t)value_ {
	[self setIssueID:[NSNumber numberWithLongLong:value_]];
}

- (int64_t)primitiveIssueIDValue {
	NSNumber *result = [self primitiveIssueID];
	return [result longLongValue];
}

- (void)setPrimitiveIssueIDValue:(int64_t)value_ {
	[self setPrimitiveIssueID:[NSNumber numberWithLongLong:value_]];
}





@dynamic issueNumber;



- (int16_t)issueNumberValue {
	NSNumber *result = [self issueNumber];
	return [result shortValue];
}

- (void)setIssueNumberValue:(int16_t)value_ {
	[self setIssueNumber:[NSNumber numberWithShort:value_]];
}

- (int16_t)primitiveIssueNumberValue {
	NSNumber *result = [self primitiveIssueNumber];
	return [result shortValue];
}

- (void)setPrimitiveIssueNumberValue:(int16_t)value_ {
	[self setPrimitiveIssueNumber:[NSNumber numberWithShort:value_]];
}





@dynamic publishdate;






@dynamic title;






@dynamic article;

	
- (NSMutableSet*)articleSet {
	[self willAccessValueForKey:@"article"];
  
	NSMutableSet *result = (NSMutableSet*)[self mutableSetValueForKey:@"article"];
  
	[self didAccessValueForKey:@"article"];
	return result;
}
	






@end
