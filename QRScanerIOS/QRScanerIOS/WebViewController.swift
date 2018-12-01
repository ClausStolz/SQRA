//
//  WebViewController.swift
//  QRScanerIOS
//
//  Created by Николай Глущенко on 01/12/2018.
//  Copyright © 2018 Николай Глущенко. All rights reserved.
//

import UIKit

class WebViewController: UIViewController {

    @IBOutlet var webView: UIWebView!
    
    var url = URL(string: "")
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let urlRequest = URLRequest(url: url!)
        webView.loadRequest(urlRequest)
    }

}
