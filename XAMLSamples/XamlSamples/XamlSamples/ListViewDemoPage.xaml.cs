// This exposes a bug in Fody with the following version of Xamarin. When the ListViewPage appears, it should show the list of colours, and it does without the Fody OnPropertyChanged implementation. With Fody, nothing happens.

//=== Xamarin Studio Community ===

//Version 6.0 (build 5104)
//Installation UUID: 82a41e4f-310a-45f1-b784-d77fca60b145
//Runtime:
//	Mono 4.4.0 (mono-4.4.0-branch/81f38a9) (64-bit)
//	GTK+ 2.24.23 (Raleigh theme)

//	Package version: 404000142

//=== Xamarin.Profiler ===

//Not Installed

//=== Apple Developer Tools ===

//Xcode 7.3.1 (10188.1)
//Build 7D1014

//=== Xamarin.Android ===

//Version: 6.1.0.48 (Xamarin Studio Community)
//Android SDK: /Users/gary/android-sdk-macosx
//	Supported Android versions:
//		2.3   (API level 10)
//		4.0.3 (API level 15)
//		4.1   (API level 16)
//		4.4   (API level 19)
//		5.0   (API level 21)
//		5.1   (API level 22)
//		6.0   (API level 23)

//SDK Tools Version: 24.4.1
//SDK Platform Tools Version: 23.1
//SDK Build Tools Version: 23.0.2

//Java SDK: /usr
//java version "1.8.0_45"
//Java(TM) SE Runtime Environment (build 1.8.0_45-b14)
//Java HotSpot(TM) 64-Bit Server VM (build 25.45-b02, mixed mode)

//Android Designer EPL code available here:
//https://github.com/xamarin/AndroidDesigner.EPL

//=== Xamarin Android Player ===

//Version: 0.6.5
//Location: /Applications/Xamarin Android Player.app

//=== Xamarin.Mac ===

//Version: 2.8.0.294 (Xamarin Studio Community)

//=== Xamarin.iOS ===

//Version: 9.8.0.294 (Xamarin Studio Community)
//Hash: 6950f7b
//Branch: cycle7
//Build date: 2016-04-24 15:35:14-0400

//=== Xamarin Inspector ===

//Version: 0.8.0.0
//Hash: dc081aa
//Branch: master
//Build date: Tue Apr 26 23:07:44 UTC 2016

//=== Build Information ===

//Release ID: 600005104
//Git revision: 1345d355d4f1b9677d91e1290a6034e2047bdf36
//Build date: 2016-04-26 12:21:45-04
//Xamarin addins: 7d85147c75b6dbb4b351906636ef76fdf60307c2
//Build lane: monodevelop-lion-cycle7

//=== Operating System ===

//Mac OS X 10.11.4
//Darwin Garys-MBP 15.4.0 Darwin Kernel Version 15.4.0
//    Fri Feb 26 22:08:05 PST 2016
//    root:xnu-3248.40.184~3/RELEASE_X86_64 x86_64

//=== Enabled user installed addins ===

//Xamarin Inspector 0.8.0.0

#define FODY			// comment out this line to see it work with the manually implemented OnPropertyChanged

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;


namespace XamlSamples {

	[ImplementPropertyChanged]
  public partial class ListViewDemoPage {
    public ListViewDemoPage()
    {
				BindingContext = this;
        InitializeComponent();
			ListViewItems = new ObservableCollection<NamedColor> (NamedColor.All);
    }

		#if FODY
		public ObservableCollection<NamedColor> ListViewItems;
		#else    
		private ObservableCollection<NamedColor> listItems;
		public ObservableCollection<NamedColor> ListViewItems {
			get {
				return listItems;
			}
			set {
				listItems = value;
				OnPropertyChanged (nameof (ListViewItems));
			}
		}
		#endif

		void Handle_Clicked (object sender, System.EventArgs e)
		{
			ListViewItems = new ObservableCollection<NamedColor> (NamedColor.All);
		}

	}
}
