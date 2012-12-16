//
//  FINewsstand.h
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import <StoreKit/StoreKit.h>
#import <Foundation/Foundation.h>

@interface FINewsstand : NSObject <SKPaymentTransactionObserver, SKProductsRequestDelegate>

+ (id)shared;

- (void)addIssues:(NSArray *)issues;
- (void)subscribeFree;
- (void)requestProductData;

@end
