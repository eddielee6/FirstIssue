//
//  FINewsstand.m
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import "FINewsstand.h"

#import "FIIssue.h"
#import "FIArticle.h"

#import <NewsstandKit/NewsstandKit.h>
#import <StoreKit/StoreKit.h>

@interface FINewsstand ()
@property (nonatomic, strong) NSArray *products;
@end

@implementation FINewsstand

+ (id)shared {
    static FINewsstand *__sharedInstance;
    if (__sharedInstance == nil) {
        __sharedInstance = [[FINewsstand alloc] init];
    }
    return __sharedInstance;
}

- (void)addIssues:(NSArray *)issues {
    NKLibrary *library = [NKLibrary sharedLibrary];
    
    for (FIIssue *issue in issues) {
        NKIssue *newsstandIssue = [library issueWithName:issue.title];
        
        if (!newsstandIssue) {
            [library addIssueWithName:issue.title date:issue.publishDate];
        }
    }
}

#pragma mark - StoreKit

- (void)paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray *)transactions {
    for (SKPaymentTransaction *transaction in transactions) {
        switch (transaction.transactionState) {
            case SKPaymentTransactionStatePurchased:
                [self completeTransaction:transaction];
                break;
                
            case SKPaymentTransactionStateFailed:
                
                break;
                
            case SKPaymentTransactionStateRestored:

                break;
                
            default:
                break;
        }
    }
}
//
//// Sent when transactions are removed from the queue (via finishTransaction:).
//- (void)paymentQueue:(SKPaymentQueue *)queue removedTransactions:(NSArray *)transactions {
//
//}
//
//// Sent when an error is encountered while adding transactions from the user's purchase history back to the queue.
//- (void)paymentQueue:(SKPaymentQueue *)queue restoreCompletedTransactionsFailedWithError:(NSError *)error {
//
//}
//
//// Sent when all transactions from the user's purchase history have successfully been added back to the queue.
//- (void)paymentQueueRestoreCompletedTransactionsFinished:(SKPaymentQueue *)queue {
//    
//}
//
//// Sent when the download state has changed.
//- (void)paymentQueue:(SKPaymentQueue *)queue updatedDownloads:(NSArray *)downloads {
//    
//}

- (void)failedTransaction:(SKPaymentTransaction *)transaction {
    if (transaction.error.code != SKErrorPaymentCancelled) {
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Failed to subscribe" message:@"First Issue Magazine was unable to subscribe." delegate:nil cancelButtonTitle:nil otherButtonTitles:@"OK", nil];
        [alert show];
    }
}

- (void)restoreTransaction:(SKPaymentTransaction *)transaction {
    // TODO: record transaction data
    // [self provideContent: transaction.originalTransaction.payment.productIdentifier];
    
    //Finish the transaction
    [[SKPaymentQueue defaultQueue] finishTransaction: transaction];
    
}

- (void)completeTransaction: (SKPaymentTransaction *)transaction
{
    //If you want to save the transaction
    // [self recordTransaction: transaction];
    
    //Provide the new content
    //[self provideContent: transaction.payment.productIdentifier];
    
    [[SKPaymentQueue defaultQueue] finishTransaction: transaction];
    
}


- (void)productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response {
    for (SKProduct *product in response.products) {
        NSLog(@"Name: %@ - Price: %f", product.localizedTitle, product.price.doubleValue);
    }
}

- (void)subscribeFree {
    SKPayment *payment = [SKPayment paymentWithProduct:_products[0]];
    [[SKPaymentQueue defaultQueue] addPayment:payment];
}

#pragma mark - Product data

- (void)requestProductData {
    NSArray *products = @[@"co.firstissue.Magazine.subscription.free", @"co.firstissue.Magazine.subscription.onemonth"];
    SKProductsRequest *request = [[SKProductsRequest alloc] initWithProductIdentifiers:[NSSet setWithArray:products]];
    request.delegate = self;
    [request start];
}

@end
