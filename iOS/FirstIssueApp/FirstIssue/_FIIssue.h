// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to FIIssue.h instead.

#import <CoreData/CoreData.h>


extern const struct FIIssueAttributes {
	__unsafe_unretained NSString *contentURL;
	__unsafe_unretained NSString *coverURL;
	__unsafe_unretained NSString *issueID;
	__unsafe_unretained NSString *issueNumber;
	__unsafe_unretained NSString *publishDate;
	__unsafe_unretained NSString *title;
} FIIssueAttributes;

extern const struct FIIssueRelationships {
	__unsafe_unretained NSString *article;
} FIIssueRelationships;

extern const struct FIIssueFetchedProperties {
} FIIssueFetchedProperties;

@class FIArticle;








@interface FIIssueID : NSManagedObjectID {}
@end

@interface _FIIssue : NSManagedObject {}
+ (id)insertInManagedObjectContext:(NSManagedObjectContext*)moc_;
+ (NSString*)entityName;
+ (NSEntityDescription*)entityInManagedObjectContext:(NSManagedObjectContext*)moc_;
- (FIIssueID*)objectID;





@property (nonatomic, strong) NSString* contentURL;



//- (BOOL)validateContentURL:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSString* coverURL;



//- (BOOL)validateCoverURL:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSNumber* issueID;



@property int64_t issueIDValue;
- (int64_t)issueIDValue;
- (void)setIssueIDValue:(int64_t)value_;

//- (BOOL)validateIssueID:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSNumber* issueNumber;



@property int16_t issueNumberValue;
- (int16_t)issueNumberValue;
- (void)setIssueNumberValue:(int16_t)value_;

//- (BOOL)validateIssueNumber:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSDate* publishDate;



//- (BOOL)validatePublishDate:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSString* title;



//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;





@property (nonatomic, strong) NSSet *article;

- (NSMutableSet*)articleSet;





@end

@interface _FIIssue (CoreDataGeneratedAccessors)

- (void)addArticle:(NSSet*)value_;
- (void)removeArticle:(NSSet*)value_;
- (void)addArticleObject:(FIArticle*)value_;
- (void)removeArticleObject:(FIArticle*)value_;

@end

@interface _FIIssue (CoreDataGeneratedPrimitiveAccessors)


- (NSString*)primitiveContentURL;
- (void)setPrimitiveContentURL:(NSString*)value;




- (NSString*)primitiveCoverURL;
- (void)setPrimitiveCoverURL:(NSString*)value;




- (NSNumber*)primitiveIssueID;
- (void)setPrimitiveIssueID:(NSNumber*)value;

- (int64_t)primitiveIssueIDValue;
- (void)setPrimitiveIssueIDValue:(int64_t)value_;




- (NSNumber*)primitiveIssueNumber;
- (void)setPrimitiveIssueNumber:(NSNumber*)value;

- (int16_t)primitiveIssueNumberValue;
- (void)setPrimitiveIssueNumberValue:(int16_t)value_;




- (NSDate*)primitivePublishDate;
- (void)setPrimitivePublishDate:(NSDate*)value;




- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;





- (NSMutableSet*)primitiveArticle;
- (void)setPrimitiveArticle:(NSMutableSet*)value;


@end
