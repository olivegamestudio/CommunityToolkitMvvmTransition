using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityToolkitMvvmCommands;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		DataContext = new MenuViewModel();
	}

	public partial class MenuViewModel : ObservableObject
	{
		[ObservableProperty]
		int _pressCount;

		[RelayCommand]
		public void PressMe()
		{
			PressCount++;
			MessageBox.Show("Pressed");
		}
	}
}
