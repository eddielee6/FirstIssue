//
//  FIArticleViewController.m
//  Magazine
//
//  Created by Weiran Zhang on 15/12/2012.
//  Copyright (c) 2012 First Issue. All rights reserved.
//

#import "FIArticleViewController.h"

#import "FINewsstand.h"

@interface FIArticleViewController ()

@end

@implementation FIArticleViewController

- (void)viewDidLoad {
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    NSURLRequest *request = [NSURLRequest requestWithURL:[NSURL URLWithString:@"http://firstissue.co"]];
    [_webView loadRequest:request];
}

- (IBAction)testSubscribe:(id)sender {
    [[FINewsstand shared] subscribeFree];
}
@end
