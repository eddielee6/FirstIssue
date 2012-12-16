//
//  FIArticleViewController.h
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface FIArticleViewController : UIViewController
@property (weak, nonatomic) IBOutlet UIWebView *webView;
- (IBAction)testSubscribe:(id)sender;
@end
