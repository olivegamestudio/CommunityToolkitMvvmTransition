using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace TraditionalCommands;

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
}

public class PressMeCommand : ICommand
{
	readonly MenuViewModel _viewModel;

	public PressMeCommand(MenuViewModel viewModel)
	{
		_viewModel = viewModel;
	}

	public bool CanExecute(object? parameter)
	{
		return true;
	}

	public void Execute(object? parameter)
	{
		_viewModel.PressCount++;
		MessageBox.Show("Pressed");
	}

	public event EventHandler? CanExecuteChanged;
}

public class MenuViewModel : INotifyPropertyChanged
{
	public ICommand PressMe { get; set; }

	int _pressCount;

	public int PressCount
	{
		get => _pressCount;
		set
		{
			_pressCount = value;
			OnPropertyChanged(nameof(PressCount));
		}
	}

	public MenuViewModel()
	{
		PressMe = new PressMeCommand(this);
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
