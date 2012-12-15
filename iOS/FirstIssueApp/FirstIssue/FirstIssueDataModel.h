//
//  FirstIssueDataModel.h
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FirstIssueDataModel : NSObject

+ (id)shared;

@property (nonatomic, readonly) NSManagedObjectContext *context;
@property (nonatomic, readonly) NSPersistentStoreCoordinator *persistentStoreCoordinator;

@end
