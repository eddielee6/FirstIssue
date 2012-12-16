//
//  FIMainSplitViewController.m
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import "FIMainSplitViewController.h"

#import "FIIssuesTableViewController.h"
#import "FIArticleViewController.h"
#import "FINewsstand.h"

@interface FIMainSplitViewController ()
@property (nonatomic, strong) FIIssuesTableViewController *issuesViewController;
@property (nonatomic, strong) FIArticleViewController *articleViewController;
@end

@implementation FIMainSplitViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //_issuesViewController = self.viewControllers
    [[FINewsstand shared] requestProductData];
}

- (BOOL)splitViewController:(UISplitViewController *)svc shouldHideViewController:(UIViewController *)vc inOrientation:(UIInterfaceOrientation)orientation {
    return YES;
}

@end
