/*
 * Updated 24/8/2010, Chris Branson, updated to RedLaser SDK 2.8.2
 * 
 * Updated 16/2/2011, Chris Branson, updated to RedLaser SDK 2.9.2
 *
 * Updated 19/4/2011, Chris Branson, updated to RedLaser SDK 3.0.0
 *
 * Updated 29/7/2011, Chris Branson, updated to RedLaser SDK 3.1.1
 *
 * Updated 4/10/2011, Chris Branson, updated to RedLaser SDK 3.2.0
 *
 * This is the public API for the RedLaser SDK.
 *
 * The functions RL_GetRedLaserSDKVersion, RL_CheckReadyStatus and FindBarcodesInUIImage can be
 * found in RedLaserSDK.cs within the RedLaser Sample (https://github.com/chrisbranson/RedLaserSample)
 *
*/

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.RedLaser
{
	/*******************************************************************************
		BarcodeResult
	
		The return type of the recognizer is a NSSet of Barcode objects.	
	*/
	[BaseType (typeof (NSObject))]
	interface BarcodeResult {
		[Export ("barcodeType")]
		int BarcodeType { get; }
		
		[Export ("barcodeString")]
		string BarcodeString { get; }
		
		[Export ("extendedBarcodeString", ArgumentSemantic.Copy)]
		int ExtendedBarcodeString { get; }
		
		[Export ("associatedBarcode")]
		BarcodeResult AssociatedBarcode { get; }
		
		[Export ("firstScanTime", ArgumentSemantic.Retain)]
		NSDate FirstScanTime { get; }
		
		[Export ("mostRecentScanTime", ArgumentSemantic.Retain)]
		NSDate MostRecentScanTime { get; }
		
		[Export ("barcodeLocation", ArgumentSemantic.Retain)]
		NSObject[] BarcodeLocation { get; }
	}

	/*******************************************************************************
		BarcodePickerControllerDelegate

		The delegate receives messages about the results of a scan. This method
		gets called when a scan session completes.
	*/
	[BaseType (typeof (NSObject))]
	[Model]
	interface BarcodePickerControllerDelegate {
		// - (void) barcodePickerController:(BarcodePickerController*)picker returnResults:(NSSet *)results;
		[Export ("barcodePickerController:returnResults:")]
		void ReturnResults (BarcodePickerController picker, NSSet results);
	}
	
	/*******************************************************************************
		CameraOverlayViewController

		An optional overlay view that is placed on top of the camera view.
		This view controller receives status updates about the scanning state, and
		can update the user interface.	
	*/
	[BaseType (typeof (UIViewController))]
	interface CameraOverlayViewController {
		//@property (readonly, assign) BarcodePickerController *parentPicker;
		[Export ("parentPicker", ArgumentSemantic.Assign)]
		BarcodePickerController ParentPicker { get; }
		
		// - (void)barcodePickerController:(BarcodePickerController*)picker statusUpdated:(NSDictionary*)status;
		[Export ("barcodePickerController:statusUpdated:")]
		void StatusUpdated (BarcodePickerController picker, NSDictionary status);
	}
	
	/*******************************************************************************
		BarcodePickerController

		This ViewController subclass runs the RedLaser scanner, detects barcodes, and
		notifies its delegate of what it found.
	*/
	[BaseType (typeof (UIViewController))]
	interface BarcodePickerController {
		[Export ("pauseScanning")]
		void PauseScanning ();
		
		[Export ("resumeScanning")]
		void ResumeScanning ();
		
		[Export ("clearResultsSet")]
		void ClearResultsSet ();
		
		[Export ("doneScanning")]
		void DoneScanning ();
		
		//[Export ("returnBarcode:withInfo:")]
		//void ReturnBarcode (string ean, NSDictionary info);
		
		[Export ("hasFlash")]
		bool HasFlash ();
		
		[Export ("turnFlash:")]
		void TurnFlash (bool enabled);
		
		[Export ("overlay", ArgumentSemantic.Retain)]
		CameraOverlayViewController Overlay { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		BarcodePickerControllerDelegate Delegate { get; set; }
		
		[Export ("scanUPCE", ArgumentSemantic.Assign)]
		bool ScanUPCE { get; set; }
		
		[Export ("scanEAN8", ArgumentSemantic.Assign)]
		bool ScanEAN8 { get; set; }
		
		[Export ("scanEAN13", ArgumentSemantic.Assign)]
		bool ScanEAN13 { get; set; }
		
		[Export ("scanSTICKY", ArgumentSemantic.Assign)]
		bool ScanSTICKY { get; set; }
		
		[Export ("scanQRCODE", ArgumentSemantic.Assign)]
		bool ScanQRCODE { get; set; }
		
		[Export ("scanCODE128", ArgumentSemantic.Assign)]
		bool ScanCODE128 { get; set; }
		
		[Export ("scanCODE39", ArgumentSemantic.Assign)]
		bool ScanCODE39 { get; set; }
		
		[Export ("scanDATAMATRIX", ArgumentSemantic.Assign)]
		bool ScanDATAMATRIX { get; set; }
		
		[Export ("scanITF", ArgumentSemantic.Assign)]
		bool ScanITF { get; set; }
		
		[Export ("scanEAN5", ArgumentSemantic.Assign)]
		bool ScanEAN5 { get; set; }
		
		[Export ("scanEAN2", ArgumentSemantic.Assign)]
		bool ScanEAN2 { get; set; }
		
		[Export ("activeRegion", ArgumentSemantic.Assign)]
		System.Drawing.RectangleF ActiveRegion { get; set; }
		
		[Export ("orientation", ArgumentSemantic.Assign)]
		MonoTouch.UIKit.UIImageOrientation Orientation { get; set; }
		
		[Export ("torchState", ArgumentSemantic.Assign)]
		bool TorchState { get; set; }
		
		[Export ("isFocusing", ArgumentSemantic.Assign)]
		bool IsFocusing { get; }
		
		[Export ("useFrontCamera", ArgumentSemantic.Assign)]
		bool UseFrontCamera { get; set; }
	}
}
