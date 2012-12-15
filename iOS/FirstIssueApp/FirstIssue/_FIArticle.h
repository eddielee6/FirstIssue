// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to FIArticle.h instead.

#import <CoreData/CoreData.h>


extern const struct FIArticleAttributes {
	__unsafe_unretained NSString *articleID;
	__unsafe_unretained NSString *author;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *subtitle;
	__unsafe_unretained NSString *title;
} FIArticleAttributes;

extern const struct FIArticleRelationships {
	__unsafe_unretained NSString *issues;
} FIArticleRelationships;

extern const struct FIArticleFetchedProperties {
} FIArticleFetchedProperties;

@class FIIssue;







@interface FIArticleID : NSManagedObjectID {}
@end

@interface _FIArticle : NSManagedObject {}
+ (id)insertInManagedObjectContext:(NSManagedObjectContext*)moc_;
+ (NSString*)entityName;
+ (NSEntityDescription*)entityInManagedObjectContext:(NSManagedObjectContext*)moc_;
- (FIArticleID*)objectID;





@property (nonatomic, strong) NSNumber* articleID;



@property int64_t articleIDValue;
- (int64_t)articleIDValue;
- (void)setArticleIDValue:(int64_t)value_;

//- (BOOL)validateArticleID:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSString* author;



//- (BOOL)validateAuthor:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSNumber* order;



@property int16_t orderValue;
- (int16_t)orderValue;
- (void)setOrderValue:(int16_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSString* subtitle;



//- (BOOL)validateSubtitle:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSString* title;



//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) FIIssue *issues;

//- (BOOL)validateIssues:(id*)value_ error:(NSError**)error_;





@end

@interface _FIArticle (CoreDataGeneratedAccessors)

@end

@interface _FIArticle (CoreDataGeneratedPrimitiveAccessors)


- (NSNumber*)primitiveArticleID;
- (void)setPrimitiveArticleID:(NSNumber*)value;

- (int64_t)primitiveArticleIDValue;
- (void)setPrimitiveArticleIDValue:(int64_t)value_;




- (NSString*)primitiveAuthor;
- (void)setPrimitiveAuthor:(NSString*)value;




- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (int16_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(int16_t)value_;




- (NSString*)primitiveSubtitle;
- (void)setPrimitiveSubtitle:(NSString*)value;




- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;





- (FIIssue*)primitiveIssues;
- (void)setPrimitiveIssues:(FIIssue*)value;


@end
