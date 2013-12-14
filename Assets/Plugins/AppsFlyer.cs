using UnityEngine;
using System.Collections;
// We need this one for importing our IOS functions
using System.Runtime.InteropServices;

public class AppsFlyer : MonoBehaviour {

#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern void mTrackEvent(string eventName,string eventValue);
	
	public static void trackEvent(string eventName,string eventValue){
		mTrackEvent(eventName,eventValue);
	}
	
#elif UNITY_ANDROID
	private static AndroidJavaClass cls_AppsFlyer = new AndroidJavaClass("com.appsflyer.AppsFlyerLib");
	
	public static void trackEvent(string eventName,string eventValue){
		cls_AppsFlyer.CallStatic("sendTrackingWithEvent", eventName, eventValue);
	}
#else
	
	public static void trackEvent(string eventName,string eventValue){}
	
#endif
}