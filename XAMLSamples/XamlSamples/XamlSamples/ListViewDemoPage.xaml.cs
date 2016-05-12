// This exposes a bug in Fody. When the ListViewPage appears, it should show the list of colours, and it does without the Fody OnPropertyChanged implementation. With Fody, nothing happens.

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
