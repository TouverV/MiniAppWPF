using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace WpfApp7
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly ObservableCollection<Claim> _claims = new ObservableCollection<Claim>
        {
            new Claim { Id = 1, DateAdded = DateTime.Now, Equipment = "Компьютер", IssueType = "Не включается", Status = "Ожидает", Client = "Иванов Иван" },
            new Claim { Id = 2, DateAdded = DateTime.Now.AddDays(-2), Equipment = "Монитор", IssueType = "Битый экран", Status = "В работе", Client = "Сидоров Петр" },
            new Claim { Id = 3, DateAdded = DateTime.Now.AddDays(-5), Equipment = "Принтер", IssueType = "Не печатает", Status = "Выполнено", Client = "Петрова Мария" }
        };

        private ObservableCollection<Claim> _filteredClaims;
        public ObservableCollection<Claim> FilteredClaims
        {
            get { return _filteredClaims; }
            set
            {
                _filteredClaims = value;
                OnPropertyChanged(nameof(FilteredClaims));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FilteredClaims = _claims;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterClaims();
        }

        private void FilterClaims()
        {
            FilteredClaims = new ObservableCollection<Claim>(_claims.Where(c =>
                c.Id.ToString().Contains(SearchText) ||
                c.Equipment.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.IssueType.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Client.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
