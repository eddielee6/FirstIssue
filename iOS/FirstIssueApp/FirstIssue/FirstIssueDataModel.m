//
//  FirstIssueDataModel.m
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import <CoreData/CoreData.h>

#import "FirstIssueDataModel.h"

@interface FirstIssueDataModel ()
@property (nonatomic, strong) NSManagedObjectModel *managedObjectModel;
@end

static NSString* const modelName = @"FirstIssueDataModel";

@implementation FirstIssueDataModel

@synthesize context = _context;
@synthesize persistentStoreCoordinator = _persistentStoreCoordinator;

+ (id)shared {
    static FirstIssueDataModel *__instance = nil;
    if (__instance == nil) {
        __instance = [FirstIssueDataModel new];
    }
    return __instance;
}

#pragma mark - Core Data

- (NSManagedObjectContext *)context {
    if (_context == nil) {
        _context = [NSManagedObjectContext new];
        _context.persistentStoreCoordinator = [self persistentStoreCoordinator];
    }
    return _context;
}

- (NSManagedObjectModel *)managedObjectModel {
    if (_managedObjectModel == nil) {
        _managedObjectModel = [NSManagedObjectModel mergedModelFromBundles:nil];
    }
    return _managedObjectModel;
}

- (NSString *)pathToLocalStore {
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *documentsDirectory = paths[0];
    //NSString *pathToModel = [[NSBundle mainBundle] pathForResource:modelName ofType:@"mom"];
    NSString *storeFilename = [modelName stringByAppendingPathExtension:@"sqlite"];
    return [documentsDirectory stringByAppendingPathComponent:storeFilename];
}

- (NSPersistentStoreCoordinator *)persistentStoreCoordinator {
    if (_persistentStoreCoordinator == nil) {
        NSURL *storeURL = [NSURL fileURLWithPath:self.pathToLocalStore];
        NSPersistentStoreCoordinator *persistentStoreCoordinator = [[NSPersistentStoreCoordinator alloc] initWithManagedObjectModel:[self managedObjectModel]];
        NSDictionary *options = @{
        NSMigratePersistentStoresAutomaticallyOption : @(YES),
    NSInferMappingModelAutomaticallyOption: @(YES)
        };
        
        NSError *error = nil;
        
        if (![persistentStoreCoordinator addPersistentStoreWithType:NSSQLiteStoreType
                                                      configuration:nil
                                                                URL:storeURL
                                                            options:options
                                                              error:&error]) {
            NSDictionary *userInfo = @{ NSUnderlyingErrorKey: error };
            NSString *reason = @"Couldn't create persistent store.";
            NSException *exception = [NSException exceptionWithName:NSInternalInconsistencyException
                                                             reason:reason
                                                           userInfo:userInfo];
            @throw exception;
        }
        
        _persistentStoreCoordinator = persistentStoreCoordinator;
    }
    
    return _persistentStoreCoordinator;
}

- (void)resetCoreStorage {
    @try {
        NSError *error = nil;
        NSPersistentStore *store = [self.persistentStoreCoordinator persistentStoreForURL:[NSURL fileURLWithPath:self.pathToLocalStore]];
        
        if ([self.persistentStoreCoordinator removePersistentStore:store error:&error]) {
            [NSFileManager.defaultManager removeItemAtPath:self.pathToLocalStore error:&error];
        }
        
        if (error) {
            NSLog(@"Failed to remove store %@", error.localizedDescription);
        }
    }
    @catch (NSException *exception) {
        NSLog(@"Failed to remove store %@", exception.name);
    }
    @finally {
        _persistentStoreCoordinator = nil;
        _managedObjectModel = nil;
        _context = nil;
    }
}

@end
