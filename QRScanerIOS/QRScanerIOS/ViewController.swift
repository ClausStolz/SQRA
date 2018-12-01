//
//  ViewController.swift
//  QRScanerIOS
//
//  Created by Николай Глущенко on 01/12/2018.
//  Copyright © 2018 Николай Глущенко. All rights reserved.
//

import UIKit
import AVFoundation

class ViewController: UIViewController, AVCaptureMetadataOutputObjectsDelegate {

    @IBOutlet var videoPreview: UIView!
    @IBOutlet weak var outputValueLabel: UILabel!
    
    var video = AVCaptureVideoPreviewLayer()
    let session = AVCaptureSession()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        

        let captureDevice = AVCaptureDevice.default(for: AVMediaType.video)
        let videoInput: AVCaptureDeviceInput
            
        do {
            videoInput = try AVCaptureDeviceInput(device: captureDevice!)
            if (session.canAddInput(videoInput)) {
                session.addInput(videoInput)
            } else {
                print("input error")
            }
        } catch {
            print("error")
        }
 
        let metadataOutput = AVCaptureMetadataOutput()
        
        if (session.canAddOutput(metadataOutput)) {
            session.addOutput(metadataOutput)
            
            metadataOutput.setMetadataObjectsDelegate(self, queue: DispatchQueue.main)
            metadataOutput.metadataObjectTypes = [AVMetadataObject.ObjectType.qr]
        } else {
            print("ouput error")
        }

        
        video = AVCaptureVideoPreviewLayer(session: session)
        video.frame = view.layer.bounds
        video.videoGravity = AVLayerVideoGravity.resizeAspectFill
        view.layer.addSublayer(video)
            
        self.view.bringSubviewToFront(outputValueLabel)
        
        session.startRunning()
    }
    
    func metadataOutput(_ output: AVCaptureMetadataOutput, didOutput metadataObjects: [AVMetadataObject], from connection: AVCaptureConnection) {
        
        if let metadataObject = metadataObjects.first {
            let readableObject = metadataObject as! AVMetadataMachineReadableCodeObject;
            
            outputValueLabel.text = readableObject.stringValue!
        }
    }
}

